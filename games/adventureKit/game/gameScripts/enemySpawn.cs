//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function EnemySpawn::onAdd( %this )
{ 
   %this.ourSpawn = new SimSet();

   // Schedule a check to see if we need more spawns!
   %this.schedule( 500, checkSpawn );
}

function EnemySpawn::onRemove( %this )
{
   if ( isObject( %this.ourSpawn ) )
      %this.ourSpawn.delete();   
}

function EnemySpawn::onLevelLoaded( %this, %sg )
{
   // Are we doing spawns on add?
   if ( !%this.spawnOnAdd )
      return;
      
   // When we spawn on level load we don't use effects
   // or any sort of delay... just make them appear.
   for ( %i = 0; %i < %this.spawnCount; %i++ )
      %this.createAndSpawn( true );
}

function EnemySpawn::createAndSpawn( %this, %noEffects )
{
   %pt = %this.getPosition();
   
   %spawnee = new t2dAnimatedSprite()
   {
      config = %this.spawnConfig;
      scenegraph = %this.getSceneGraph();
      position = %pt;
      visible = false;
   };
      
   // We store our spawn in a sim group, so that
   // we can tell when he's been killed and need
   // to spawn another.
   %this.ourSpawn.add( %spawnee );
   
   %this.spawn( %spawnee, %noEffects );
}

function EnemySpawn::checkSpawn( %this )
{
   // Do we need to spawn another?
   %count = %this.ourSpawn.getCount();
   if ( %count < %this.spawnCount )
      %this.schedule( %this.spawnNextMS, createAndSpawn );

   // We schedule the next check to happen after
   // the previous spawn schedule... this ensures 
   // we don't spawn more than spawnCount.
   %this.schedule( %this.spawnNextMS+1, checkSpawn );
}

