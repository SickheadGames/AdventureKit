//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function newCorpse( %player )
{
   %sg = %player.getSceneGraph();
   
   %corpse = new t2dAnimatedSprite()
   {
      class = Corpse;
      scenegraph = %sg;
      layer = %player.getLayer();
      position = %player.getPosition();
      sortPoint = %player.getSortPoint();
   };
   
   // Start the death throw!
   %anim = getNearestDirAnim( %player.direction, %player.deathAnimsSet );
   %corpse.setAnimation( %anim );
   %corpse.setPixelScale( %player.getPixelScale() );
   createSoundEmitter( %sg, %corpse, %player.deathAudio, true );

   return %corpse;
}

