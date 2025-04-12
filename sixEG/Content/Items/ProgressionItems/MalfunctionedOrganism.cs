using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.ProgressionItems
{
public class MalfunctionedOrganism : ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 32; 

			Item.maxStack = Item.CommonMaxStack; 
			Item.value = Item.buyPrice(gold: 10); 
		}

    }
}