using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables
{
    public class HoloFungusSummon : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(0, 0, 12, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.HoloFungus>());
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Content.Items.ProgressionItems.EvilSpores>(), 1);
            recipe.AddIngredient(ItemID.Gel, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
