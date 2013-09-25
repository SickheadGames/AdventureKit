//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function SpawnPoint::spawn( %this, %spawnee, %noEffects )
{
   %pos = %this.getPosition();
   
   // First move the camera to our location!
   if ( %spawnee.isControlled )
   {
      $camera.setTarget( 0 );
      $camera.setPosition( %pos );
      $camera.setZoom( 1 );
   }

   %sg = %this.getSceneGraph();
   
   // Fire off the spawn effect!
   if ( !%noEffects && %this.effectFile !$= "" )
   {
      %effect = new t2dParticleEffect()
      {
         scenegraph = %sg;
         effectFile = %this.effectFile;
      };
      
      if ( %this.effectTime > 0 )
         %effect.setEffectLifeMode( KILL, %this.effectTime );
         
      %effect.setPosition( %pos );
      %effect.playEffect( true );
   }

   // Do the sound effect!
   if ( !%noEffects && %this.effectAudio !$= 0 )
      createSoundEmitter( %sg, %pos, %this.effectAudio, true );

   // After a bit schedule the spawn of the player.
   if ( %noEffects )
      %spawnee.onSpawn( %pos );
   else
      %spawnee.schedule( %this.spawnDelayMS, onSpawn, %pos );
}
