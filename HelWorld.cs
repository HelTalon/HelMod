using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace HelMod
{
    public class HelWorld : ModWorld
    {
        public static bool downedSupremeHelDrone;
        public static bool downedEnchantedKingSlime;
        public static bool helMode;

        public override void Initialize()
        {
            downedSupremeHelDrone = false;
            downedEnchantedKingSlime = false;
            helMode = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedSupremeHelDrone)
            {
                downed.Add("SupremeHelDrone");
            }
            if (downedEnchantedKingSlime)
            {
                downed.Add("EnchantedKingSlime");
            }
            if (helMode)
            {
                downed.Add("helMode");
            }

            return new TagCompound
            {
                ["downed"] = downed,
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedSupremeHelDrone = downed.Contains("SupremeHelDrone");
            downedEnchantedKingSlime = downed.Contains("EnchantedKingSlime");
            helMode = downed.Contains("helMode");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedSupremeHelDrone = flags[0];
                downedEnchantedKingSlime = flags[1];
                helMode = flags[2];
            }
            else
            {
                mod.Logger.WarnFormat("HelMod: Unknown loadVersion: {0}", loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(downedSupremeHelDrone);
            writer.Write(helMode);
            writer.Write(downedEnchantedKingSlime);
        }

        public override void NetReceive(BinaryReader reader)
        {
            downedSupremeHelDrone = reader.ReadBoolean();
            helMode = reader.ReadBoolean();
            downedEnchantedKingSlime = reader.ReadBoolean();
        }
    }

    
}