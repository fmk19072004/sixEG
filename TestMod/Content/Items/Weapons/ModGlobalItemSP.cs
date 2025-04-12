using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class ModGlobalItemSP : GlobalItem
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults(Item item)
        {
            if (item.type == 3506) 
            {
                item.useTime = 2;
                item.useAnimation = 2;
                item.damage = 1;
                item.autoReuse = true;
            }
            if (item.type == 3507)
            {
                item.knockBack = 20;
                item.autoReuse = true;
            }
            if (item.type == 3509)
            {
                item.useTime = 7;
                item.useAnimation = 7;
                item.autoReuse = true;
            }
            if (item.type == 674)
            {
                item.damage = 5;
            }
        }

    }
}
