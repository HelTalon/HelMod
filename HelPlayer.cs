using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace HelMod
{
    public class HelPlayer : ModPlayer
    {
        public bool strongPlasma = false;
        public override void ResetEffects()
        {
            strongPlasma = false;
        }

    }
}