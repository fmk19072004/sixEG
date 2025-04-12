using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace sixEG.Commands
{
    public class ClearTrash : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "cleartrash";
        public override string Description => "Destroys every item from yur inventoy except those related to the BTD6EG mod (and coins).";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = caller.Player;
            Mod mod = Mod; // mod mod mod :)
            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item item = player.inventory[i];

                if (item.IsAir) 
                    continue;

                if (item.type == ItemID.CopperCoin || 
                    item.type == ItemID.SilverCoin || 
                    item.type == ItemID.GoldCoin || 
                    item.type == ItemID.PlatinumCoin)
                    continue;

                if (item.ModItem != null && item.ModItem.Mod == mod)
                    continue;

                player.inventory[i].TurnToAir();
            }

            caller.Reply("Begone, useless trash.");
        }
    }
}
