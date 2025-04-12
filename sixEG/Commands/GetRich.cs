using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace sixEG.Commands
{
    public class GetRich : ModCommand
    {
        public override CommandType Type => CommandType.Chat | CommandType.Console;
        public override string Command => "riches"; 
        public override string Description => "Fills up your wallet";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            int itemType = ItemID.PlatinumCoin;
            int quantity = 5000;

            caller.Player.QuickSpawnItem(caller.Player.GetSource_GiftOrReward(), itemType, quantity);
            caller.Reply("Bank Irrtum zu Ihren Gunsten");
        }
    }
}
