//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------

// This script is loaded both by the game and the 
// editor and is used to define datablocks that are
// needed in both.

// There are a few resources which we gotta 
// load here so that they work from within 
// the config datablocks below.
exec( "./orcAnimSets.cs" );
exec( "./audio.cs" );



//------------------------------------------------------------------------------
// Ammo

datablock t2dSceneObjectDatablock( AmmoConfig )
{
   class = "Round";

   layer = 10;
   
   // All the ammo is in group 9 and it
   // doesn't collide with itself.
   graphGroup = 9;

   // Ammo can only collide with the default
   // and the player and enemy groups.
   collisionGroups = BIT(0) | BIT(1) | BIT(2);

   // Setup the normal collision basics.
   collisionResponseMode = CLAMP;
   collisionActiveSend = true;
   collisionActiveReceive = true;
   collisionPhysicsSend = false;
   collisionPhysicsReceive = false;
   collisionCallback = true;

   // The audio profile for the firing event.
   fireAudio = 0;
   
   // The audio profile for the explosion event.
   explodeAudio = 0;
   
   // This is the particle effect to play for an explosion.
   explodeEffect = "";

   // This tells the code if it needs to rotate the 
   // image with the velocity vector or not.
   rotWithVelocity = true;

   speed    = 0;
   damage   = 0;
   damageRadius = 0;
   deleteMS = 2500;
};


datablock t2dSceneObjectDatablock( BoltAmmoConfig : AmmoConfig )
{
   imageMap = arrow_map;
   frame = 0;
   size = "4.15055 0.4981";
   sortPoint = "0 1.5";

   collisionPolyList = "0.175 -0.175 0.175 0.175 -0.175 0.175 -0.175 -0.175";
   
   fireAudio = boltShotAudio;

   speed    = 80;
   damage   = 40;
};


datablock t2dSceneObjectDatablock( BombAmmoConfig : AmmoConfig )
{
   imageMap = structures_map;
   frame = 9;
   size = "1.892 3.054";
   sortPoint = "0 2.1";
   
   collisionPolyList = "-0.939 0.423 0.0 0.1 0.939 0.423 0.0 0.939";
   
   fireAudio = boltShotAudio;
   explodeAudio = tntExplodeAudio;
   explodeEffect = "~/data/particles/explosion.eff";

   rotWithVelocity = false;
   
   speed    = 80;
   damage   = 150;
   damageRadius = 15;
};


//------------------------------------------------------------------------------
// Player

datablock t2dSceneObjectDatablock( PlayerConfig )
{
   class = "Player";
   superclass = "";

   size = "16.113 16.113";
   layer = 10;
   sortPoint = "0 0.3";
   animationName = orc_idle_south_anim;
   
   // The player is the only thing on graph
   // group 1... this allows us to easily
   // limit some collision to only effect the
   // player... like some gameplay triggers.
   graphGroup = 1;
   
   // Make sure we collide with our special 
   // triggers, enemies, other players, world
   // items, and weapon fire.
   collisionGroups = BIT(0) | BIT(1) | BIT(2) | BIT(9) | BIT(10) | BIT(11);
      
   // Here we setup a simple collision diamond and prepare
   // the player to recieve as well as dish out collision
   // and physics responses.
   collisionPolyList = "-0.4 0.2 0 -0.1 0.4 0.2 0 0.5";
   collisionResponseMode = CLAMP;
   collisionActiveSend = true;
   collisionActiveReceive = true;
   collisionPhysicsSend = true;
   collisionPhysicsReceive = true;

   // This selects the ammo that the player is firing.  This
   // could be extended to support a switching weapons system. 
   ammoConfig = BoltAmmoConfig;
   
   // This is the number of rounds you 
   // can fire per second.
   fireRate = 5;

   // This is how far, in object space units, from the sort 
   // point to spawn the projectile when firing.  This should
   // take into account the collision shape of the player and
   // the projectile to ensure we don't hit ourselves.
   fireOffset = 0.6;
   
   fireHeight = 0.5;
   
   // The animation sets to use for various states.
   idleAnimsSet = OrcIdleAnims;
   runAnimsSet = OrcRunAnims;
   jumpAnimsSet = OrcJumpAnims;
   deathAnimsSet = OrcDeathAnims;
   
   deathAudio = OrcDeathAudio;
   painAudio = OrcPainAudio;
   breathAudio = OrcBreathingAudio;
   runAudio = OrcRunAudio;
   jumpAudio = OrcGruntAudio;

   // Stuff we use from script!
   runSpeed = 22;
   jumpHeight = 6;
   jumpSpeed = 40;   
   direction = "0 1";
   life = 100;
};


datablock t2dSceneObjectDatablock( AiPlayerConfig : PlayerConfig )
{
   class = "AiPlayer";
   superclass = "Player";
   
   // Only enemies are on the second 
   // graph group.
   graphGroup = 2;
   
   // Make sure the enemy cannot collide
   // against any of our special triggers,
   // but can collide with the world, the
   // player, and weapon fire.
   collisionGroups = BIT(0) | BIT(1) | BIT(2) | BIT(9) | BIT(11);

   // This is the class of object the
   // AI considers as the enemy.
   enemyClass = "Player";

   // This is how far the AI will travel
   // from his spawn point when patrolling
   // for an enemy to target.
   patrolRange = 40;
   
   // This is the fov used when doing 
   // visibility testing.
   lookFov = 210;
   
   // This is the distance used when
   // doing visibility testing.
   lookDist = 36;
   
   // This is how close the enemy can get before
   // the AI will be alert to his presence.
   sneakDist = 10;
   
   // Slow down the AI fire rate to make them 
   // easier to handle.
   fireRate = 3;
   
   // Make the AI slightly slower to let the player
   // be able to out run them.
   runSpeed = 15;
   
   // This is the distance at which the
   // AI will stop chasing the player and
   // start firing at him.
   attackDist = 40;
   
   // Here we set the AI think rate in milliseconds
   // which basicly controls overall reaction time.
   thinkRate = 360;   
};


datablock t2dSceneObjectDatablock( GigantorkConfig : AiPlayerConfig )
{ 
   size = "40 40";
   patrolRange = 60;
   lookFov = 170;
   lookDist = 80;
   attackDist = 70;
   sneakDist = 10;
   fireRate = 1.2;
   runSpeed = 10;
   life = "1000";
   thinkRate = 400;   
   AmmoConfig = "BombAmmoConfig";
};


//------------------------------------------------------------------------------
// SpawnPoints

datablock t2dSceneObjectDatablock( SpawnPointConfig )
{
   class = "SpawnPoint";

   layer = 10;
   size = "5 5";
   
   effectFile = "~/data/particles/spawn.eff";
   effectTime = 3;
   effectAudio = spawnAudio;
   spawnDelayMS = 2000;
};


datablock t2dSceneObjectDatablock( EnemySpawnConfig : SpawnPointConfig )
{
   class = "EnemySpawn";
   superclass = "SpawnPoint";

   spawnConfig = AiPlayerConfig;
   spawnOnAdd = true;
   spawnCount = 1;
   spawnNextMS = 10000;
};


//------------------------------------------------------------------------------
// SoundEmitter

datablock t2dSceneObjectDatablock( SoundEmitterConfig )
{
   class = "SoundEmitter";

   // By putting the sound emitter on a different
   // graph group we're blocking it from collision
   // queries... this is a savings in collision 
   // processing.
   graphGroup = 15;

   profile = 0;
   volume = 1;
   playOnce = false;
   ambient = false;
};


//------------------------------------------------------------------------------
// Triggers

datablock t2dSceneObjectDatablock( ObjectTriggerConfig )
{
   class = "ObjectTrigger";

   // The object triggers are by default only 
   // tripped by the player and enemies.
   collisionGroups = BIT(1) | BIT(2);
   
   enterCallback = true;
   leaveCallback = true;
   
   graphGroup = 10;

   triggered = 0;   
};


datablock t2dSceneObjectDatablock( InteriorTriggerConfig )
{
   class = "InteriorTrigger";

   // Put this on a special graph
   // group so that we can keep the
   // AI from colliding with it.
   graphGroup = 10;

   // This trigger can only be tripped by
   // the player himself.
   collisionGroups = BIT(1);
   
   enterCallback = true;
   leaveCallback = true;
   
   triggered = 0;
   fadeMS = 500;
};


datablock t2dSceneObjectDatablock( LevelTriggerConfig )
{
   class = "LevelTrigger";

   // This trigger can only be tripped by
   // the player himself.
   collisionGroups = BIT(1);
   
   enterCallback = true;
   leaveCallback = false;

   // Put this on a special graph
   // group so that we can keep the
   // AI from colliding with it.
   graphGroup = 10;

   levelFile = 0;
   optionalSpawnPoint = 0;

   effectFile = "~/data/particles/spawn.eff";
   effectTime = 3;
   effectAudio = spawnAudio; 
};


datablock t2dSceneObjectDatablock( CameraTriggerConfig )
{
   class = "CameraTrigger";

   // This trigger can only be tripped by
   // the player himself.
   collisionGroups = BIT(1);

   enterCallback = true;
   leaveCallback = true;
   
   // Put this on a special graph
   // group so that we can keep the
   // AI from colliding with it.
   graphGroup = 10;
   
   zoom = 0.5;
   zoomSeconds = 2;
};


//------------------------------------------------------------------------------
// Traps

datablock t2dSceneObjectDatablock( GantletConfig )
{
   class = "Gantlet";

   msDelay = 0;
   msPerShot = 1000;
   fireDir = "-1 0";
   fireOffset = 0.5;
   fireHeight = 0.5;
   
   ammoConfig = BoltAmmoConfig;
};


//------------------------------------------------------------------------------
// Breakables

datablock t2dSceneObjectDatablock( BreakableConfig )
{
   class = "Breakable";

   layer = 10;

   collisionActiveSend = true;
   collisionActiveReceive = false;
   collisionPhysicsSend = false;
   collisionPhysicsReceive = false;

   noSplashDamage = false;
   onlySplashDamage = false;
   
   explodeEffect = "";
   explodeAudio = 0;
   
   explodeMark = "";
   explodeMarkFrame = 0;
   explodeMarkOffset = "0 0";
   
   breakObject = 0;

   cameraShakeMag = 0;
   cameraShakeTime = 0;

   life = 100;
};


datablock t2dSceneObjectDatablock( TNTBarrelConfig : BreakableConfig )
{
   // You cannot set imageMaps here for things you
   // place in the level builder... it will always
   // use frame 0.
   //imageMap = "structures_map";
   //frame = 9;
   
   layer = 10;
   size = "5.078 7.715";
   sortPoint = "0.000 0.900";

   autoMassInertia = false;
   mass = 10;
   inertia = 1;
   damping = 0.99;

   collisionActiveSend = true;
   collisionActiveReceive = true;
   collisionPhysicsSend = false;
   collisionPhysicsReceive = false;
   collisionPolyList = "-0.939 0.423 -0.833 0.241 -0.352 0.056 0.159 0.056 0.691 0.157 0.914 0.411 0.737 0.680 0.271 0.931 -0.387 0.909 -0.863 0.611";

   explodeEffect = "~/data/particles/explosion.eff";
   explodeAudio = tntExplodeAudio;
   
   explodeMark = structures_map;
   explodeMarkFrame = 7;
   explodeMarkOffset = "0 2";
   
   cameraShakeMag = 8;
   cameraShakeTime = 2;

   splashRadius = 15;
   splashDamage = 200;
};


datablock t2dSceneObjectDatablock( BreakableWallConfig : BreakableConfig )
{
   class = "Breakable";

   layer = 10;

   onlySplashDamage = true;
   explodeEffect = "~/data/particles/breakwall.eff";
   explodeAudio = breakWallAudio;
};
