using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossScaler
{
    public class BossScalerGlobalNPC : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            var config = ModContent.GetInstance<BossScalerConfig>();

            if (npc.boss) {
                ScaleNPC(npc, config);
                return;
            }

            if (IsBossMinion(npc) || IsMobUsedDuringBossFight(npc)) {
                ScaleNPC(npc, config, 0.25f);
            }
        }

        private static int AdjustValue(int value, float multiplier, float closerOneBy)
        {
            if (closerOneBy != 0f)
            {
                if (multiplier > 1f)
                {
                    multiplier = 1f + (multiplier - 1f) * closerOneBy;
                }
                else
                {
                    multiplier = 1f - (1f - multiplier) * closerOneBy;
                }
            }

            return Math.Max(1, (int)(value * multiplier));
        }

        private static void ScaleNPC(NPC npc, BossScalerConfig config, float closerOneBy = 0f)
        {
            npc.lifeMax = AdjustValue(npc.lifeMax, config.BossHPMultiplier, closerOneBy);
            npc.life = npc.lifeMax;
            npc.damage = AdjustValue(npc.damage, config.BossDamageMultiplier, closerOneBy);
        }

        private static readonly Dictionary<int, HashSet<int>> MobsUsedDuringBossFight = new()
        {
            {
                NPCID.KingSlime,
                [
                    NPCID.BlueSlime,
                    NPCID.SlimeSpiked,
                ]
            },
            {
                NPCID.QueenBee,
                [
                    NPCID.Bee,
                    NPCID.BeeSmall,
                ]
            },
            {
                NPCID.Plantera,
                [
                    NPCID.Spore,
                ]
            },
            {
                NPCID.Golem,
                [
                    NPCID.Lihzahrd,
                    NPCID.LihzahrdCrawler,
                ]
            },
            {
                NPCID.DukeFishron,
                [
                    NPCID.Sharkron,
                    NPCID.Sharkron2,
                ]
            }
        };

        private static bool IsMobUsedDuringBossFight(NPC npc)
        {
            var aliveBosses = Main.npc.Where(n => n.active && n.boss).Select(n => n.type);
            return MobsUsedDuringBossFight.Any(kvp => aliveBosses.Contains(kvp.Key) && kvp.Value.Contains(npc.type));
        }

        private static readonly HashSet<int> BossMinions =
        [
            // Kind Slime
            // --

            // Eye of Cthulhu
            NPCID.ServantofCthulhu,

            // Eater of Worlds
            NPCID.EaterofWorldsBody,
            NPCID.EaterofWorldsHead,
            NPCID.EaterofWorldsTail,

            // Brain of Cthulhu
            NPCID.Creeper,

            // Queen Bee
            // --

            // Skeletron
            NPCID.SkeletronHand,

            // Deerclops
            // --

            // Wall of Flesh
            NPCID.TheHungry,
            NPCID.TheHungryII,
            NPCID.LeechHead,
            NPCID.LeechBody,
            NPCID.LeechTail,

            // Queen Slime
            NPCID.QueenSlimeMinionBlue,
            NPCID.QueenSlimeMinionPink,
            NPCID.QueenSlimeMinionPurple,

            // The Twins
            NPCID.Spazmatism,
            NPCID.Retinazer,

            // The Destroyer
            NPCID.TheDestroyerBody,
            NPCID.TheDestroyerTail,
            NPCID.Probe,

            // Skeletron Prime
            NPCID.PrimeCannon,
            NPCID.PrimeSaw,
            NPCID.PrimeVice,
            NPCID.PrimeLaser,

            // Mechdusa
            // --

            // Plantera
            NPCID.PlanterasHook,
            NPCID.PlanterasTentacle,

            // Golem
            NPCID.GolemFistLeft,
            NPCID.GolemFistRight,
            NPCID.GolemHead,
            NPCID.GolemHeadFree,

            // Duke Fishron
            // --

            // Empress of Light
            // --

            // Lunatic Cultist
            NPCID.CultistBossClone,
            NPCID.CultistArcherBlue,
            NPCID.CultistArcherWhite,
            NPCID.CultistDevote,
            NPCID.CultistDragonBody1,
            NPCID.CultistDragonBody2,
            NPCID.CultistDragonBody3,
            NPCID.CultistDragonBody4,
            NPCID.CultistDragonHead,

            // Pre Moon Lord - Stardust
            NPCID.StardustCellBig,
            NPCID.StardustCellSmall,
            NPCID.StardustJellyfishBig,
            NPCID.StardustJellyfishSmall,
            NPCID.StardustSpiderBig,
            NPCID.StardustSpiderSmall,
            NPCID.StardustSoldier,
            NPCID.StardustWormBody,
            NPCID.StardustWormHead,
            NPCID.StardustWormTail,
            NPCID.LunarTowerStardust,

            // Pre Moon Lord - Nebula
            NPCID.NebulaBeast,
            NPCID.NebulaBrain,
            NPCID.NebulaHeadcrab,
            NPCID.NebulaSoldier,
            NPCID.LunarTowerNebula,

            // Pre Moon Lord - Vortex
            NPCID.VortexHornetQueen,
            NPCID.VortexHornet,
            NPCID.VortexLarva,
            NPCID.VortexRifleman,
            NPCID.VortexSoldier,
            NPCID.LunarTowerVortex,

            // Pre Moon Lord - Solar
            NPCID.SolarCorite,
            NPCID.SolarCrawltipedeHead,
            NPCID.SolarCrawltipedeBody,
            NPCID.SolarCrawltipedeTail,
            NPCID.SolarDrakomire,
            NPCID.SolarDrakomireRider,
            NPCID.SolarFlare,
            NPCID.SolarGoop,
            NPCID.SolarSroller,
            NPCID.SolarSolenian,
            NPCID.SolarSpearman,
            NPCID.LunarTowerSolar,

            // Mood Lord
            NPCID.MoonLordCore,
            NPCID.MoonLordHand,
            NPCID.MoonLordHead,
            NPCID.MoonLordLeechBlob,
            NPCID.MoonLordFreeEye,
        ];

        private static bool IsBossMinion(NPC npc) => BossMinions.Contains(npc.type);
    }
}