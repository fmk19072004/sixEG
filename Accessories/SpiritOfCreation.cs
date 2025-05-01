using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace sixEG.Content.Items.Accessories
{
    public class SpiritOfCreation : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40; 
            Item.height = 40;
            Item.accessory = true; // flag item ass accessory
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Purple; 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 3;
            player.statLifeMax2 += 40;
            player.statManaMax2 += 100;
            player.lifeRegen *= 2;
            player.manaRegen *= 4;
        }
    }
}
