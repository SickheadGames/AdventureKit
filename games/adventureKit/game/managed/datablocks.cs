$managedDatablockSet = new SimSet() {
   canSaveDynamicFields = "1";
   Parent = "RootGroup";
   setType = "Datablocks";

   new t2dImageMapDatablock(whiteMap) {
      imageName = "~/data/images/white.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(flamesImageMap) {
      imageName = "~/data/images/flames.png";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "32";
      cellHeight = "32";
      preload = "0";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(flamesAnimation) {
      imageMap = "flamesImageMap";
      animationFrames = "0 1 2 3";
      animationTime = "0.3";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
      canSaveDynamicFields = "1";

   };
   
   new t2dImageMapDatablock(particles1ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/particles1";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles2ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/particles2";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles3ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/particles3";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles4ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/particles4";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles5ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/particles5";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles6ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/particles6";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };   
   
   ///////////////////////////////////////////////////////////
   // Kork the Orc
   
   // Orc - forward
   
   new t2dImageMapDatablock(orc_forward_east_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_east";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_east_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_east_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "1 0";
   };  
   
   
   new t2dImageMapDatablock(orc_forward_west_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_west";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };

   
   
   new t2dAnimationDatablock(orc_forward_west_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_west_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 0";
   };
   
    new t2dImageMapDatablock(orc_forward_north_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_north";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_north_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_north_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "0 -1";
   };
   
    new t2dImageMapDatablock(orc_forward_south_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_south";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_south_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_south_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "0 1";
   };
   
    new t2dImageMapDatablock(orc_forward_northwest_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_northwest";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_northwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_northwest_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 -1";
   };  
   
    new t2dImageMapDatablock(orc_forward_northeast_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_northeast";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_northeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_northeast_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "1 -1";
   };  
   
    new t2dImageMapDatablock(orc_forward_southwest_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_southwest";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_southwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_southwest_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 1";
   }; 
   
    new t2dImageMapDatablock(orc_forward_southeast_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_forward_southeast";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "10";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_forward_southeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_forward_southeast_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "1 1";
   }; 


   // Orc - jump
   
     new t2dImageMapDatablock(orc_jump_east_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_east";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_east_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_east_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "1 0";
   };  
   
   new t2dImageMapDatablock(orc_jump_west_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_west";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_west_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_west_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 0";
   };
   
    new t2dImageMapDatablock(orc_jump_north_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_north";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_north_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_north_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "0 -1";
   };
   
    new t2dImageMapDatablock(orc_jump_south_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_south";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_south_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_south_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "0 1";
   };
   
    new t2dImageMapDatablock(orc_jump_northwest_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_northwest";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_northwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_northwest_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 -1";
   };  
   
    new t2dImageMapDatablock(orc_jump_northeast_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_northeast";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_northeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_northeast_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "1 -1";
   };  
   
    new t2dImageMapDatablock(orc_jump_southwest_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_southwest";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_jump_southwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_southwest_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 1";
   }; 
   
    new t2dImageMapDatablock(orc_jump_southeast_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_jump_southeast";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "8";
      cellCountY = "1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "0";
      allowUnload = "1";
   };
   
   new t2dAnimationDatablock(orc_jump_southeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_jump_southeast_map";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "1 1";
   };


   // Orc - idle (root)

  new t2dImageMapDatablock(orc_idle_ewns_map) {
      imageName = "~/data/images/sprites/orc/orc_idle_ewns";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };


 new t2dAnimationDatablock(orc_idle_north_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_ewns_map";
      animationFrames = "8 9 10 10 10 11";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "0 -1";
   };

   new t2dAnimationDatablock(orc_idle_south_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_ewns_map";
      animationFrames = "12 13 14 14 14 15";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "0 1";
   };
   
      new t2dAnimationDatablock(orc_idle_east_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_ewns_map";
      animationFrames = "0 1 2 2 2 3";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "1 0";
   }; 
   
      new t2dAnimationDatablock(orc_idle_west_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_ewns_map";
      animationFrames = "4 5 6 6 6 7";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 0";
   };

   new t2dImageMapDatablock(orc_idle_nwneswse_map) {
      imageName = "~/data/images/sprites/orc/orc_idle_nwneswse";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   
    new t2dAnimationDatablock(orc_idle_northwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_nwneswse_map";
      animationFrames = "0 1 2 2 2 3";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 -1";
   };

   new t2dAnimationDatablock(orc_idle_northeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_nwneswse_map";
      animationFrames = "4 5 6 6 6 7";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "1 -1";
   };
   
   new t2dAnimationDatablock(orc_idle_southwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_nwneswse_map";
      animationFrames = "8 9 10 10 10 11";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 1";
   }; 
   
      new t2dAnimationDatablock(orc_idle_southeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_idle_nwneswse_map";
      animationFrames = "12 13 14 14 14 15";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      dir = "1 1";
   };



   // Orc - die
   
       new t2dImageMapDatablock(orc_die_north_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_die_north";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "232";
      cellHeight = "232";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dAnimationDatablock(orc_die_north_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_die_north_map";
      animationFrames = "0 1 2 3 4 5 6";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "0 -1";
   };

   
     new t2dImageMapDatablock(orc_die_south_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_die_south";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "232";
      cellHeight = "232";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_die_south_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_die_south_map";
      animationFrames = "0 1 2 3 4 5 6";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "0 1";
   }; 
   
     new t2dImageMapDatablock(orc_die_east_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_die_east";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "232";
      cellHeight = "232";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_die_east_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_die_east_map";
      animationFrames = "0 1 2 3 4 5 6";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "1 0";
   };
   
     new t2dImageMapDatablock(orc_die_west_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_die_west";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "232";
      cellHeight = "232";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_die_west_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_die_west_map";
      animationFrames = "0 1 2 3 4 5 6";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 0";
   };


   
   /*
      These are only commented out because they are not
      used in the demo and were just eating up memory.
      
      // Orc - fire (standing)
      
   new t2dImageMapDatablock(orc_fire_north_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_north";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_north_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_north_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "0 -1";
   }; 
   
      new t2dImageMapDatablock(orc_fire_south_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_south";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_south_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_south_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "0 1";
   }; 
   
      new t2dImageMapDatablock(orc_fire_east_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_east";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_east_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_east_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
   };
   
      new t2dImageMapDatablock(orc_fire_west_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_west";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_west_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_west_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 0";
   }; 
   
      new t2dImageMapDatablock(orc_fire_northeast_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_northeast";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_northeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_northeast_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "1 -1";
   };
   
      new t2dImageMapDatablock(orc_fire_northwest_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_northwest";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_northwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_northwest_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 -1";
   };  
   
      new t2dImageMapDatablock(orc_fire_southeast_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_southeast";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_southeast_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_southeast_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
   }; 
   
      new t2dImageMapDatablock(orc_fire_southwest_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/orc/orc_fire_southwest";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "165";
      cellHeight = "165";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(orc_fire_southwest_anim) {
      canSaveDynamicFields = "1";
      imageMap = "orc_fire_southwest_map";
      animationFrames = "0 1 2 3 2 1";
      animationTime = "0.3";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
      dir = "-1 1";
   }; 

   */
   
   new t2dImageMapDatablock(decoration_tiles_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/tiles/decoration_tiles";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "0";
      allowUnload = "1";      
   };
   new t2dImageMapDatablock(groundtiles_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/tiles/ground_tiles";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "0";
      allowUnload = "1";            
   };
   
      new t2dImageMapDatablock(groundtiles2_map) {
      imageName = "~/data/images/tiles/ground_tiles_02";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "5";
      cellCountY = "5";
      cellWidth = "128";
      cellHeight = "128";
      preload = "1";
      allowUnload = "0";
   };

   new t2dImageMapDatablock(stonepath_map) {
      imageName = "~/data/images/tiles/stonepath";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };

   new t2dImageMapDatablock(elephantear_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/elephant_ear";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "126";
      cellHeight = "126";
      preload = "0";
      allowUnload = "1";      
   };
   new t2dAnimationDatablock(elephant_ear_anim) {
      canSaveDynamicFields = "1";
      imageMap = "elephantear_map";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };    
     new t2dImageMapDatablock(stonewalls_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/stonewalls";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };   
     
   new t2dImageMapDatablock(arrow_map) {
      imageName = "~/data/images/sprites/arrow";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };

   new t2dImageMapDatablock(campfire_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/campfire_lit";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "126";
      cellHeight = "89";
      preload = "0";
      allowUnload = "1";      
   };
   new t2dAnimationDatablock(campfirelit_anim) {
      canSaveDynamicFields = "1";
      imageMap = "campfire_map";
      animationFrames = "1 2 1 2 1 2 1 0 2 1 2 1 2 0 2 1";
      animationTime = "2";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };

    new t2dImageMapDatablock(fences_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/fences";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
    new t2dImageMapDatablock(rock_greygranite_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/rock_greygranite";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";   
   };
   new t2dImageMapDatablock(rock_greygranitemossy_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/rock_greygranitemossy";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   new t2dImageMapDatablock(rock_pinkgranite_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/rock_pinkgranite";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };

   new t2dImageMapDatablock(rock_sandstone_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/rock_sandstone";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };

    new t2dImageMapDatablock(stumplogs_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/stumplogs";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   
    new t2dImageMapDatablock(broadleaf_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/broadleaf";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "124";
      cellHeight = "114";
      preload = "0";
      allowUnload = "1";      
   };
   
   new t2dAnimationDatablock(broadleaf_anim) {
      canSaveDynamicFields = "1";
      imageMap = "broadleaf_map";
      animationTime = "3";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };

   new t2dImageMapDatablock(smallplants_map) {
      canSaveDynamicFields = "1";
      imageName = "~/data/images/sprites/smallplants";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };

   new t2dImageMapDatablock(graveldeco_map) {
      imageName = "~/data/images/sprites/graveldeco";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   
   new t2dImageMapDatablock(shortgrassclearings_map) {
      imageName = "~/data/images/sprites/shortgrass_clearings";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   
   new t2dImageMapDatablock(longgrassclearings_map) {
      imageName = "~/data/images/sprites/longgrass_clearings";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   
   new t2dImageMapDatablock(darkdirtclearings_map) {
      imageName = "~/data/images/sprites/darkdirt_clearings";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   
   new t2dImageMapDatablock(gantlet_map) {
      imageName = "~/data/images/sprites/gantlet";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";      
   };
   
   new t2dImageMapDatablock(tentsmall_map) {
      imageName = "~/data/images/sprites/tent_small";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dImageMapDatablock(tentlarge_map) {
      imageName = "~/data/images/sprites/tent_large";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";  
   };
   
    new t2dImageMapDatablock(ripple_map) {
      imageName = "~/data/images/sprites/ripple";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "11";
      cellCountY = "1";
      cellWidth = "98";
      cellHeight = "67";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dAnimationDatablock(ripple_anim) {
      imageMap = "ripple_map";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   
      new t2dImageMapDatablock(shackcutaway3_map) {
      imageName = "~/data/images/sprites/shackcutaway3";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";  
   };

      new t2dImageMapDatablock(structures_map) {
      imageName = "~/data/images/sprites/structures";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dImageMapDatablock(hedge_map) {
      imageName = "~/data/images/sprites/hedge";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "198";
      cellHeight = "100";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dImageMapDatablock(treevaristatic_map) {
      imageName = "~/data/images/sprites/trees/treevaristatic";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dImageMapDatablock(firsmallgreen_map) {
      imageName = "~/data/images/sprites/trees/firsmall_green";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "3";
      cellCountY = "3";
      cellWidth = "168";
      cellHeight = "311";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dAnimationDatablock(firsmallgreen_anim) {
      imageMap = "firsmallgreen_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 8 8 7 6 5 4 3 2 1 0 0";
      animationTime = "2.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   
   new t2dImageMapDatablock(firsmallbrown_map) {
      imageName = "~/data/images/sprites/trees/firsmall_brown";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "3";
      cellCountY = "3";
      cellWidth = "168";
      cellHeight = "311";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dAnimationDatablock(firsmallbrown_anim) {
      imageMap = "firsmallbrown_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 8 8 7 6 5 4 3 2 1 0 0";
      animationTime = "2.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   
   new t2dImageMapDatablock(smalltreegreen_map) {
      imageName = "~/data/images/sprites/trees/smalltree_green";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "5";
      cellCountY = "2";
      cellWidth = "100";
      cellHeight = "243";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dAnimationDatablock(smalltreegreen_anim) {
      imageMap = "smalltreegreen_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 9 8 7 6 5 4 3 2 1 0";
      animationTime = "2";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   
   new t2dImageMapDatablock(smalltreeyellow_map) {
      imageName = "~/data/images/sprites/trees/smalltree_yellow";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "5";
      cellCountY = "2";
      cellWidth = "100";
      cellHeight = "243";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dAnimationDatablock(smalltreeyellow_anim) {
      imageMap = "smalltreeyellow_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 9 8 7 6 5 4 3 2 1 0";
      animationTime = "2";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   

   new t2dImageMapDatablock(dectreevar06_map) {
      imageName = "~/data/images/sprites/trees/dectree_var06";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "4";
      cellCountY = "3";
      cellWidth = "308";
      cellHeight = "388";
      preload = "0";
      allowUnload = "1";  
   };
   
   new t2dAnimationDatablock(dectreevar06anim) {
      imageMap = "dectreevar06_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 9 10 10 9 8 7 6 5 4 3 2 1 0 0 0 0 0";
      animationTime = "4";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   
   new t2dImageMapDatablock(bamboo_map) {
      imageName = "~/data/images/sprites/trees/bamboo";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "0";
      allowUnload = "1";  
   };
   
    new t2dImageMapDatablock(flags_map) {
      imageName = "~/data/images/sprites/flags";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "539";
      cellHeight = "175";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(flagred_anim) {
      imageMap = "flags_map";
      animationFrames = "1 2 3 4 5 6 7 8 9 10 11 12 13 14";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   new t2dAnimationDatablock(flagblue_anim) {
      imageMap = "flags_map";
      animationFrames = "15 16 17 18 19 20 21 22 23 24 25 26 27 28";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   new t2dAnimationDatablock(flagyellow_anim) {
      imageMap = "flags_map";
      animationFrames = "29 30 31 32 33 34 35 36 37 38 39 40 41 42";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   new t2dAnimationDatablock(flaggreen_anim) {
      imageMap = "flags_map";
      animationFrames = "43 44 45 46 47 48 49 50 51 52 53 54 55 56";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   new t2dImageMapDatablock(treasurechest_map) {
      imageName = "~/data/images/sprites/treasurechest";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(treasurechest_anim) {
      imageMap = "treasurechest_map";
      animationFrames = "1 1 2 2 1 1 2 1 2 1 2 3 4 5 6";
      animationTime = "1";
      animationCycle = "0";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dImageMapDatablock(bags_map) {
      imageName = "~/data/images/sprites/bags";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(mushbaskets_map) {
      imageName = "~/data/images/sprites/mushbaskets";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(torch_map) {
      imageName = "~/data/images/sprites/torch";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "27";
      cellHeight = "77";
      preload = "1";
      allowUnload = "0";
   };
   
   new t2dImageMapDatablock(pier_map) {
      imageName = "~/data/images/sprites/pier";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   
  
   
   /* MAPS FOR LAKECREEK */

   new t2dImageMapDatablock(lakecreektiles14_map) {
      imageName = "~/data/images/tiles/lakecreektiles14";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";  
   };
   

   new t2dImageMapDatablock(lakecreektiles58_map) {
      imageName = "~/data/images/tiles/lakecreektiles58";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";  
   };
   
   new t2dImageMapDatablock(lakecreek_linkmap) {
      imageName = "FIX_FOR_LINKMAP_BUG";
      imageMode = "LINK";
      linkImageMaps = "lakecreektiles14_map lakecreektiles58_map";
   };
   
   new t2dImageMapDatablock(lakecreektiles912_map) {
      imageName = "~/data/images/tiles/lakecreektiles912";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "0";
      allowUnload = "1";  
   };
   
   
   /* ANIMATIONS FOR LAKECREEK  */     

   new t2dAnimationDatablock(lakecreektiles01_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "0 1 2 3 4 5 6 7 8 9";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles02_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "10 11 12 13 14 15 16 17 18 19";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles03_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "20 21 22 23 24 25 26 27 28 29";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles04_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "30 31 32 33 34 35 36 37 38 39";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
    new t2dAnimationDatablock(lakecreektiles05_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "40 41 42 43 44 45 46 47 48 90";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   
   new t2dAnimationDatablock(lakecreektiles06_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "50 51 52 53 54 55 56 57 58 59";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles07_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "60 61 62 63 64 65 66 67 68 69";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles08_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "70 71 72 73 74 75 76 77 78 79";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles09_anim) {
      imageMap = "lakecreek_linkmap";
      animationFrames = "80 81 82 83 84 85 86 87 88 89";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles10_anim) {
      imageMap = "lakecreektiles912_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 9";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles11_anim) {
      imageMap = "lakecreektiles912_map";
      animationFrames = "10 11 12 13 14 15 16 17 18 19";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles12_anim) {
      imageMap = "lakecreektiles912_map";
      animationFrames = "20 21 22 23 24 25 26 27 28 29";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(lakecreektiles13_anim) {
      imageMap = "lakecreektiles912_map";
      animationFrames = "30 31 32 33 34 35 36 37 38 39";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };


 /* MAPS FOR OCEAN */
   
   new t2dImageMapDatablock(oceantiles14_map) {
      imageName = "~/data/images/tiles/oceantiles14";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";  
   };
   
   new t2dImageMapDatablock(oceantiles58_map) {
      imageName = "~/data/images/tiles/oceantiles58";
      imageMode = "KEY";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0"; 
   };
   
   new t2dImageMapDatablock(ocean_linkmap) {
      imageName = "FIX_FOR_LINKMAP_BUG";
      imageMode = "LINK";
      linkImageMaps = "oceantiles14_map oceantiles58_map";
   };
   
   new t2dImageMapDatablock(oceantiles912_map) {
      imageName = "~/data/images/tiles/oceantiles912";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "0";
      allowUnload = "1"; 
   };

/* ANIMATIONS FOR OCEAN  */   

   new t2dAnimationDatablock(oceantiles01_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "0 1 2 3 4 5 6 7 8 9";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles02_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "10 11 12 13 14 15 16 17 18 19";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles03_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "20 21 22 23 24 25 26 27 28 29";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles04_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "30 31 32 33 34 35 36 37 38 39";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
    new t2dAnimationDatablock(oceantiles05_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "40 41 42 43 44 45 46 47 48 90";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   
   new t2dAnimationDatablock(oceantiles06_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "50 51 52 53 54 55 56 57 58 59";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles07_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "60 61 62 63 64 65 66 67 68 69";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles08_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "70 71 72 73 74 75 76 77 78 79";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles09_anim) {
      imageMap = "ocean_linkmap";
      animationFrames = "80 81 82 83 84 85 86 87 88 89";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles10_anim) {
      imageMap = "oceantiles912_map";
      animationFrames = "0 1 2 3 4 5 6 7 8 9";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles11_anim) {
      imageMap = "oceantiles912_map";
      animationFrames = "10 11 12 13 14 15 16 17 18 19";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles12_anim) {
      imageMap = "oceantiles912_map";
      animationFrames = "20 21 22 23 24 25 26 27 28 29";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dAnimationDatablock(oceantiles13_anim) {
      imageMap = "oceantiles912_map";
      animationFrames = "30 31 32 33 34 35 36 37 38 39";
      animationTime = "1.5";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
         
};

