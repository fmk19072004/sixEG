using System;
using sixEG.Content.Buffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace sixEG.Content.Items.Consumables
{
    public class AngelBlood : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 15;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.consumable = true;
            Item.buffTime = 7 * 60;
        }

        public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 1;
		}

        public override bool? UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.RapidHealingBuffDivine>(), Item.buffTime); 
            SoundEngine.PlaySound(SoundID.Item4);

            return true;
        }
    }
}
