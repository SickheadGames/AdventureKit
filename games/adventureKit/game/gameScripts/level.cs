//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


/// Called from  a random level spawn point scene object.
function levelCreate( %levelFile )
{
   %level = sceneWindow2D.loadLevel( %levelFile );
        
   // Collect spawn points we find in the level.
   %spawnPoints = new SimSet();
   %count = %level.getSceneObjectCount();
   for ( %i=0; %i < %count; %i++ )
   {
      %object = %level.getSceneObject( %i );
      
      if ( %object.class $= "SpawnPoint" )
         %spawnPoints.add( %object );
   }
   %level.spawnPoints = %spawnPoints;

   return %level;
}

/// Returns a random spawn point scene object from a 
/// scene graph created by levelCreate().
function getRandomSpawnPoint( %level )
{
   t2dAssertISV( isObject( %level.spawnPoints ), 
      "This scene graph was not loaded with levelCreate!" );
                     
   %simSet = %level.spawnPoints;
   %count = %simSet.getCount();
   
   // If we don't have a spawn point then return a dummy.
   if ( %count == 0 )
   {
      %spawn = new t2dSceneObject() {
         class = "SpawnPoint";
         position = "0 0";
         size = "5 5";
         layer = "0";
      };
      %simSet.add( %spawn );
   }

   // Pick a random spawn point object.
   %i = getRandom( 0, %count - 1 );
   return %simSet.getObject( %i );
}
