//------------------------------------------------------------------------------
// Torque Game Builder Adventure Kit
// Copyright (C) Sickhead Games, LLC
//------------------------------------------------------------------------------


new AudioDescription(AudioNonLooping)
{
   volume   = 1.0;
   isLooping= false;
   is3D     = false;
   type     = $GuiAudioType;
};

new AudioDescription(AudioLooping)
{
   volume   = 1.0;
   isLooping= true;
   is3D     = false;
   type     = $GuiAudioType;
};


new AudioProfile(ambientAudio)
{
   filename = "~/data/audio/ambient.ogg";
   description = "AudioLooping";
   preload = true;
   volume = 0.9;
};


new AudioProfile(boltShotAudio)
{
   filename = "~/data/audio/boltShot.ogg";
   description = "AudioNonLooping";
   preload = true;
   radius = 60;
   volume = 0.5;
};


new AudioProfile(orcGruntAudio)
{
   filename = "~/data/audio/orcGrunt.ogg";
   description = "AudioNonLooping";
   preload = true;
   volume = 0.8;
   radius = 40;     
};


new AudioProfile(orcBreathingAudio)
{
   filename = "~/data/audio/orcBreathing.ogg";
   description = "AudioLooping";
   preload = true;
   volume = 0.7;
   radius = 40;     
};


new AudioProfile(orcRunAudio)
{
   filename = "~/data/audio/orcRun.ogg";
   description = "AudioLooping";
   preload = true;
   volume = 0.7;
   radius = 40;   
};


new AudioProfile(orcPainAudio)
{
   filename = "~/data/audio/orcPain.ogg";
   description = "AudioNonLooping";
   preload = true;
   volume = 0.8;
   radius = 40;   
};


new AudioProfile(orcDeathAudio)
{
   filename = "~/data/audio/orcDeath.ogg";
   description = "AudioNonLooping";
   preload = true;
   volume = 0.8;
   radius = 40;   
};


new AudioProfile(tntExplodeAudio)
{
   filename = "~/data/audio/tntExplode.ogg";
   description = "AudioNonLooping";
   preload = true;
   volume = 0.7;
   radius = 60;
};


new AudioProfile(breakWallAudio)
{
   filename = "~/data/audio/breakWall.ogg";
   description = "AudioNonLooping";
   preload = true;
   radius = 40;
   volume = 0.8;
};


new AudioProfile(spawnAudio)
{
   filename = "~/data/audio/spawn.ogg";
   description = "AudioNonLooping";
   preload = true;
   radius = 80;
   volume = 0.8;   
};


new AudioProfile(fireAudio)
{
   filename = "~/data/audio/fire.ogg";
   description = "AudioLooping";
   preload = true;
   radius = 80;
   volume = 0.8;
};


new AudioProfile(oceanAudio)
{
   filename = "~/data/audio/ocean.ogg";
   description = "AudioLooping";
   preload = true;
   radius = 80;
   volume = 0.8;
};

new AudioProfile(streamAudio)
{
   filename = "~/data/audio/stream.ogg";
   description = "AudioLooping";
   preload = true;
   radius = 80;
   volume = 0.8;
};


