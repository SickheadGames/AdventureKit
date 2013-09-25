//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function toggleDebugBanner()
{
   toggleDebugState( 0 );
}

function toggleCollisionShapes()
{
   toggleDebugState( 5 );
}

function toggleBoundingBoxes()
{
   toggleDebugState( 1 );
}

function toggleDebugState( %state )
{
   if ( !isObject( $levelScene ) )
   {
      error( "No level loaded!" );
      return;
   }

   if ( $levelScene.getDebugOn( %state ) )
      $levelScene.setDebugOff( %state );       
   else
      $levelScene.setDebugOn( %state ); 
}

function loadLevel( %levelFile, %optionalSpawnPoint )
{
   if ( %levelFile $= "" )
   {
      error( "Need level file name!" );
      return;
   }

   // We must have an expanded filename without a 
   // tilda to pass to load level.
   %levelFile = expandFilename( %levelFile );

   // Make sure it exists.
   if ( !isFile( %levelFile ) )
   {
      // Does it need an extension?
      if ( strstr( %levelFile, ".t2d" ) == -1 )
         %levelFile = %levelFile @ ".t2d";

      if ( !isFile( %levelFile ) )
      {
         // Try adding the level path to it.
         %levelFile = expandFilename( "~/data/levels/" @ %levelFile );
         if ( !isFile( %levelFile ) )
         {
            error( "The level file could not be found!" );
            return;
         }
      }
   }
   
   // Store it here for reload later.
   $currentLevelFile = %levelFile;
   
   // Let the GUI do the work.
   LoadingScreenGui.loadLevel( %levelFile, %optionalSpawnPoint );
}

function reloadLevel()
{
   if ( $currentLevelFile $= "" )
   {
      error( "No reload file name found!" );
      return;
   }

   loadLevel( $currentLevelFile );
}

function pauseGame( %pause, %noGui )
{
   if ( !isObject( $levelScene ) )
   {
      error( "No level loaded!" );
      return;
   }

   if ( %pause )
   {
      $gamePaused = true;

      if ( !%noGui )
      {
         PauseTextGui.setVisible( true );
         SetCanvasTitle( $canvasTitle SPC " - Paused" );
      }
         
      $levelScene.setScenePause( true );
      setSoundEmittersPaused( true );
   }
   else
   {
      $gamePaused = false;
      
      PauseTextGui.setVisible( false );
      SetCanvasTitle( $canvasTitle );

      $levelScene.setScenePause( false );
      setSoundEmittersPaused( false );
   }
}

function respawn( %optionalSpawnPoint )
{
   if ( !isObject( $levelScene ) )
   {
      error( "No level loaded!" );
      return;
   }

   // Kill the player!
   if ( isObject( $player ) )
      $player.kill( true );

   // Then do the spawn.
   $player = playerCreate( $levelScene, false );
   if ( !isObject( %optionalSpawnPoint ) )
      %optionalSpawnPoint = getRandomSpawnPoint( $levelScene );
   %optionalSpawnPoint.spawn( $player );
}

function suicide()
{
   if ( !isObject( $player ) )
   {
      error( "No player loaded!" );
      return;
   }

   // Kill the player!
   $player.kill( true );
   $player = 0;
}

function god()
{
   if ( !isObject( $player ) )
   {
      error( "No player loaded!" );
      return;
   }

   $player.god = !$player.god;
   
   if ( $player.god )
      echo( "You feel invincible!" );
   else
      echo( "You feel mortal!" );
}

function ghost()
{
   if ( !isObject( $player ) )
   {
      error( "No player loaded!" );
      return;
   }

   $player.setCollisionActiveReceive( !$player.getCollisionActiveReceive() );
   $player.setCollisionActiveSend( !$player.getCollisionActiveSend() );

   if ( !$player.getCollisionActiveReceive() )
   {
      echo( "You feel ethereal!" );
      $player.setBlendAlpha( 0.4 );
   }
   else
   {
      echo( "You feel earthly!" );
      $player.setBlendAlpha( 1 );
   }
}

function deathToKorks()
{
   %count = $aiPlayers.getCount();
   for ( ; %count > 0; %count-- )
   {
      %kork = $aiPlayers.getObject( 0 );
      %kork.kill();
   }
}

function letThereBeNight()
{
   if ( !isObject( $levelScene ) )
   {
      error( "No level loaded!" );
      return;
   }
   
   // Ok... so we experimented here with setting
   // the gamma down to get more contrast and make
   // the darkeness more night like.  The problem
   // is that gamma is a system wide setting and
   // it will effect other windows.
   //videoSetGammaCorrection( 0 );
   
   %color = 150 / 256 SPC 175 / 256 SPC 200 / 256;
   
   %count = $levelScene.getSceneObjectCount();
   for ( %i=0; %i < %count; %i++ )
   {
      %object = $levelScene.getSceneObject( %i );
      %object.setBlendColor( %color );
   }
}

function letThereBeLight()
{
   if ( !isObject( $levelScene ) )
   {
      error( "No level loaded!" );
      return;
   }
   
   // Ok... so we experimented here with setting
   // the gamma down to get more contrast and make
   // the darkeness more night like.  The problem
   // is that gamma is a system wide setting and
   // it will effect other windows.
   //videoSetGammaCorrection( $pref::OpenGL::gammaCorrection );
   
   %color = "1 1 1";
   
   %count = $levelScene.getSceneObjectCount();
   for ( %i=0; %i < %count; %i++ )
   {
      %object = $levelScene.getSceneObject( %i );
      %object.setBlendColor( %color );
   }
}
  
function letThereBeSunset()
{
   if ( !isObject( $levelScene ) )
   {
      error( "No level loaded!" );
      return;
   }
     
   %color = 255 / 256 SPC 220 / 256 SPC 185 / 256;
   
   %count = $levelScene.getSceneObjectCount();
   for ( %i=0; %i < %count; %i++ )
   {
      %object = $levelScene.getSceneObject( %i );
      %object.setBlendColor( %color );
   }
}

function superSizeMe()
{
   if ( !isObject( $player ) )
   {
      error( "No player loaded!" );
      return;
   }

   %size = $player.getConfigDatablock().size;
   %curr = $player.getSize();
   if ( t2dVectorCompare( %size, %curr, 0.01 ) )
   {
      echo( "You feel mastodonic!" );
      %size = t2dVectorScale( %size, 2 );
   }
   else
      echo( "You feel rather normal!" );

   $player.setSize( %size );
}

function miniMe()
{
   if ( !isObject( $player ) )
   {
      error( "No player loaded!" );
      return;
   }

   %size = $player.getConfigDatablock().size;
   %curr = $player.getSize();
   if ( t2dVectorCompare( %size, %curr, 0.01 ) )
   {
      echo( "You feel minuscule!" );
      %size = t2dVectorScale( %size, 0.4 );
   }
   else
      echo( "You feel rather normal!" );

   $player.setSize( %size );
}
