using Terraria.ModLoader.Config;

namespace BossScaler
{
    public class BossScalerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [LabelKey("$Mods.BossScaler.Config.BossDamageMultiplier.Label")]
        [TooltipKey("$Mods.BossScaler.Config.BossDamageMultiplier.Tooltip")]
        [Range(0.1f, 10f)]
        public float BossDamageMultiplier { get; set; }

        [LabelKey("$Mods.BossScaler.Config.BossHPMultiplier.Label")]
        [TooltipKey("$Mods.BossScaler.Config.BossHPMultiplier.Tooltip")]
        [Range(0.1f, 20f)]
        public float BossHPMultiplier { get; set; }

        private static float ToRange(float value, float min, float max, float? def)
        {
            if (value < min)
            {
                return def ?? min;
            }
            if (value > max)
            {
                return def ?? max;
            }
            return value;
        }

        private void EnsureValidValues()
        {
            BossDamageMultiplier = ToRange(BossDamageMultiplier, 0.1f, 10f, 1f);
            BossHPMultiplier = ToRange(BossHPMultiplier, 0.1f, 20f, 1f);
        }

        public override void OnChanged()
        {
            EnsureValidValues();
        }

        public override void OnLoaded()
        {
            EnsureValidValues();
        }

        public override bool NeedsReload(ModConfig pendingConfig) => false;
    }
}