//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


/// This is a handy function which filters an analog
/// input value, clipping it if it's below the deadzone
/// and applying a power to it, and then returns it.
function inputFilterAxis( %value, %deadzone, %pow )
{
   // Check to see if we're trapped in the deadzone!
   if (  %value <= %deadzone &&
         %value >= -%deadzone )
      return 0;

   else
   {
      // Scale the value to get it back into the -1 / +1 range.
      %range = 1 - %deadzone;
      if ( %value > 0 )
         %value = ( %value - %deadzone ) / %range;     
      else
         %value = ( %value + %deadzone ) / %range;
   }
   
   // Now apply a power to it to make it feel a little nicer.
   %sign = %value < 0 ? -1 : 1;
   %value = %sign * mPow( mAbs( %value ), %pow );

   return %value;
}

function moveX( %value )
{
   $moveX = inputFilterAxis(  %value, 
                              $pref::Input::JoystickDeadzone, 
                              $pref::Input::JoystickPow );
}

function moveY( %value )
{
   $moveY = inputFilterAxis(  %value, 
                              $pref::Input::JoystickDeadzone, 
                              $pref::Input::JoystickPow );
}

function moveLeft( %val )
{
   $moveX = -%val;
}

function moveRight( %val )
{
   $moveX = %val;
}

function moveUp( %val )
{
   $moveY = -%val;
}

function moveDown( %val )
{
   $moveY = %val;
}

function jump( %val )
{
   $jump = %val;
}

function shoot( %val )
{
   $shoot = %val;
}

function strafe( %val )
{
   %val = inputFilterAxis( %val, $pref::Input::JoystickDeadzone, 1 );
   if ( %val < 0 || %val > 0 )
      $strafe = true;
   else
      $strafe = false;
}

// This is a wrapper around the basic move
// functions to trick the action map into 
// allowing more than one key to bind to the
// same function.
function moveUp2( %val ) { moveUp( %val ); }
function moveDown2( %val ) { moveDown( %val ); }
function moveLeft2( %val ) { moveLeft( %val ); }
function moveRight2( %val ) { moveRight( %val ); }
function jump2( %val ) { jump( %val ); }
function shoot2( %val ) { shoot( %val ); }
function strafe2( %val ) { strafe( %val ); }


function setupInputs()
{
   // This enables joystick inputs.  To do that
   // DirectInput has to be enabled first.
   $enableDirectInput = "1";
   activateDirectInput();
   enableJoystick();

   // Setup some globals.
   $pref::Input::JoystickDeadzone = 0.26;
   $pref::Input::JoystickPow = 1; //2.71828;   
   $moveX = 0;
   $moveY = 0;
   $strafe = false;
   $jump = false;
   $shoot = false;

   if ( isObject( moveMap ) )
      moveMap.delete();
   new ActionMap(moveMap);

   // Setup the keybinding package which sniffs our
   // bindings to display them to the options dialog.
   activatePackage(KeybindPackage);

   // These are the "bindings" which will call the specified
   // script functions (they're up above this) when an input
   // event is recieved from one of the input devices. 
   moveMap.bind( keyboard, up, "moveUp" );
   moveMap.bind( keyboard, down, "moveDown" );
   moveMap.bind( keyboard, left, "moveLeft" );
   moveMap.bind( keyboard, right, "moveRight" );
   
   // This is a trick.  By default TAP does not allow multiple
   // input events to be bound to the same script function.  To
   // work around this and allow the arrows or the WSAD keys to
   // control the player, we create a second set of functions
   // which just call the first set.
   moveMap.bind( keyboard, "w", "moveUp2" );
   moveMap.bind( keyboard, "s", "moveDown2" );
   moveMap.bind( keyboard, "a", "moveLeft2" );
   moveMap.bind( keyboard, "d", "moveRight2" );

   // These bindings are for the first connected joystick (this
   // includes gamepads like the Xbox and Xbox 360 usb controllers)
   // to control the player.  Notice that the moveX() and moveY()
   // functions control left/right and up/down unlike how the
   // keyboard bindings above work.
   moveMap.bind( joystick, xaxis, "moveX" );
   moveMap.bind( joystick, yaxis, "moveY" );

   // Interesting fact... Kork is an avid jumper!  Aside from 
   // crushing his foes, it's his second favoriate pastime.  So
   // lets add some control for jumping!  
   moveMap.bind( keyboard, "space", "jump" );
   moveMap.bind( joystick, "button1", "jump2" );

   // When Kork crushes his foes he does it with his trusty
   // crossbow.  What's a game without shooting? 
   moveMap.bind( keyboard, "enter", "shoot" );
   moveMap.bind( joystick, "button0", "shoot2" );

   // You can't effectively battle if you can't 
   // sidestep your enemies attacks.
   moveMap.bind( keyboard, "apostrophe", "strafe" );
   moveMap.bind( joystick, zaxis, "strafe2" );
   
   // These are some miscellaneous features.
   moveMap.bindCmd( keyboard, "p" ,       "pauseGame( !$gamePaused );", "" );
   moveMap.bindCmd( keyboard, "pause" ,   "pauseGame( !$gamePaused );", "" );
   moveMap.bindCmd( keyboard, "escape" ,  "Canvas.pushDialog( MainMenuGui );", "" );
   
   // Make sure you deactivate it.
   deactivatePackage(KeybindPackage);   
}
