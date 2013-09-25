//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


function cameraCreate( %sceneGraph )
{
   %camera = new t2dSceneObject()
   {
      class = "Camera";
      scenegraph = %sceneGraph;
      visible = false;
   };

   %camera.setTrackingForce( 0 );
   %camera.setOffset( "0 0" );
   %camera.setTarget( 0 );
   %camera.setZoom( 1, 0 );
   
   // Enable tick updates.   
   %camera.enableUpdateCallback();
   
   return %camera;
}

function Camera::onRemove( %this )
{
   sceneWindow2D.dismount();
}

function Camera::getRadius( %this )
{
   %pt = getWords( sceneWindow2D.getCurrentCameraArea(), 0, 1 );
   %ct = sceneWindow2D.getCurrentCameraPosition();
   return t2dVectorDistance( %pt, %ct );
}

function Camera::setPosition( %this, %pos )
{
   if ( isObject( %this.target ) )
      return;
      
   Parent::setPosition( %this, %pos );

   sceneWindow2D.dismount();
   sceneWindow2D.setCurrentCameraPosition( %pos );
   %this.setTrackingForce( %this.trackingForce );
}


function Camera::setTrackingForce( %this, %force )
{
   %this.trackingForce = %force;
   sceneWindow2D.mount( %this, "0 0", %force, true );
}


function Camera::setTarget( %this, %target, %reposition )
{
   %this.target = %target;
   
   if ( isObject( %this.target ) && %reposition )
      Parent::setPosition( %this, %this.target.getPosition() );
}


function Camera::setOffset( %this, %offset )
{
   %this.xOffset = getWord( %offset, 0 );
   %this.yOffset = getWord( %offset, 1 );
}

function Camera::setZoom( %this, %zoom, %seconds )
{
   %this.newZoom = %zoom;
   %this.zoomTime = %seconds;   

   if ( %seconds == 0 )
   {
      sceneWindow2D.setCurrentCameraZoom( %this.newZoom );
      return;      
   }

   %currZoom = sceneWindow2D.getCurrentCameraZoom();
   %this.zoomDelta = ( %currZoom - %zoom ) / %seconds;
}

function Camera::shakeCamera( %this, %magnitude, %seconds )
{
   sceneWindow2D.startCameraShake( %magnitude, %seconds );
}

function Camera::onUpdate( %this )
{
   // Get the time elapsed for this tick.
   %elapsed = 32 / 1000;
         
   // Are we doing a zoom?
   %currZoom = sceneWindow2D.getCurrentCameraZoom();
   if ( %this.zoomTime > 0 )
   {
      %this.zoomTime -= %elapsed;
      if ( %this.zoomTime <= 0 )
         %currZoom = %this.newZoom;
      else
         %currZoom -= %this.zoomDelta * %elapsed;

      sceneWindow2D.setCurrentCameraZoom( %currZoom );
   }

   %target = %this.target;
   if ( !isObject( %target ) )
      return;
      
   %this.setPositionX( %target.getPositionX() + %this.xOffset );
   %this.setPositionY( %target.getPositionY() + %this.yOffset );
}



