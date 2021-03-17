using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HelMod
{
    public class HelMod : Mod
	{
        public HelMod()
        {
         
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                bossChecklist.Call("AddbossWithInfo", "Supreme Hel Drone", 14.5f, (Func<bool>)(() => HelWorld.downedSupremeHelDrone), "Use a [i:" + ModContent.ItemType<Items.Summons.DroneBeacon>() + "] anywhere");
            }
        }


        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("HelMod:GoldBar", group);

            RecipeGroup group1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 2 Hardmode Bar", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("HelMod:Tier2HardmodeBar", group1);

            RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 3 Hardmode Bar", new int[]
            {
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            });
            RecipeGroup.RegisterGroup("HelMod:Tier3HardmodeBar", group2);

            RecipeGroup group3 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Bar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            RecipeGroup.RegisterGroup("HelMod:SilverBar", group3);

            RecipeGroup group4 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 1 Hardmode Bar", new int[]
            {
                ItemID.PalladiumBar,
                ItemID.CobaltBar
            });
            RecipeGroup.RegisterGroup("HelMod:Tier1HardmodeBar", group4);
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (HelWorld.helMode)
            {
                if (NPC.AnyNPCs(NPCID.KingSlime))
                {
                    music = MusicID.TheTowers;
                    priority = MusicPriority.BossMedium;
                    
                }
                if (NPC.AnyNPCs(NPCID.EyeofCthulhu))
                {
                    music = MusicID.TheTowers;
                    priority = MusicPriority.BossMedium;

                }
            }

        }


    }

}


