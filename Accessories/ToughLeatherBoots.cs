using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;


namespace sixEG.Content.Items.Accessories
{
    public class ToughLeatherBoots : ModItem
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
            player.moveSpeed += .02f;  //base is 1 so this adds 2% of base
            player.GetModPlayer<Content.Players.KnockbackResistPlayer>().knockbackReduction += 0.15f;
        }
    }
}
