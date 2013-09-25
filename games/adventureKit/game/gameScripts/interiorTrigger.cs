//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function InteriorTrigger::onEnter( %this, %object )
{
   // Do we have an object to trigger?
   %triggered = %this.triggered;
   if ( !isObject( %triggered ) )
      return;
   
   // Figure out how much to fade out per step.
   %steps = %this.fadeMS / 100;
   %step = -1 / %steps;
   %triggered.fadeBlendAlpha( %step, %this.fadeMS );
}

function InteriorTrigger::onLeave( %this, %object )
{
   // Do we have an object to trigger still?
   %triggered = %this.triggered;
   if ( !isObject( %triggered ) )
      return;
      
   // Figure out how much to fade out per step.
   %steps = %this.fadeMS / 100;
   %step = 1 / %steps;
   %triggered.fadeBlendAlpha( %step, %this.fadeMS );
}
