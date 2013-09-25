//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function CameraTrigger::onEnter(%this, %object)
{
   if ( %this.zoom !$= "" )
      $camera.setZoom( %this.zoom, %this.zoomSeconds );
}

function CameraTrigger::onLeave(%this, %object)
{
   if ( %this.zoom !$= "" )
      $camera.setZoom( 1, %this.zoomSeconds );
}

