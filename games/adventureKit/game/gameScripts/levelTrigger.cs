//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function LevelTrigger::onEnter( %this, %object )
{
   // If we have no file then don't bother
   // reacting to the trigger.
   if ( %this.levelFile $= "" )
      return;

   %pos = %object.getPosition();
   %sg = %object.getSceneGraph();
   
   // Fire off the spawn effect!
   if ( %this.effectFile !$= "" )
   {
      %effect = new t2dParticleEffect()
      {
         scenegraph = %sg;
         effectFile = %this.effectFile;
         effectTime = %this.effectTime;
      };
      %effect.setPosition( %pos );
      %effect.playEffect( true );
   }

   // Do the sound effect!
   if ( %this.effectAudio !$= "" )
      createSoundEmitter( %sg, %pos, %this.effectAudio, true );

   // Delete the player.
   %object.safeDelete();
   
   // Schedule the level change.
   %time = ( %this.effectTime * 1000 ) + 750;
   schedule( %time, 0, loadLevel, %this.levelFile, %this.optionalSpawnPoint );
}
