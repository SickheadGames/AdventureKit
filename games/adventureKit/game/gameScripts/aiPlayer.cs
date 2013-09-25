//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


// All the AIs in the system are registered into this
// global SimSet.  Notice we use isObject() so that we
// don't recreate the gloabl if it already exists.  This
// allows us to reload scripts whenever we like.
if ( !isObject( $aiPlayers ) )
   $aiPlayers = new SimSet();


function AiPlayer::onAdd( %this )
{
   Parent::onAdd( %this );
   
   // Ai players are not controllable.
   %this.isControlled = false;
   
   // Keep these guys in a set so we can
   // do some group operations on them.
   $aiPlayers.add( %this );

   // Create a steering object.
   %this.steering = newSteering( %this, %this.runSpeed );

   // Make sure we get updates!
   %this.schedule( 100, onUpdate );
}

function AiPlayer::onRemove( %this )
{
   Parent::onRemove( %this );
  
   if ( isObject( %this.thinkGoal ) )
      %this.thinkGoal.delete();

   if ( isObject( %this.steering ) )
      %this.steering.delete();      
}

function AiPlayer::getMove( %this )
{
   // Get the latest steering move.
   %move = %this.steering.calculate();
   if ( t2dVectorLength( %move ) > 1 )
      %move = t2dVectorNormalise( %move );

   // Add a null jump and fire for now.
   %move = %move SPC 0 SPC 0;

   return %move;
}

function AiPlayer::damage( %this, %damage, %splash, %enemy )
{
   // Let the brain know we've been damaged.
   if ( isObject( %this.thinkGoal ) )
      %this.thinkGoal.onDamage( %enemy );
      
   Parent::damage( %this, %damage, %splash );
}

function AiPlayer::getVisibleEnemy( %this )
{
   // This could be expanded to really do pick radius
   // on the player group and pick the closest player,
   // but checking the gloabal works well enough.
   if ( !isObject( $player ) || !$player.getVisible() )
      return 0;
   
   // First make sure we're within visible range.
   %pos = %this.getPosition();
   %pt = $player.getPosition();
   %dist = t2dVectorDistance( %pt, %pos );
   if ( %dist > %this.lookDist )
      return 0;

   // If we are in the ai fov or really really 
   // close then we can see him.
   %vec = t2dVectorSub( %pt, %pos );
   %dir = t2dVectorNormalise( %vec );
   %dot = t2dVectorDot( %this.direction, %dir );
   if (  %dot < mCos( %this.lookFov ) &&
         %dist > %this.sneakDist )
      return 0;

   // Now check to see if we can see the player by
   // checking to see if we can move to the player
   // without hitting anything else.
   if ( %this.canMoveToObject( $player ) )
      return $player;
      
   return 0;
}

function AiPlayer::onUpdate( %this )
{
   // Make sure this boy has his head screwed on!
   if ( !isObject( %this.thinkGoal ) )
      %this.thinkGoal = newAiGoalThink( %this );
   
   Parent::onUpdate( %this );
   
   // Make sure we get another update!
   %this.schedule( 100, onUpdate );      
}

