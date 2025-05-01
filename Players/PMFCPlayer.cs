using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;
using Terraria.GameInput;
using sixEG.Content.Items.Accessories;

namespace sixEG.Content.Players
{
    public class PMFCPlayer : ModPlayer
    {
        private bool transformed = false;
        private bool hasAccessoryEqipped = false;
        public override void ProcessTriggers(TriggersSet triggersSet) 
        {
            for (int i = 3; i < 14; i++) {
                Item accessory = Player.armor[i];
                if (accessory.type == ModContent.ItemType<ThreeEyes>()) {
                    hasAccessoryEqipped = true;
                }
            }

            if (Main.player[Main.myPlayer].active)
            {
            if (sixEG.PMFCHotkey.Current && !Player.HasBuff(ModContent.BuffType<TransformCooldown>()) && hasAccessoryEqipped)
            {
                Main.NewText("PMFCPlayer has detected the press of hotkey", Color.LimeGreen);
                Player.AddBuff(ModContent.BuffType<Transformed>(), 3000);
                Player.AddBuff(ModContent.BuffType<TransformCooldown>(), 7000);

                transformed = true;
            }
            }
        }
    }
}
