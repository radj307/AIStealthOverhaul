using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings
    {
        public class TimerGameSettings : IGameSettingsCategory
        {
            // TODO: Fix tooltips in TimerGameSettings

            [SettingName(nameof(fCombatStealthPointRegenAlertWaitTime))]
            [Tooltip("how long enemies search if they only partly detect you (and you did not attack them). add partial eye closing time.\n\n(Vanilla: 10)")]
            public Setting<float> fCombatStealthPointRegenAlertWaitTime = new();

            [SettingName(nameof(fCombatStealthPointRegenDetectedEventWaitTime))]
            [Tooltip("how long enemies search if a detection event (projectile impact or dead body found etc) happened (and you did not attack them). sometimes this timer is replaced by \"AlertWaitTime\" if set lower than it. sometimes add \"fDetectionEventExpireTime\" to this value. add partial eye closing time.\n\n(Vanilla: 10)")]
            public Setting<float> fCombatStealthPointRegenDetectedEventWaitTime = new();

            [SettingName(nameof(fCombatStealthPointRegenAttackedWaitTime))]
            [Tooltip("how long enemy searches after you shot them (but they did not fully detect you). add partial eye closing time.\n\n(Vanilla: 15)")]
            public Setting<float> fCombatStealthPointRegenAttackedWaitTime = new();

            [SettingName(nameof(fCombatStealthPointRegenLostWaitTime))]
            [Tooltip("how long enemy searches after being in combat with you but losing track of you. this is the 3rd timer after breaking line-of-sight. the 2 GMSTs directly below add to this timer, so total search time is usually 5-20 seconds higher than value set here. and, add full eye closing time (15 in vanilla, 40 in RAID) for grand total search time of ~40 sec in vanilla and ~70 in RAID..\n\n(Vanilla: 10)")]
            public Setting<float> fCombatStealthPointRegenLostWaitTime = new();

            [SettingName(nameof(fCombatDetectionLostTimeLimit))]
            [Tooltip("2nd timer after breaking line-of-sight. during this time NPCs exibit a semi-wall-hack ability. only ranged enemies use this, in addition to the 1st timer (when the first timer lapses, melee enemies skip this 2nd timer). after this timer lapses, all time-based wall-hack effects end. if the player moves more than 10m during this timer it lapses. Extremely high values (as used by the Immersive Citizens mod) can cause serious bugs.\n\n(Vanilla: 10)")]
            public Setting<float> fCombatDetectionLostTimeLimit = new();

            [SettingName(nameof(fCombatDetectionNoticedTimeLimit))]
            [Tooltip("1st timer after breaking line-of-sight. during this time NPCs exibit a FULL wall-hack ability. if the player moves more than 10m during this timer it lapses.\n\n(Vanilla: 10)")]
            public Setting<float> fCombatDetectionNoticedTimeLimit = new();

            [SettingName(nameof(fActorAlertSoundTimer))]
            [Tooltip("this timer is triggered by spell-casting and melee weapon swings (but not bows). during this time the sneak eye indicator opens (at a rate depending on loudness of source, fCombatStealthPointDrainMult, and distance to enemy). unfortunately, this effect fully ignores walls (Bethesda, what were you smoking???).\n\n(Vanilla: 5)")]
            public Setting<float> fActorAlertSoundTimer = new();

            [SettingName(nameof(fDetectionEventExpireTime))]
            [Tooltip("similar to fActorAlertSoundTimer. defines how long after a detection event (projectile impact) NPCs can detect it if they did not initially. this allows an enemy who did not hear the impact because they were walking past a solid object (like a pillar) to still notice the event if the solid object no longer blocks the sound within this timer limit. this also helps Skyrim get away with very low polling rates for checking if NPCs notice events\n\n(Vanilla: 5)")]
            public Setting<float> fDetectionEventExpireTime = new();
        }
    }
}
