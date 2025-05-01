using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Weapons
{ 

	public class AugmentedAmethystStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;   //15 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4; //3.25 on og
			Item.value = Item.buyPrice(silver: 57);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //false on og
            Item.shoot = ProjectileID.AmethystBolt;
            Item.mana = 7; //5 on og
            Item.shootSpeed = 6.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AmethystStaff, 1);
            recipe.AddIngredient(ItemID.LargeAmethyst, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	public class AugmentedTopazStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 18;   //16 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.25f; //3.5 on og
			Item.value = Item.buyPrice(silver: 59);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //false on og
            Item.shoot = ProjectileID.TopazBolt;
            Item.mana = 7; //5 on og
            Item.shootSpeed = 6.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TopazStaff, 1);
            recipe.AddIngredient(ItemID.LargeTopaz, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	public class AugmentedSapphireStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22;   //18 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5; //4 on og
			Item.value = Item.buyPrice(gold: 1, silver: 94);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //true on og
            Item.shoot = ProjectileID.SapphireBolt;
            Item.mana = 8; //6 on og
            Item.shootSpeed = 7.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SapphireStaff, 1);
            recipe.AddIngredient(ItemID.LargeSapphire, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	public class AugmentedEmeraldStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22;   //19 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6; //4.25 on og
			Item.value = Item.buyPrice(gold: 2, silver: 72);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //true on og
            Item.shoot = ProjectileID.EmeraldBolt;
            Item.mana = 8; //6 on og
            Item.shootSpeed = 8;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EmeraldStaff, 1);
            recipe.AddIngredient(ItemID.LargeEmerald, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	public class AugmentedAmberStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 27;   //21 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6.5f; //4.75 on og
			Item.value = Item.buyPrice(gold: 5, silver: 17);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //true on og
            Item.shoot = ProjectileID.AmberBolt;
            Item.mana = 10; //7 on og
            Item.shootSpeed = 9;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AmberStaff, 1);
            recipe.AddIngredient(ItemID.LargeAmber, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	public class AugmentedRubyStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 27;   //21 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 19;
			Item.useAnimation = 19;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6.5f; //4.75 on og
			Item.value = Item.buyPrice(gold: 5, silver: 17);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //true on og
            Item.shoot = ProjectileID.RubyBolt;
            Item.mana = 10; //7 on og
            Item.shootSpeed = 9;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RubyStaff, 1);
            recipe.AddIngredient(ItemID.LargeRuby, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}

	public class AugmentedDiamondStaff : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 30;   //23 on og
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7.5f; //5.5 on og
			Item.value = Item.buyPrice(gold: 5, silver: 35);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true; //true on og
            Item.shoot = ProjectileID.DiamondBolt;
            Item.mana = 11; //8 on og
            Item.shootSpeed = 9.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DiamondStaff, 1);
            recipe.AddIngredient(ItemID.LargeDiamond, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
