using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace sixEG.Content.Items.Weapons.UpgradableWeapons.EnergeticMachineGun
{ 

	public class EnergeticMachineGunMK2 : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.sixEG.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 35;  //mk 1 is 24
			Item.DamageType = DamageClass.Ranged;
			Item.width = 76;
			Item.height = 32;
			Item.useTime = 3;  //mk1 is 4
			Item.useAnimation = 3;  //mk1 is 4
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(silver: 12);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
        	Item.noMelee = true; 
            Item.shoot = ModContent.ProjectileType<EnergeticBullet>();
            Item.shootSpeed = 35f;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Vector2 offset = Vector2.Normalize(velocity) * 26f;
			position += offset;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 4); //hold spirte closer to body so it lines up with how you would actually hold a gun instead of flying in fromt of you
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EnergeticMachineGunMK1>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.ProgressionItems.UpgradeModules.UpgradeModuleOne>(), 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}

	}
}
