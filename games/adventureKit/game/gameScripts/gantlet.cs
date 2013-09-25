//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


// Gantlet \Gant"let\, n. 
//   A military punishment formerly in use, wherein the offender
//   was made to run between two files of men facing one another,
//   who struck him as he passed.
//
//   To run the gantlet, to suffer the punishment of the
//   gantlet; hence, to go through the ordeal of severe
//   criticism or controversy, or ill-treatment at many hands.
//
//   Note: Written also, but less properly, gauntlet.


function Gantlet::onAdd( %this )
{
   if ( !%this.poweredOn )
      return;
      
   // Start firing immediately.
   %this.schedule( 1, startFiring );
}

function Gantlet::startFiring( %this )
{
   %this.poweredOn = true;
   
   // Start firing!      
   if ( %this.msDelay > 0 )
      %this.fireEvent = %this.schedule( %this.msDelay, fire );
   else
      %this.fire();   
}

function Gantlet::stopFiring( %this )
{
   %this.poweredOn = false;
   %this.targets = 0;
   cancel( %this.fireEvent );
}

function Gantlet::onTriggerEnter( %this, %object )
{
   %speed = t2dVectorLength( %object.getLinearVelocity() );

   // Increment the target count... protect against
   // negative counts while we're at it.
   %this.targets = t2dGetMax( 1, %this.targets + 1 );
   
   // Do we need to turn on the fire?
   if ( %this.targets != 1 )
      return;

   // Start firing!
   %this.startFiring();
}

function Gantlet::onTriggerLeave( %this, %object )
{
   // Decrement the target count... protect against
   // negative counts while we're at it.
   %this.targets = t2dGetMax( 0, %this.targets - 1 );

   // Do we need to stop firing?
   if ( %this.targets == 0 )
      %this.stopFiring();
}

function Gantlet::fire( %this )
{
   // If we've been disabled... don't fire again.
   if ( !%this.poweredOn )
   {
      %this.stopFiring();
      return;
   }

   // Fire one projectile in the direction.
   fireRound(  %this.ammoConfig, 
               %this, 
               %this.fireDir, 
               %this.fireOffset, 
               %this.fireHeight );
               
   // Schedule the next fire event!
   %this.fireEvent = %this.schedule( %this.msPerShot, fire );
}
