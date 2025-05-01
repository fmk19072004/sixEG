using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace sixEG.Content.Items.Unobtainables
{
public class PreBossPickImage: ModItem
	{
        private int frame;
        private int frameCounter;
        public override void SetStaticDefaults()
        {
            
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(20, 12));

            
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(platinum: 1000); 
		}

        public override void PostUpdate()
        {
        
            frameCounter++;

        
            if (frameCounter >= 20) 
            {
                frameCounter = 0;
                frame++;


                if (frame >= 12)
                {
                    frame = 0;
                }
            }
        }
    }
}