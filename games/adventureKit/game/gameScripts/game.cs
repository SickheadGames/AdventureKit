//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


/// All game logic is set up here. This will be called by the 
/// level builder when you select "Run Game" or by the startup 
/// process of your game to load the first level.
function startGame( %levelFile )
{
   // Make sure we've exec'd the game scripts.
   execGameScripts();
   
   // Start the level load.
   if ( !loadLevel( %levelFile ) )
      return false;
}


/// Called by the game and the level builder tool
/// when stopping the game.
function endGame()
{
   if ( isObject( $camera ) )
      $camera.safeDelete();

   if ( isObject( $player ) )
      $player.safeDelete();

   if ( isObject( sceneWindow2D ) )
      sceneWindow2D.endLevel();
      
   moveMap.pop();
   
   // Stop All Sounds.	
   alxStopAll();   
}

/// By putting our game scripts here it's easy to reload
/// them as we need to.  Just be sure to use isObject to
/// check if the global exists before recreating it.  See
/// aiPlayer.cs for an example.
function execGameScripts()
{
   exec( "~/gui/splashScreen.gui" );
   exec( "~/gui/mainMenu.gui" );
   exec( "~/gui/loadingScreen.gui" );
   exec( "~/gui/playScreen.gui" );
   
   exec( "./t2dExt.cs" );   
   
   exec( "./commands.cs" );
   exec( "./level.cs" );
   exec( "./camera.cs" );

   exec( "./soundEmitter.cs" );

   exec( "./spawnPoint.cs" );
   exec( "./enemySpawn.cs" );

   exec( "./player.cs" );
   exec( "./round.cs" );
   exec( "./corpse.cs" );

   exec( "./aiPlayer.cs" );
   exec( "./aiGoals.cs" );
   exec( "./steering.cs" );

   exec( "./breakable.cs" );
   exec( "./gantlet.cs" );  
 
   exec( "./objectTrigger.cs" );
   exec( "./interiorTrigger.cs" );   
   exec( "./cameraTrigger.cs" );
   exec( "./levelTrigger.cs" );
}
