using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace sixEG.Content.Tiles
{
    public class CraftingStationTile : ModTile
    {
        public override void SetStaticDefaults()
        {
			Main.tileTable[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

            // Register the tile's use
            AddMapEntry(new Color(200, 200, 200), Language.GetText("ItemName.CraftingStation"));

            // Enable the use of this tile for crafting
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 18 };
            TileObjectData.addTile(Type);
        }
    }
}
