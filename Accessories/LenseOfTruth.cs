using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using sixEG.Players;

namespace sixEG.Content.Items.Accessories
{
    public class LenseOfTruth : ModItem
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
            bool isFrameEquipped = false;
            bool isSpiritEquipped = false;

            for (int i = 3; i < 14; i++) {
                Item accessory = player.armor[i];
                if (accessory.type == ModContent.ItemType<MythicalFrame>()) {
                    isFrameEquipped = true;
                }
                if (accessory.type == ModContent.ItemType<SpiritOfCreation>()) {
                    isSpiritEquipped = true;
                }
            }

            if (isFrameEquipped && isSpiritEquipped) {
                if (!player.GetModPlayer<PerfectMirrorSetPlayer>().hasSetBonus) {
                    player.GetModPlayer<PerfectMirrorSetPlayer>().hasSetBonus = true;
                }
            } else {
                if (player.GetModPlayer<PerfectMirrorSetPlayer>().hasSetBonus)
                {
                    player.GetModPlayer<PerfectMirrorSetPlayer>().hasSetBonus = false;
                }
            }

            player.statDefense += 10;
        }
    }
}
