using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class ContextualModifierGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fSneakAlertMod))]
            public FloatSetting fSneakAlertMod = new();

            [SettingName(nameof(fSneakCombatMod))]
            public FloatSetting fSneakCombatMod = new();

            [SettingName(nameof(fSneakSleepBonus))]
            public FloatSetting fSneakSleepBonus = new();
        }
    }
}
