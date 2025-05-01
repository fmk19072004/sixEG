using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables.LootBags.IntroFungus
{
    public class IntroFungusSpecialBag : ModItem 
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
            itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 12, 25));
            itemLoot.Add(ItemDropRule.Common(ItemID.SuspiciousLookingEye, 2, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ItemID.FriedEgg, 3, 1, 2));

            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.Snail,
                ItemID.Snail,
                ItemID.Worm
            )); 

            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            ));  
            
            itemLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.Apple,
                ItemID.BloodOrange,
                ItemID.Peach,
                ItemID.Cherry,
                ItemID.Apricot,
                ItemID.Lemon
            ));         
		}

    }
}