//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function newSteering( %agent, %maxSpeed )
{
   %maxSpeed = %maxSpeed $= "" ? 1 : %maxSpeed;

   %steer = new ScriptObject()
   {
      class = Steering;

      agent = %agent;
         
      maxSpeed = %maxSpeed;
      
      force = "0 0";
      averageForce = "0 0";
      
      target = 0;
      targetPos = "";

      arriveWeight      = 0;
      separationWeight  = 2;
   };

   return %steer;
}

function Steering::clear( %this )
{
   %this.target = 0;
   %this.targetPos = "";
   %this.arriveWeight = 0;
   %this.force = "0 0";
   %this.averageForce = "0 0";
}

function Steering::clearTarget( %this )
{
   %this.target = 0;
   %this.targetPos = "";
}

function Steering::setTarget( %this, %objectOrPoint )
{
   if ( getWordCount( %objectOrPoint ) == 1 && isObject( %objectOrPoint ) )
      %this.target = %objectOrPoint;
   else
      %this.targetPos = %objectOrPoint;
}

function Steering::setArrive( %this, %weight, %objectOrPoint )
{
   %this.arriveWeight = %weight;
   
   if ( %objectOrPoint $= "" )
      %this.clearTarget();
   else
      %this.setTarget( %objectOrPoint );
}

function Steering::getArrivalMS( %this )
{
   if ( %this.arriveWeight <= 0 )
      return 0;

   // Just a simple distance over speed.
   %dist = t2dVectorDistance( %this.targetPos, %this.agent.getPosition() );
   return  ( %dist / %this.maxSpeed ) * 1000;
}

function Steering::calculate( %this )
{
   %this.force = "0 0";
   
   // Update the target if we have one.
   if ( isObject( %this.target ) )
      %this.targetPos = %this.target.getPosition();
  
   if ( %this.separationWeight > 0 )
   {
      %force = t2dVectorScale( %this.calcSeparation(), %this.separationWeight );
      %this.force = t2dVectorAdd( %this.force, %force );

      if ( t2dVectorLength( %force ) > 1 )
         return %this.normalizeAndSmooth();
   }
  
   if ( %this.arriveWeight > 0 )
   {
      %force = t2dVectorScale( %this.calcArrive(), %this.arriveWeight );
      %this.force = t2dVectorAdd( %this.force, %force );
      
      if ( t2dVectorLength( %force ) > 1 )
         return %this.normalizeAndSmooth();
   }

   %len = t2dVectorLength( %this.force );
   if ( %len > 1 )
      return %this.normalizeAndSmooth();
   else if ( %len == 0 )
      %this.averageForce = "0 0";      

   return %this.force;
}

function Steering::normalizeAndSmooth( %this )
{
   // Do a simple average.
   %force = t2dVectorAdd( %this.averageForce, %this.force );
   %this.averageForce = t2dVectorScale( %force, 0.5 );

   // Normalize it.
   %force = t2dVectorNormalise( %this.averageForce );
   %this.force = %force;
   return %force;
}

function Steering::calcSeparation( %this )
{
   // Gather all the neighbors.
   %agent = %this.agent;
   %sg = %agent.getSceneGraph();
   %group = %agent.getGraphGroup();
   %pos = %agent.getPosition();
   
   %force = "0 0";
   
   // Collect all the objects within the radius.
   %others = %sg.pickRadius( %pos, 5, BIT( %group ) );
   if ( %others $= "" )
      return %force;
   
   %count = getWordCount( %others );
   for ( %i=0; %i < %count; %i++ )
   {
      %other = getWord( %others, %i );
      
      if ( %other == %agent )
         continue;

      %toAgent = t2dVectorSub( %pos, %other.getPosition() );

      %sepForce = t2dVectorScale( t2dVectorNormalise( %toAgent ), 
                                 1 / t2dVectorLength( %toAgent ) );
      %force = t2dVectorAdd( %force, %sepForce );
   }
   
   return %force;
}

function Steering::calcArrive( %this )
{
   %agent = %this.agent;

   %vec = t2dVectorSub( %this.targetPos, %agent.getPosition() );
   %dist = t2dVectorLength( %vec );
   %dir = t2dVectorNormalise( %vec );
   %scale = %dist / ( %this.maxSpeed / 6 ); // hacky number!
   if ( %scale < 0.01 )
      %scale = 0;
   %dir = t2dVectorScale( %dir, %scale );
   return %dir;
}
