using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Material
{
public class RawMeat: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(copper: 12); 
		}

    }
}