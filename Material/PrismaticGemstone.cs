using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Material
{
public class PrismaticGemstone: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 10;

			Item.value = Item.buyPrice(gold: 20); 
		}

    }
}