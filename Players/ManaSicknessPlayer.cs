using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;
using Terraria.GameInput;
using sixEG.Content.Items.Accessories;
public class ManaSicknessPlayer : ModPlayer
{
    public bool ManaSicknessReducer = false;
    private bool reductionApplied = false;
    public override void ResetEffects() {
        ManaSicknessReducer = false;
    }

    public override void PostUpdateBuffs() {
        for (int i = 0; i < 14; i++) {
            Item item = Player.armor[i];
            if (item != null && item.type == ModContent.ItemType<TomeOfSourcery>() && item.accessory) {
                ManaSicknessReducer = true;
                break;
            }
        }

        if (ManaSicknessReducer) {
            int index = Player.FindBuffIndex(BuffID.ManaSickness);
            if (index != -1 && Player.buffTime[index] > 0 && !reductionApplied) {
                Player.buffTime[index] = (int)(Player.buffTime[index] * 0.75); 
                reductionApplied = true;
            } else if (index == -1) {
                reductionApplied = false; //reset once buff is gone so next one can work properly
            }
        }
    }
}
