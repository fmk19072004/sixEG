using sixEG.Content.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;




namespace sixEG.Content.Items.Summoners.TheTizard
{
    public class MagicSeal : ModItem
    {

        public int turnCount = 0;  //the tizard grows in strength every turn

        public override void SetDefaults()
        {
            Item.width = 40; 
            Item.height = 40; 
            Item.useStyle = ItemUseStyleID.HoldUp; 
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item44;
            //Item.shoot = ModContent.ProjectileType<TheTizard>();
            //Item.buffType = ModContent.BuffType<TizardBuff>(); 
            Item.buffTime = 3600; 
            Item.DamageType = DamageClass.Summon; 
            Item.mana = 10; 
            Item.rare = ItemRarityID.Green; 
            Item.value = Item.buyPrice(0, 0, 1, 0);
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI != Main.myPlayer)
                return true;

            bool hasTizard = false;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile proj = Main.projectile[i];
                if (proj.active && proj.owner == player.whoAmI && proj.type == ModContent.ProjectileType<TheTizard>())
                {
                    hasTizard = true;
                    break;
                }
            }

            // If no Tizard is found, summon one and apply the buff
            if (!hasTizard)
            {
                turnCount++;
                Projectile.NewProjectile(
                    Item.GetSource_FromThis(),
                    player.Center,
                    Vector2.Zero,
                    ModContent.ProjectileType<TheTizard>(),
                    0,
                    0,
                    player.whoAmI,
                    ai0: turnCount
                );

                player.AddBuff(ModContent.BuffType<TizardBuff>(), Item.buffTime);
            }
            else
            {
                Main.NewText("The Tizard is already active!");
            }

            return true;
        }


        public override ModItem Clone(Item item)
        {
            var clone = (MagicSeal)base.Clone(item);
            clone.turnCount = turnCount;
            return clone;
        }

        public override void SaveData(TagCompound tag)
        {
            tag["turnCount"] = turnCount;
        }

        public override void LoadData(TagCompound tag)
        {
            turnCount = tag.GetInt("turnCount");
        }

        //probably don't want this item to just be craftable but for now this is fine
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

                recipe.AddIngredient(ItemID.Wood, 10);
                recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
                recipe.Register();
        }
    }
}
