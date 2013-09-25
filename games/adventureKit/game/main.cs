//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------

// We use this to display a version in the GUI.
$adventureKitVersion = "1.2";


/// Perform game initialization here.
function initializeProject()
{
   // Load the shared config datablocks here.
   exec("~/gameScripts/datablocks.cs");

   // Load all the game scripts.
   exec( "~/gameScripts/game.cs" );
   execGameScripts();

   // This is the window title.  As of TGB 1.5.1 you may
   // may notice that your title bar starts as "UntitledGame"
   // for a breif period before these lines below are exec'd.
   // See common/commonConfig.xml to correct this.   
   $canvasTitle = "TGB Adventure Kit"; 
   SetCanvasTitle( $canvasTitle );
   
   // Launch the splash screen which in turn
   // loads the main menu.
   showSplashScreen();
}


/// This is called from MainMenuGui to start playing the game.
function newGame()
{
   // Cleanup any existing game.
   endGame();

   // We default to our startup level.
   %level = "~/data/levels/start.t2d"; 

   // As of TGB 1.5.1 there isn't a way to tell if your
   // launching from the level editor or not.  If you are
   // trying to test new levels uncomment this line...
   //
   // %level = $Game::DefaultScene;
   //
   // ... or use the following command in the console.
   //
   // loadLevel( levelname );
   //
   
   startGame( expandFilename( %level ) );
}


/// Clean up your game objects here.
function shutdownProject()
{
   endGame();
}


/// Bind keys to actions here..
function setupKeybinds()
{
   exec("./gameScripts/input.cs");
   setupInputs();
}
