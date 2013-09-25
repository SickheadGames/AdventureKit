//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


// This file contains extensions that we have
/// added to the base t2d namespaces.


function t2dStaticSprite::getPixelScale( %this, %frame )
{
   if ( %frame $= "" )
      %frame = %this.getFrame();
      
   %size = %this.getSize();
   %pix  = %this.getImageMap().getFrameSize( %frame );

   return   ( getWord( %size, 0 ) / getWord( %pix, 0 ) ) SPC
            ( getWord( %size, 1 ) / getWord( %pix, 1 ) );
}

function t2dStaticSprite::setPixelScale( %this, %scale, %frame )
{
   if ( %frame $= "" )
      %frame = %this.getFrame();

   %pix = %this.getImageMap().getFrameSize( %frame );

   %this.setSize( t2dVectorScale( %pix, %scale ) );
}

function t2dAnimatedSprite::getPixelScale( %this, %frame )
{
   %anim = %this.getAnimation();
   
   if ( %frame $= "" )
      %frame = %anim.startFrame;

   %size = %this.getSize();
   %pix  = %anim.imageMap.getFrameSize( %frame );

   return   ( getWord( %size, 0 ) / getWord( %pix, 0 ) ) SPC
            ( getWord( %size, 1 ) / getWord( %pix, 1 ) );
}

function t2dAnimatedSprite::setPixelScale( %this, %scale, %frame )
{
   %anim = %this.getAnimation();
   
   if ( %frame $= "" )
      %frame = %anim.startFrame;
      
   %pix  = %anim.imageMap.getFrameSize( %frame );

   %this.setSize( t2dVectorScale( %pix, %scale ) );
}

function t2dSceneObject::fadeBlendAlpha( %this, %step, %ms )
{
   // Cancel any current fading effects!
   cancel( %this.fadeBlendAlphaEvent );
   %this.fadeBlendAlphaEvent = "";

   // Do one step of fade out.
   %alpha = %this.getBlendAlpha() + %step;
   %this.setBlendAlpha( %alpha );

   // Have we finished the fade?
   if (  ( %alpha <= 0 && %step < 0 ) ||
         ( %alpha >= 1 && %step > 0 ) )
      return;

   // Figure out how much to fade out per step.
   %steps = mAbs( 1 / %step );
   %this.fadeBlendAlphaEvent = %this.schedule( %ms / %steps, fadeBlendAlpha, %step, %ms );
}

function t2dSceneObject::castCollisionTo( %this, %pt )
{
   // Get the object position... take into account 
   // the collision centeroid.
   %pos = %this.getPosition(); 
         
   // Get the distance we need to travel 
   // and in what direction.
   %vec = t2dVectorSub( %pt, %pos );
   %dist = t2dVectorLength( %vec );
   %dir  = t2dVectorNormalise( %vec );

   // Set the velocity fast enough that we land
   // on our dest point in the simulation time. 
   %lastVel = %this.getLinearVelocity();
   %this.setLinearVelocity( t2dVectorScale( %dir, %dist ) );

   // Do the cast which simulates time moving ahead
   // to detect any collisions.
   %hits = %this.castCollision( 1 );

   // Restore the old velocity.
   %this.setLinearVelocity( %lastVel );

   return %hits;
}

function t2dSceneObject::canMoveTo( %this, %pt )
{
   %hits = %this.castCollisionTo( %pt );
   return %hits $= "";
}

function t2dSceneObject::canMoveToObject( %this, %object )
{
   // Ideally this would be an instantanious check,
   // but there is a bug in TGB 1.1.1 where if we
   // set the object here as immovable that collision
   // is sometimes not detected.  To fake it here we
   // put a really small velocity on it... which seems
   // to work out ok.
   %oldVel = %object.getLinearVelocity();
   %object.setLinearVelocity( "0.01 0.01" );

   // Test for collision.
   %pos = %object.getPosition(); 
   %hits = %this.castCollisionTo( %pos );
   
   // Restore the paused state.
   %object.setLinearVelocity( %oldVel );

   // Did we hit the object first?
   if ( getWord( %hits, 0 ) == %object )
      return true;

   return false;
}

function t2dSceneObjectGroup::setVisible( %this, %visible )
{
   %count = %this.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %child = %this.getObject( %i );
      %child.setVisible( %visible );
   }
}

function t2dSceneObject::getWorldValue( %this, %value )
{
   %center = %this.getWorldPoint( "0 0" );
   %value = %this.getWorldPoint( %value SPC 0 );
   return mAbs( getWord( %value, 0 ) - getWord( %center, 0 ) );
}

function t2dSceneObject::splashDamage( %this, %radius, %damage )
{
   %pos = %this.getPosition();
   %layer = %this.getLayer();
   %group = %this.getGroup();
   %sg = %this.getSceneGraph();
   
   // Collect all the objects within the radius.
   %objects = %sg.pickRadius( %pos, %radius );

   if ( %objects $= "" )
      return;

   %count = getWordCount( %objects );
   for ( %i=0; %i < %count; %i++ )
   {
      %object = getWord( %objects, %i );
      
      if ( %object == %this || %object.life <= 0 )
         continue;

      // Use the distance to the object to scale the damage.
      %dir = t2dVectorSub( %object.getPosition(), %pos );
      %dist = t2dVectorLength( %dir );
      if ( %dist > %radius )
         continue;

      %splashDamage = ( 1 - ( %dist / %radius ) ) * %damage;
      %object.schedule( 185, damage, %splashDamage, true );
      
      // Give the object an impulse.
      %impulse = t2dVectorScale( t2dVectorNormalise( %dir ), %splashDamage / 8 );
      %object.setImpulseForce( %impulse ); 
   }
}
