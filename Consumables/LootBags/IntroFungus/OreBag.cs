using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables.LootBags.IntroFungus
{
    public class IntroFungusOreBag : ModItem 
    {
        public int valuableOre = 0;
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

        public override void RightClick(Player player)
        {
            valuableOre = Main.rand.NextBool() ? ItemID.GoldOre : ItemID.PlatinumOre;
            
            //following quickspawns give either of the 2 in some quantity
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), Main.rand.NextBool() ? ItemID.CopperOre : ItemID.TinOre, Main.rand.Next(16, 33));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), Main.rand.NextBool() ? ItemID.IronOre : ItemID.LeadOre, Main.rand.Next(12, 25)); 
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), Main.rand.NextBool() ? ItemID.GoldOre : ItemID.PlatinumOre, Main.rand.Next(8, 25));
            
        }

		public override void ModifyItemLoot(ItemLoot itemLoot) {
            //empty because of the quickspawn, but use this in other bags
		}

    }
}