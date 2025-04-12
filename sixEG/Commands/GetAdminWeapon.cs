using Terraria.ModLoader;
using Terraria;

namespace sixEG.Commands
{
    public class GetAdminWeapon : ModCommand
    {
        public override CommandType Type => CommandType.Chat | CommandType.Console;
        public override string Command => "adminweapon"; 
        public override string Description => "It makes big boom";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            int itemType = ModContent.ItemType<Content.Items.Weapons.AdminWeapon>();
            caller.Player.QuickSpawnItem(caller.Player.GetSource_GiftOrReward(), itemType);
            caller.Reply("adminweapon added to inventory");
        }
    }
}
