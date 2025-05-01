using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables.LootBags.IntroFungus
{
    public class IntroFungusPotionBag : ModItem 
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
            itemLoot.Add(ItemDropRule.Common(ItemID.LesserHealingPotion, 1, 3, 5)); 
            itemLoot.Add(ItemDropRule.Common(ItemID.LesserManaPotion, 1, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.RecallPotion, 1, 3, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.ThornsPotion, 2, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ItemID.IronskinPotion, 2, 1, 2));            
		}

    }
}