//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function ObjectTrigger::onEnter( %this, %object )
{
   // Do we have an object to trigger?
   %triggered = %this.triggered;
   if ( !isObject( %triggered ) )
      return;

   // If we're not a group... just fire it right away!
   if ( %triggered.getClassName() !$= "t2dSceneObjectGroup" )
   {
      %triggered.onTriggerEnter( %object );
      return;
   }

   // We're pointing at a group... trigger each child!
   %count = %triggered.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %child = %triggered.getObject( %i );
      %child.onTriggerEnter( %object );
   }
}

function ObjectTrigger::onLeave( %this, %object )
{
   // Do we have an object to trigger still?
   %triggered = %this.triggered;
   if ( !isObject( %triggered ) )
      return;

   // If we're not a group... just fire it right away!
   if ( %triggered.getClassName() !$= "t2dSceneObjectGroup" )
   {
      %triggered.onTriggerLeave( %object );
      return;
   }

   // We're pointing at a group... trigger each child!
   %count = %triggered.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %child = %triggered.getObject( %i );
      %child.onTriggerLeave( %object );
   }
}
