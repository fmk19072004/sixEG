
using System;
using sixEG.Content.Buffs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using sixEG.Content.Items.Placeable;
using sixEG.Content.Tiles;
using sixEG.Content.Items.Material;

namespace sixEG.Content.Items.Consumables
{
    
public class GreaterMutatedHealingPotion : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;
        Item.maxStack = 9999;
        Item.value = Item.buyPrice(0, 2, 40, 0);
        Item.rare = ItemRarityID.Yellow;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useTime = 17;
        Item.useAnimation = 17;
        Item.consumable = true;

        Item.UseSound = SoundID.Item3;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.HasBuff(BuffID.PotionSickness)) {
            return false;
        } else {
            return true;
        }
    }

    public override bool? UseItem(Player player)
    {
        int healAmount = 225;

        player.statLife += healAmount;
        player.HealEffect(healAmount);

        player.AddBuff(BuffID.PotionSickness, 48 * 60); //48 seconds

        return true;
    }

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 25;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.SuperHealingPotion, 3);
        recipe.AddIngredient(ItemID.BottledHoney, 3);
        recipe.AddIngredient(ItemID.PixieDust, 5);
        recipe.AddIngredient(ModContent.ItemType<TransmutationCatalyst>(), 1);
        recipe.AddTile(ModContent.TileType<ResearchStationTile>());
        recipe.Register();
    }
}
}