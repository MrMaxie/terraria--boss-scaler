using Terraria.ModLoader.Config;

namespace BossScaler
{
    public class BossScalerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [LabelKey("$Mods.BossScaler.Config.BossDamageMultiplier.Label")]
        [TooltipKey("$Mods.BossScaler.Config.BossDamageMultiplier.Tooltip")]
        [Range(0.1f, 20f)]
        public float BossDamageMultiplier { get; set; } = 1f;

        [LabelKey("$Mods.BossScaler.Config.BossHPMultiplier.Label")]
        [TooltipKey("$Mods.BossScaler.Config.BossHPMultiplier.Tooltip")]
        [Range(0.1f, 20f)]
        public float BossHPMultiplier { get; set; } = 1f;
    }
}