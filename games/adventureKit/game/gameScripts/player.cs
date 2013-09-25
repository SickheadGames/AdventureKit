//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function playerCreate( %sg, %visible )
{
   if ( %visible $= "" )
      %visible = true;
      
   %player = new t2dAnimatedSprite()
   {
      config = PlayerConfig;
      scenegraph = %sg;
      visible = %visible;
      
      // Make sure the player is always created way 
      // offscreen so that it doesn't inadvertently
      // appear within a critical trigger.
      position = "-10000 -10000";
   };
   
   // Enable tick updates.
   %player.enableUpdateCallback();
   
   return %player;
}

function Player::onAdd( %this )
{
   %this.isJumping = false;
   %this.isControlled = true;
   
   // By scheduling this call with a short delay
   // we can fake a post onAdd callback to init
   // stuff after we're in the scenegraph.
   %this.schedule( 1, onAdded );
}

function Player::onAdded( %this )
{
   // Here the scene graph is valid... unlike in onAdd!
   %sg = %this.getSceneGraph();
      
   if ( isObject( %this.breathAudio ) )
      %this.breathEmitter = createSoundEmitter( %sg, %this, %this.breathAudio );
   if ( isObject( %this.runAudio ) )
      %this.huffEmitter = createSoundEmitter( %sg, %this, %this.runAudio );
}

function Player::onRemove( %this )
{
   if ( isObject( %this.breathEmitter ) )
      %this.breathEmitter.delete();
      
   if ( isObject( %this.huffEmitter ) )
      %this.huffEmitter.delete();
      
   if ( isObject( %this.jumpPath ) )
   {
      %this.jumpPath.detachObject( %this );
      %this.jumpPath.safeDelete();      
   }
}

/// This is called from SpawnPoint when the player
/// should appear in the scene.
function Player::onSpawn( %this, %pos )
{  
   // Setup our spawn postion.
   %this.setPosition( %pos );

   // We now get the camera focus if we're
   // under player control.
   if ( %this.isControlled )
      $camera.setTarget( %this, true );

   // Turn ourselves on!   
   %this.setVisible( true );
}

function Player::kill( %this, %noRespawn )
{
   // Replace us with the stunt corpse!
   newCorpse( %this );

   if ( %this.isControlled )
      EffectWindow.onPlayerPain( 1 );
      
   // Delete ourselves!   
   %this.setVisible( false );
   %this.safeDelete();
   
   // If we're a controlled and we're allowed
   // to, then do an automatic respawn after
   // a few seconds.
   if ( %this.isControlled && !%noRespawn )
      schedule( 5000, 0, respawn );
}

function Player::damage( %this, %damage, %splash )
{
   // If we're already dead... we can't be damaged.
   if ( %this.life <= 0 )
      return;
 
   // Remove some life...
   if ( !%this.god )
      %this.life -= %damage;
   
   // Play some damage effects... for a controlled
   // player we do some full screen effects.
   if ( isObject( %this.painAudio ) )
      createSoundEmitter( %this.getSceneGraph(), %this, %this.painAudio, true );
   if ( %this.isControlled )
      EffectWindow.onPlayerPain( %damage / 100 );

   // If we still have life we have nothing to do.
   if ( %this.life > 0 )
      return;
      
   // We're dead...
   %this.kill();
}

function Player::lookAt( %this, %objectOrNormal )
{
   if ( getWordCount( %objectOrNormal ) > 0 )
      %this.direction = t2dVectorNormalise( %objectOrNormal );      

   else if ( isObject( %objectOrNormal ) )
   {
      %dir = t2dVectorSub( %this.getPositon(), %objectOrNormal.getPosition() );
      %this.direction = t2dVectorNormalise( %dir );
   }
}

function Player::fire( %this, %dir )
{
   // If we got a direction then turn
   // the player to face it first.
   if ( %dir !$= "" )
      %this.lookAt( %dir );

   // Can we fire the projectile?
   %time = getSimTime();
   if ( %time < %this.nextFire )
      return;

   // Fire the projectile!
   fireRound(  %this.ammoConfig, 
               %this, 
               %this.direction, 
               %this.fireOffset, 
               %this.fireHeight );

   %this.nextFire = %time + ( 1000 / %this.fireRate );
}

function Player::getMove( %this )
{
   // Capture the move data.
   %move = $moveX SPC $moveY SPC $jump SPC $shoot SPC $strafe;

   // Clear the jump state... make them press 
   // the button again to jump.
   $jump = false;
   
   // Do the same for the shoot state, but if one
   // would like auto fire this is the line to remove.
   $shoot = false;
   
   return %move;
}

function Player::onUpdate( %this )
{
   %sg = %this.getSceneGraph();
   if ( ( !%sg || %sg.getScenePause() ) ||
         !%this.getVisible() ||
         %this.getPaused() )
      return;

   %move = %this.getMove();

   %traj = getWords( %move, 0, 1 );  
   if ( t2dVectorLength( %traj ) > 1 )
      %traj = t2dVectorNormalise( %traj );
   %vel = t2dVectorScale( %traj, %this.runSpeed );
   %speed = t2dVectorLength( %vel );
   
   // If we're moving then allow strafing.
   if ( %speed > 0 )
      %strafe = getWords( %move, 4 );
           
   if ( %speed < 0.01 )
      %vel = "0 0";
   else if ( !%strafe )
   {
      // We store the last velocity here as the last 
      // facing direction, so we can play the right
      // directional animations when not moving.
      //
      // Since we don't update the direction when
      // strafing the last direction animation is
      // played... making it strafe.
      %this.direction = t2dVectorNormalise( %vel );      
   }

   // Are we starting a jump?
   if ( getWords( %move, 2 ) && !%this.isJumping )
   {
      %this.setLinearVelocity( "0 0" );
      
      // Pick the right animation to play and play it.
      %anim = getNearestDirAnim( %this.direction, %this.jumpAnimsSet );
      %anim.animationTime = 0.5;
      %this.setAnimation( %anim );
      
      %this.setFrameChangeCallback( true );
      
      // We now turn on gravity and give the player
      // a little impuse boost.  This gives the jump
      // it's arc.
      //%this.setConstantForce( 0, 58.5, true );
      //%this.setImpulseForce( 0, -$jumpForce, false );
      //%this.setConstantForce( 0, $jumpForce * $jumpGravityScale, false );

      // Set the jump state for checking later.
      %this.isJumping = true;     
   }
   else if ( !%this.isJumping )
   {
      %this.setLinearVelocity( %vel );
      %this.lastVel = %vel;
   }
   
   // Did we fire?
   if ( getWords( %move, 3 ) )
      %this.fire();
          
   %this.updateAnimation();
   %this.updateSounds();
}


function Player::updateAnimation( %this )
{
   // If we're in the middle of a jump... there
   // is no need to go any further.
   if ( %this.isJumping )
      return;

   %vel = %this.getLinearVelocity();
   %dir = %this.direction;
   %len = t2dVectorLength( %vel );

   // If we're not moving then set the idle animation.
   if ( %len <= 0 )
   {
      %anim = getNearestDirAnim( %dir, %this.idleAnimsSet );
      if ( %this.getAnimation() != %anim )
         %this.setAnimation( %anim );

      return;
   }

   // We're running... look for the run state with the
   // closest direction vector and make sure we're in it.
   %anim = getNearestDirAnim( %dir, %this.runAnimsSet );
   if ( %this.getAnimation() != %anim )
      %this.setAnimation( %anim );

   /*
   // Now adjust the animation speed for the
   // current run animation by velocity.
   %animation = %newState.animation;
   %len /= $player.runSpeed;
   %time = ( ( 1 - %len ) * 1 ) + 0.75;
   %animation.animationTime = %time;
   %frame = %this.getAnimationFrame();
   %this.playAnimation( %animation, false, %frame );
   */
}

function Player::updateSounds( %this )
{
   // If we're in the middle of a jump... there
   // is no need to go any further.
   if ( %this.isJumping )
      return;
      
   %sg = %this.getSceneGraph();
   %idleEmitter   = %this.breathEmitter;
   %runEmitter    = %this.huffEmitter;
   
   %vel = %this.getLinearVelocity();
   %len = t2dVectorLength( %vel );

   // If we're not moving then set the breathing sound.
   if ( %len <= 0 )
   {
      if ( isObject( %runEmitter ) )
         %runEmitter.stop();

      if ( isObject( %idleEmitter ) && %idleEmitter.isStopped() )
         %idleEmitter.play();
         
      return;
   }
   
   if ( isObject( %idleEmitter ) )
      %idleEmitter.stop();
   if ( isObject( %runEmitter ) )
      %runEmitter.play();
}


function Player::onFrameChange( %this, %frameIndex )
{
   // Look for frame three of the jump.
   if ( !%this.isJumping || %frameIndex != 2 )
      return;   
   
   // Stop the other sounds.
   if ( isObject( %this.huffEmitter ) )
      %this.huffEmitter.stop();
   if ( isObject( %this.breathEmitter ) )
      %this.breathEmitter.stop();
   
   // Play the jump sound!
   if ( isObject( %this.jumpAudio ) )
      createSoundEmitter( %this.getSceneGraph(), %this, %this.jumpAudio, true );
   
   //%this.setCollisionActive( false, false );
   
   %this.jumpStartTime = getRealTime();
   %this.jumpStartPos = %this.getPosition();
   
   // This is the frame when we push off, to
   // get the arc of travel we want we create
   // a t2dPath.
   %jumpPath = buildJumpPath( %this.getPosition(), %this.direction, t2dVectorLength( %this.lastVel ) );
   %jumpPath.attachObject( %this, PlayerConfig.jumpSpeed );
   %jumpPath.setOrient( %this, false );
   %this.jumpPath = %jumpPath;

   // We restart the jump animation from the push off
   // frame, but this time scale the playback by the
   // time it will take for the jump.
   %animation = %this.getAnimation();
   %frames = 8; // %animation.animationFrames;
   %framePercentLeft = %frames / ( %frames - 2 );
   %animation.animationTime = ( %jumpPath.length / PlayerConfig.jumpSpeed ) * %framePercentLeft;
   %this.playAnimation( %animation, false, 2 );
   
   %this.setFrameChangeCallback( false );
}


function Player::onAnimationEnd( %this )
{
   // We're looking for the end of a jump...
   if ( !%this.isJumping )
      return;

   // So we jumped... clear junk.
   if ( isObject( %this.jumpPath ) )
   {
      %this.jumpPath.detachObject( %this );
      %this.jumpPath.safeDelete();
   }
   %this.isJumping = false;

   //echo( "jumpTime = " @ ( getRealTime() - %this.jumpStartTime ) );
   //echo( "jumpDist = " @ t2dVectorDistance( %this.getPosition(), %this.jumpStartPos ) );
   
   //%this.setCollisionActive( true, true );
}


function getNearestDirAnim( %dir, %animSet )
{
   %nearestDot = -9999;
   %nearestAnim = 0;
   
   for ( %i = 0; %i < %animSet.getCount(); %i++ )
   {
      %anim = %animSet.getObject( %i );
      %normal = t2dVectorNormalise( %anim.dir );
      %dot = t2dVectorDot( %dir, %normal );
      if ( %dot >= %nearestDot )
      {
         %nearestDot = %dot;
         %nearestAnim = %anim;
      }
   }
   
   return %nearestAnim;
}


function buildJumpPath( %startPos, %starDir, %speed )
{
   // First we calculate the jump vector.
   %starDir = t2dVectorNormalise( %starDir );
   %jumpVec = t2dVectorScale( %starDir, %speed );
   
   // Now if the jump vector is not purely east or
   // west we need to shorten it to account for the
   // depth of the scene.  We approximate this by
   // using the dot product with an eastward vector
   // to scale the jump vector.
   //%dot = mAbs( t2dVectorDot( %starDir, "1 0" ) );
   //%jumpVec = t2dVectorScale( %jumpVec, %perspScale );
   
   // Now calculate the final landing point.
   %endPos = t2dVectorAdd( %startPos, %jumpVec );

   // Check to see if we will collide with something.
   //%hits = $levelScene.pickLine( %startPos, %endPos, MASK_ALL, MASK_ALL, false );
   //%count = getWordCount( %hits );
   //for ( %i = 0; %i < %count; %i++ )
   //{
      //%object = getWord( %count, %i );
      //if ( %object == $player )
         //continue;
                     //
   //}

   // The mid point of the jump is the peak of the arc.
   %midPos = t2dVectorAdd( %startPos, t2dVectorScale( %jumpVec, 0.5 ) );
   %midPos = t2dVectorAdd( %midPos, "0 " SPC -PlayerConfig.jumpHeight );
      
   // Create the path... we use a linear interpolation
   // mode because it's the only mode which i can easily
   // measure the travel distance and it's good enough
   // for a simple jump.
   %path = new t2dPath()
   {
      scenegraph = $levelScene;
   };
   %path.setPathType( LINEAR );
   %path.addNode( %startPos );
   %path.addNode( %midPos );
   %path.addNode( %endPos );
   
   // Calculate the length of the path... you would
   // think TGB would include this or allow the path
   // to be driven by time, but it does not. :(
   %length = t2dVectorDistance( %startPos, %midPos );
   %length += t2dVectorDistance( %midPos, %endPos );
   %path.length = %length;
   
   return %path;
}
