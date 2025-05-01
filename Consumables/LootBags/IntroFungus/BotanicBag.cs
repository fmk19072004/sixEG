using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables.LootBags.IntroFungus
{
    public class IntroFungusBotanicBag : ModItem 
    {
        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.Purple;
  
        }

        public override bool CanRightClick() {
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) {
            itemLoot.Add(ItemDropRule.Common(ItemID.GrassSeeds, 1, 3, 9));  // 3-9 with 6 avrg
            itemLoot.Add(ItemDropRule.Common(ItemID.Mushroom, 1, 4, 6));
            itemLoot.Add(ItemDropRule.Common(ItemID.ViciousMushroom, 2, 1, 3));
            itemLoot.Add(ItemDropRule.Common(ItemID.Daybloom, 2, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Blinkroot, 2, 3, 5));
		}

    }
}