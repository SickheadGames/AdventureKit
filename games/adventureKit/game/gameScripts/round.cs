//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function fireRound( %config, %owner, %dir, %offset, %height )
{
   // Calculate the rotation.
   %dirX = GetWord( %dir, 0 );
   %dirY = GetWord( %dir, 1 );
   %rot = mRadToDeg( mAtan( %dirY , %dirX ) );
      
   // The fired rounds are based on three objects.
   %sg = %owner.getSceneGraph();
   
   // First create the part that is actually fired
   // which has collision and is invisible.
   %fired = new t2dStaticSprite()
   {
      config = %config;
      scenegraph = %sg;
      owner = %owner;
   };
   %fired.setVisible( false );
   if ( %config.rotWithVelocity )
      %fired.setRotation( %rot );

   // At the center of the fired object we mount
   // a dummy object which is only used to offset
   // the mount position of the visual projectile
   // based on the firing height of the projectile.
   %dummy = new t2dSceneObject()
   {
      scenegraph = %sg;
   };
   %height = %owner.getWorldValue( %height );
   %dummy.setSize( %height * 2, %height * 2 );
   %dummy.mount( %fired, 0, 0, 0, false, true, true, false );

   // The final object is the visible projectile
   // which is just decoration... no collision.
   %round = new t2dStaticSprite()
   {
      config = %config;
      scenegraph = %sg;
      position = "0 0";
   };
   %round.setCollisionActive( false, false );
   %round.setSortPoint( %round.getLocalPoint( 0 SPC %height ) );
   if ( %config.rotWithVelocity )
      %round.setRotation( %rot );
   %round.mount( %dummy, 0, -1, 0, false, true, true, false );

   // Do we have a trail effect to spawn?
   if ( %config.trailEffect !$= "" )
   {
      %effect = new t2dParticleEffect()
      {
         scenegraph = %sg;
         effectFile = %config.trailEffect;
         layer = %config.layer - 1;
      };
      if ( !%config.rotWithVelocity )
         %effect.setRotation( %rot );
      %effect.mount( %round, "0 0", 0, true, true, true, false );
      %effect.playEffect( true );    
      %fired.trailEffect = %effect;
   }
   
   %fired.fire( %dir, %offset );
}

function Round::onRemove( %this )
{
   // Dismout the trail object and let it die on it's own.
   if ( isObject( %this.trailEffect ) )
   {
      %this.trailEffect.dismount();
      %this.trailEffect.stopEffect( true, true );
   }   
}

function Round::fire( %this, %dir, %offset )
{
   // We fire the projectile from the sort point
   // pushed out by the offset plus a little fudge
   // value based on the owner velocity.
   %owner = %this.owner;
   %offset = %owner.getWorldValue( %offset );
   %velTweak = t2dVectorLength( %owner.getLinearVelocity() ) * 0.200;
   %pos = %owner.getWorldPoint( %owner.getSortPoint() );
   %pos = t2dVectorAdd( %pos, t2dVectorScale( %dir, %offset + %velTweak ) );

   %vel = t2dVectorScale( %dir, %this.speed );

   // Set the start position and velocity.
   %this.setPosition( %pos );
   %this.setLinearVelocity( %vel );

   // Do the fire sound!
   if ( isObject( %this.fireAudio ) )
      createSoundEmitter( %this.getSceneGraph(), %this.owner, %this.fireAudio, true );

   // If a round doesn't hit anything we still want it to
   // eventually delete itself.  So schedule it to delete
   // itself if it doesn't hit anything.
   %this.schedule( %this.deleteMS, safeDelete );
}


function Round::onCollision( %this, %object, %srcRef, %dstRef, %time, %normal, %contactCount, %contacts )
{
   // Is this an explosive round?
   if ( %this.damageRadius > 0 )
   {
      %this.explode();
      return;
   }

   // If the object hit has life then try to damage it.
   if ( %object.life > 0 )
      %object.damage( %this.damage, false, %this.owner );
      
   // Go away!
   %this.safeDelete();
}

function Round::explode( %this )
{
   %pos = %this.getPosition();
   %sg = %this.getSceneGraph();
   %layer = %this.getLayer();
   
   // Fire off explosion particle effect.
   if ( %this.explodeEffect !$= "" )
   {   
      %effect = new t2dParticleEffect()
      {
         scenegraph = %sg;
         effectFile = %this.explodeEffect;
         layer = %layer - 1;
         position = %pos;
         effectMode = "KILL";
         effectTime = 2;
      };
      %effect.playEffect( false );    
   }

   // Do some more special effects!
   if ( isObject( %this.explodeAudio ) )
      createSoundEmitter( %sg, %pos, %this.explodeAudio, true );   

   // Do radius damage.
   %this.splashDamage( %this.damageRadius, %this.damage );
   
   // Go away!
   %this.safeDelete();
}
