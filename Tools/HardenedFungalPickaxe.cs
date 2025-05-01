using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Tools
{ 

	public class HardenedFungalPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(silver: 76);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

            Item.pick = 120; //can mine t1 and t2 hardmode ore
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Tools.LivingFungalPickaxe>(), 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 23);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
	}
}
