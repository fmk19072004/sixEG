using sixEG.Content.Items.Material;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables.LootBags.IntroFungus
{
    public class IntroFungusFungalBag : ModItem 
    {
        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 9999;
        }

        public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<FungalWood>(), 1, 11, 23)); 
            itemLoot.Add(ItemDropRule.Common(ItemID.Mushroom, 1, 5, 7));  
            itemLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 13, 21));     

		}

    }
}