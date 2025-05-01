using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;

namespace sixEG.Content.Items.Accessories
{
    public class MythicalFrame : ModItem
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
            player.statDefense += 21;
            player.maxMinions += 1;
            player.maxTurrets += 1;
        }
    }
}
