using System;
using sixEG.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables
{
    public class Doreo : ModItem
    {
        private static Random random = new Random();
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.consumable = true;
        }

        public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

        public override bool? UseItem(Player player)
        {
            int roll = random.Next(0,100);

            if (roll < 80) {
                player.AddBuff(ModContent.BuffType<DoreoBuffGood>(), DoreoBuffGood.BuffDuration); //80% chance for good buff
            } else {
                player.AddBuff(ModContent.BuffType<DoreoBuffBad>(), DoreoBuffBad.BuffDuration); //20% chance for bad buff
            }           
            return true;
        }
    }
}
