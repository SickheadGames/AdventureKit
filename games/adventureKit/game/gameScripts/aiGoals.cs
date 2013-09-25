//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function AiGoal::onAdd( %this )
{
   %this.subgoals = new SimGroup();
}

function AiGoal::onRemove( %this )
{
   %this.subgoals.delete();
}

function AiGoal::addSubgoal( %this, %goal )
{
   %this.subgoals.add( %goal );
   %this.subgoals.bringToFront( %goal );
}

function AiGoal::removeAllSubgoals( %this )
{
   %this.subgoals.delete();
   %this.subgoals = new SimGroup();
}

function AiGoal::getGoal( %this )
{
   %goals = %this.subgoals;
   if ( %goals.getCount() < 1 )
      return 0;
      
   return %goals.getObject( 0 );   
}

function AiGoal::processSubgoals( %this )
{
   // If we have no subgoals we have 
   // no processing to do!
   %goals = %this.subgoals;
   if ( %goals.getCount() == 0 )
      return false;

   // Process the next goal... it will return
   // either a new goal or true if complete or
   // return false if it's not done processing.
   %goal = %goals.getObject( 0 );
   %newGoalOrComplete = %goal.process();
   if ( %newGoalOrComplete )
   {
      %goals.remove( %goal );
      %goal.delete();

      if ( isObject( %newGoalOrComplete ) )
         %this.addSubgoal( %newGoalOrComplete );
   }
   
   // Return true if we have more 
   // goals to process!
   return %goals.getCount() > 0;     
}


function newAiGoalThink( %agent )
{
   return new ScriptObject()
   {
      class = AiGoalThink;
      superClass = AiGoal;
      agent = %agent;
   };
}

function AiGoalThink::onAdd( %this )
{
   Parent::onAdd( %this );

   // Store the current agent position.
   %this.startPos = %this.agent.getPosition();
   
   // Start the think updates.
   %this.schedule( 1, process );
}

function AiGoalThink::onDamage( %this, %enemy )
{
   // Get the current goal. 
   %goal = %this.getGoal();
   
   // If we're not currently attacking 
   // then start attacking!
   if ( !%goal || %goal.class !$= "AiGoalAttack" && isObject( %enemy ) )
   {
      %this.removeAllSubgoals();
      %this.addSubgoal( newAiGoalAttack( %this.agent, %enemy ) );               
   }
}

function AiGoalThink::process( %this )
{
   // Process the subgoals.
   %this.processSubgoals();
   
   // Get the current goal.
   %goal = %this.getGoal(); 
   %agent = %this.agent;
   
   // If we're not currently attacking then check to
   // see if we should start.
   if ( !%goal || %goal.class !$= "AiGoalAttack" )
   {
      %enemy = %agent.getVisibleEnemy();
      if ( isObject( %enemy ) )
      {
         %this.removeAllSubgoals();
         %goal = newAiGoalAttack( %agent, %enemy );
         %this.addSubgoal( %goal );
      }
   }
   
   // If we still don't have a goal and we have a patrol
   // range then go patrol... else sit still.
   if ( !%goal && %agent.patrolRange > 0 )
      %this.addSubgoal( newAiGoalPatrol( %agent, %this.startPos, %agent.patrolRange ) );

   // To reduce CPU load with AI checks we scale down 
   // updates by the distance to the camera.
   %ms = %agent.thinkRate ? %agent.thinkRate : 250;
   if ( isObject( $camera ) )
   {
      %camDist = t2dVectorDistance( $camera.getPosition(), %agent.getPosition() );
      %radius = %camDist / $camera.getRadius();
      if ( %radius > 1 )
         %ms *= %radius;
   }

   // Think never completes.
   %this.schedule( %ms, process );
   return false;
}


function newAiGoalPatrol( %agent, %patrolPt, %patrolRange )
{
   //echo( "AiGoalPatrol " @ %patrolPt );
   
   return new ScriptObject()
   {
      class = AiGoalPatrol;
      superClass = AiGoal;
      agent = %agent;
      pt = %patrolPt;
      range = %patrolRange;
   };
}

function AiGoalPatrol::onAdd( %this )
{
   Parent::onAdd( %this );
   %this.agent.steering.clear();
}

function AiGoalPatrol::getNewPoint( %this )
{
   %agent = %this.agent;

   // What point do we partol from?  If we're farther
   // away from our patrol point then our range then
   // patrol from our current position towards our
   // patrol point.
   %pos = %agent.getPosition();
   %dist = t2dVectorDistance( %pos, %this.pt );
   if ( %dist < %this.range )
      %patrolPt = %this.pt;
   else
      %patrolPt = %pos;

   // We pick a position to move to by picking
   // a random point within a circle from the
   // starting patrol point.
   %vec =   getRandom( -%this.range, %this.range ) SPC 
            getRandom( -%this.range, %this.range );
   %pt = t2dVectorAdd( %patrolPt, %vec );
   
   // Make sure we've got a clear line of movement to it.
   if ( !%agent.canMoveTo( %pt ) )
   {
      // This random position has us colliding with something
      // so try another random point on the next update.
      return "";
   }

   return %pt;
}

function AiGoalPatrol::process( %this )
{  
   // If we don't have any subgoals then 
   // pick a new partol point.
   if ( !%this.processSubgoals() )
   {
      %pt = %this.getNewPoint();
      if ( %pt !$= "" )
      {
         // We want to wait at the point for a few
         // seconds before we make the next move.
         %this.addSubgoal( newAiGoalWait( %this.agent, 2200 + ( getRandom() * 10000 ) ) );
         %this.addSubgoal( newAiGoalMoveToPt( %this.agent, %pt ) );
      }
   }
   
   // Note... patrol never ends.  It is only forcefully
   // removed by the parent think goal!
   return false;
}


function newAiGoalWait( %agent, %ms )
{
   //echo( "AiGoalWait " @ %ms );
   
   %wait = new ScriptObject()
   {
      class = AiGoalWait;
      superclass = AiGoal;
   };
   
   // Just delete the goal when it's over.
   %wait.schedule( %ms, delete ); 

   return %wait;
}

function AiGoalWait::process( %this )
{
   return false;
}


function newAiGoalMoveToPt( %agent, %pt, %dir )
{
   //echo( "AiGoalMoveToPt " @ %pt );
   
   return new ScriptObject()
   {
      class = AiGoalMoveToPt;
      superClass = AiGoal;
      agent = %agent;
      pt = %pt;
      dir = %dir;
   };
}

function AiGoalMoveToPt::onAdd( %this )
{
   Parent::onAdd( %this );
   
   // Lets make with the moving!
   %steering = %this.agent.steering;
   %steering.clear();
   %steering.setArrive( 1, %this.pt );

   // Delete this goal a little after we "should" have
   // gotten there.  If it fires we must have gotten 
   // blocked and need to end the move.
   %this.schedule( %steering.getArrivalMS() + 1000, delete );
}

function AiGoalMoveToPt::process( %this )
{
   // Have we gotten close enought to the target?
   %agent = %this.agent;
   %dist = t2dVectorDistance( %agent.getPosition(), %this.pt );
   if ( %dist < 0.5 )
   {
      // If we have a direction to look at
      // then look that way now.
      if ( %this.dir !$= "" )
         %agent.lookAt( %this.dir );
      %agent.steering.clear();
      return true;
   }
   
   return false;
}


function newAiGoalAttack( %agent, %enemy )
{
   //echo( "AiGoalAttack " @ %enemy.getPosition() );
   
   return new ScriptObject()
   {
      class = AiGoalAttack;
      superClass = AiGoal;
      agent = %agent;
      enemy = %enemy;
      lastEnemyPos = %enemy.getPosition();
      lastEnemyVel = %enemy.getLinearVelocity();
      hunting = false;
   };
}

function AiGoalAttack::process( %this )
{
   // Process the subgoals.
   %this.processSubgoals();

   // If the enemy is dead we're done!
   %enemy = %this.enemy;
   if ( !isObject( %enemy ) )
   {
      //echo( "AiGoalAttack killed enemy!" );      
      return true;
   }
   
   // Did we loose the enemy?
   %agent = %this.agent;
   if ( %agent.getVisibleEnemy() != %enemy )
   {  
      //echo( "AiGoalAttack enemy lost!" );
      
      // By returning a new goal we'll be removed
      // and it will be added.
      return newAiGoalMoveToPt( %this.agent, %this.lastEnemyPos, t2dVectorNormalise( %this.lastEnemyVel ) );
   }
   
   // Keep track of the last sighting so we can hunt him later.
   %this.lastEnemyPos = %enemy.getWorldPoint( %enemy.getSortPoint() ); 
   %this.lastEnemyVel = %enemy.getLinearVelocity();
   
   %steering = %agent.steering;

   // Are we close enought to him?
   %pos = %agent.getWorldPoint( %agent.getSortPoint() );
   %vec = t2dVectorSub( %this.lastEnemyPos, %pos );
   %dist = t2dVectorLength( %vec );
   if ( %dist < %agent.attackDist )
   {
      //echo( "AiGoalAttack close enough!" );
      %steering.clear();
   }

   // Keep seeking him!
   else if ( %steering.target != %enemy )
   {
      //echo( "AiGoalAttack get closer!" );
      %steering.setArrive( 1, %enemy );
   }

   // Aim and fire.
   %agent.fire( %vec );
   
   return false;
}

