//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


if ( !isObject( $soundEmitters ) )
   $soundEmitters = new SimSet();


function createSoundEmitter( %sg, %mountOrPoint, %profile, %playOnce )
{
   // Get the position this emitter will be created at.
   if ( getWordCount( %mountOrPoint ) == 1 && isObject( %mountOrPoint ) )
      %pos = %mountOrPoint.getPosition();
   else
      %pos = %mountOrPoint;

   // Make sure we have a good default volume.
   %volume = %profile.volume;
   if ( %volume $= "" )
      %volume = 1;

   // Get a good default size.
   %size = %profile.radius * 2;
   if ( %size == 0 )
      %size = 20;

   // Create a scene object to act as our emitter.
   %emitter = new t2dSceneObject()
   {
      config      = SoundEmitterConfig;

      scenegraph  = %sg;

      position = %pos;
      size = %size SPC %size;
      
      profile = %profile;
      playOnce = %playOnce;
      volume = %volume;

      _handle = 0;
      _paused = false;
   };
   
   // If we are mounted... do the mounting now.
   if ( isObject( %mountOrPoint ) )
      %emitter.mount( %mountOrPoint, "0 0", 0, false, true, true, true );

   return %emitter;
}

function SoundEmitter::onAdd( %this )
{
   // Update the capsule data used in _attenuateVolume.
   %this._updateCapsule();

   // Start playback!
   %this.play();

   // Add it to our emitter list!  If this is the 
   // first emitter then start the update thread.
   $soundEmitters.add( %this );
   if ( $soundEmitters.getCount() == 1 )
      schedule( 200, 0, updateSoundEmitters );
}

function SoundEmitter::onRemove( %this )
{
   %this.stop();
}

function SoundEmitter::_updateCapsule( %this )
{
   // Calculate the cap points of the capsule.
   %width   = %this.getWidth();
   %height  = %this.getHeight();

   if ( %width > %height )
   {
      %radius = %height / 2;
      %half = ( %width / 2 ) - %radius;
      %p0 = -%half SPC 0;
      %p1 = %half SPC 0;
   }
   else
   {
      %radius = %width / 2;
      %half = ( %height / 2 ) - %radius;
      %p0 = 0 SPC -%half;
      %p1 = 0 SPC %half;
   }
   
   %this._p0 = %p0;
   %this._p1 = %p1;
   %this._radius = %radius;
}

function SoundEmitter::isStopped( %this )
{
   return !alxIsPlaying( %this._handle );
}

function SoundEmitter::play( %this )
{
   // If we're already playing don't change anything!
   if ( alxIsPlaying( %this._handle ) )
      return;

   %this._paused = false;

   // Do we need to allocate a handle?
   if ( %this._handle == 0 && %this.profile !$= "" )
      %this._handle = alxCreateSource( %this.profile, "0 0 0" );
           
   // Adjust the volume now.
   %this._attenuateVolume();
   
   // Start playback!
   alxPlay( %this._handle );
}

function SoundEmitter::stop( %this )
{
   if ( !alxIsPlaying( %this._handle ) )
      return;

   alxStop( %this._handle );
   %this._handle = 0;
   %this._paused = false;
}

function SoundEmitter::pause( %this )
{
   if ( !alxIsPlaying( %this._handle ) )
      return;

   %this._paused = true;
   alxStop( %this._handle );
   
   // Pausing doesn't work right... so just
   // clear the handle and let play reload it.
   %this._handle = 0;
}

function SoundEmitter::update( %this )
{
   // If the sound is paused or ambient then we 
   // have no update to do.
   if ( %this._paused || %this.ambient )
      return;

   %playing = alxIsPlaying( %this._handle );
   
   // If the sound is stopped and was set to play once
   // then delete ourselves.
   if ( !%playing && %this.playOnce )
   {
      %this.safeDelete();
      return;
   }
   
   // The workhorse... we now adjust the volume based
   // on emitter size and distance to camera.
   if ( %playing )
      %this._attenuateVolume();
}

function distPtToSegment( %pt, %p0, %p1 )
{
   %v = t2dVectorSub( %p1, %p0 );
   %w = t2dVectorSub( %pt, %p0 );

   %c1 = t2dVectorDot( %w, %v );
   if ( %c1 <= 0 )
      return t2dVectorDistance( %pt, %p0 );

   %c2 = t2dVectorDot( %v, %v );
   if ( %c2 <= %c1 )
      return t2dVectorDistance( %pt, %p1 );

   %b = %c1 / %c2;
   %pb = t2dVectorAdd( %p0, t2dVectorScale( %v, %b ) );
   return t2dVectorDistance( %pt, %pb );
}

function SoundEmitter::_attenuateVolume( %this )
{     
   // We don't adjust the volume for ambient sounds.
   if ( %this.ambient )
      %volume = 1;

   // If we have no camera then we can't hear anything!
   else if ( !isObject( $camera ) )
      %volume = 0;
      
   else
   {
      // Get the relative position to the camera. 
      %pos = t2dVectorSub( %this.getPosition(), $camera.getPosition() );
      
      // Mounted objects are always treated as
      // radial sources for simplicity.
      if ( %this.getIsMounted() )
      {
         %dist = t2dVectorLength( %pos );
         %radius = %this.getWidth() / 2;
      }
      else
      {
         // Get the distance to the capsule!
         %dist = distPtToSegment( %pos, %this._p0, %this._p1 );
         %radius = %this._radius;
      }

      // We want the sound to linearly ramp up to 50%
      // of the radius then stay at full volume.
      // hence the .99 maximum.
      %volume = t2dGetMax( 0, 1 - ( %dist / %radius ) );
      %volume = t2dGetMin( 1, %volume / 0.5 );
   }
   
   // Ok... set the volume now.
   alxSourcef( %this._handle, AL_GAIN_LINEAR, %volume * %this.volume );
}

function updateSoundEmitters()
{
   %count = $soundEmitters.getCount();
   for ( %i=0; %i < %count; %i++ )
   {
      %emitter = $soundEmitters.getObject( %i );
      %emitter.update();
   }

   // If we still have emitters then we continue
   // to run this update thread.
   if ( %count != 0 )
      schedule( 200, 0, updateSoundEmitters );
}

function setSoundEmittersPaused( %pause )
{
   if ( %pause $= "" )
      %pause = true;

   %count = $soundEmitters.getCount();
   for ( %i=0; %i < %count; %i++ )
   {
      %emitter = $soundEmitters.getObject( %i );
      if ( %pause )
         %emitter.pause();
      else if ( %emitter._paused )
         %emitter.play();
   }
}
