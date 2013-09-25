//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


// The Breakable is a special object than when damaged enough
// will hide itself and then optionally play some effects, turn
// on a broken object or group, drop a scorch mark, do some splash
// damage, and/or do a camera shake.


/// This is called by weapons and the splash damage function
/// when damage should be inflicted on the object.
function Breakable::damage( %this, %damage, %splash )
{
   // If it's already dead... we can't damage it.
   if ( %this.life <= 0 )
      return;

   // Check to see if we should accept this damage.
   if ( ( %splash && %this.noSplashDamage ) ||
        ( !%splash && %this.onlySplashDamage ) )
      return;

   %this.life -= %damage;

   // If we still have life we have nothing to do.
   if ( %this.life > 0 )
      return;

   %sg = %this.getSceneGraph();
   %pos = %this.getPosition();
   %layer = %this.getLayer();
   
   // Fire off explosion particle effect.
   if ( %this.explodeEffect !$= "" )
   {
      %effect = new t2dParticleEffect()
      {
         scenegraph = %sg;
         effectFile = %this.explodeEffect;
         position = %pos;
         size = %this.getSize();
         layer = %layer - 1;
         effectMode = "KILL";
      };
      %effect.playEffect( false );    
   }

   // Drop a blast mark on the ground.
   if ( %this.explodeMark !$= "" )
   {
      new t2dStaticSprite()
      {
         scenegraph = %sg;
         imageMap = %this.explodeMark;
         frame = %this.explodeMarkFrame;
         layer = %layer + 1;
         position = t2dVectorAdd( %pos, %this.explodeMarkOffset );
      };
   }

   // Replace us with the breakable version.
   if ( isObject( %this.breakObject ) )
      %this.breakObject.setVisible( true );

   // Play the audio effect.
   if ( isObject( %this.explodeAudio ) )
      createSoundEmitter( %sg, %pos, %this.explodeAudio, true );

   if ( %this.cameraShakeMag > 0 )
      $camera.shakeCamera( %this.cameraShakeMag, %this.cameraShakeTime );

   // Do radius damage.
   if ( %this.splashDamage > 0 )
      %this.splashDamage( %this.splashRadius, %this.splashDamage );
      
   // Remove the sprite from the scene.   
   %this.safeDelete();
}
