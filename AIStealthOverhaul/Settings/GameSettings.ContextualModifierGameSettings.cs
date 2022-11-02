using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings
    {
        public class ContextualModifierGameSettings : IGameSettingsCategory
        {
            // TODO: Fix tooltips in ContextualModifierGameSettings

            [SettingName(nameof(fSneakAlertMod))]
            [Tooltip("adjusts detection performance when enemy is alert and searching, but not in combat. can use negative values. once an enemy is alert, values above \"0\" can cause sneak eye indicator to open at a rate depending on proximity to enemy, regardless of player action or cover, thus values higher than \"1\" can cause a bad \"wall-hacking\" NPC effect. high fPlayerDetectionSneakBase/Mult settings can limit this wall-hacking while the player is sneaking, but not while standing.\n\n(Vanilla: 0)")]
            public Setting<float> fSneakAlertMod = new();

            [SettingName(nameof(fSneakCombatMod))]
            [Tooltip("adjusts detection performance when enemy is in combat with someone else (negative values can simulate combat tunnel vision). unfortunately, this value is multiplied by enemy sneak skill, so high level enemes are affected much more (this means large negative values produce un-desireable results). it does not seem to affect wall-hacking (suprisingly). also feels a bit unreliable (when the engine considers NPCs \"in combat\" is a bit tempramental).\n\n(Default: -0.4)")]
            public Setting<float> fSneakCombatMod = new();

            [SettingName(nameof(fSneakSleepBonus))]
            [Tooltip("adjusts detection performance (mainly hearing ability in this case) when enemy is sleeping. negative values make enemies more deaf when sleeping. a value of zero (vanilla) means sleeping enemies hear just as well as when awake. values that are too low will cause NPCs to fail to wake up even when the player shouts \"fus roh dah\" right next to them.\n\n(Vanilla: 0)")]
            public Setting<float> fSneakSleepBonus = new();
        }
    }
}
