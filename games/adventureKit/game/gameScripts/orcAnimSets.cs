//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------

// These SimSets are used to group the animations for
// different orc states.  Each animation datablock has
// a 'dir' field which specifies the direction normal
// of that animation.  We then use getNearestDirAnim()
// to select the right animation for our movement.

if ( !isObject( OrcIdleAnims ) )
{
   new SimSet( OrcIdleAnims );
   OrcIdleAnims.add( orc_idle_north_anim );
   OrcIdleAnims.add( orc_idle_northeast_anim );
   OrcIdleAnims.add( orc_idle_east_anim );
   OrcIdleAnims.add( orc_idle_southeast_anim );
   OrcIdleAnims.add( orc_idle_south_anim );
   OrcIdleAnims.add( orc_idle_southwest_anim );
   OrcIdleAnims.add( orc_idle_west_anim );
   OrcIdleAnims.add( orc_idle_northwest_anim );
}

if ( !isObject( OrcRunAnims ) )
{
   new SimSet( OrcRunAnims );
   OrcRunAnims.add( orc_forward_north_anim );
   OrcRunAnims.add( orc_forward_northeast_anim );
   OrcRunAnims.add( orc_forward_east_anim );
   OrcRunAnims.add( orc_forward_southeast_anim );
   OrcRunAnims.add( orc_forward_south_anim );
   OrcRunAnims.add( orc_forward_southwest_anim );
   OrcRunAnims.add( orc_forward_west_anim );
   OrcRunAnims.add( orc_forward_northwest_anim );
}

if ( !isObject( OrcJumpAnims ) )
{
   new SimSet( OrcJumpAnims );
   OrcJumpAnims.add( orc_jump_north_anim );
   OrcJumpAnims.add( orc_jump_northeast_anim );
   OrcJumpAnims.add( orc_jump_east_anim );
   OrcJumpAnims.add( orc_jump_southeast_anim );
   OrcJumpAnims.add( orc_jump_south_anim );
   OrcJumpAnims.add( orc_jump_southwest_anim );
   OrcJumpAnims.add( orc_jump_west_anim );
   OrcJumpAnims.add( orc_jump_northwest_anim );
}

if ( !isObject( OrcDeathAnims ) )
{
   new SimSet( OrcDeathAnims );
   OrcDeathAnims.add( orc_die_north_anim );
   OrcDeathAnims.add( orc_die_east_anim );
   OrcDeathAnims.add( orc_die_south_anim );
   OrcDeathAnims.add( orc_die_west_anim );
}
