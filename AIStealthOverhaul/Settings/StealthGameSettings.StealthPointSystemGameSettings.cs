using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class StealthPointSystemGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fCombatStealthPointDrainMult))]
            public FloatSetting fCombatStealthPointDrainMult = new();

            [SettingName(nameof(fCombatStealthPointRegenMult))]
            public FloatSetting fCombatStealthPointRegenMult = new();

            [SettingName(nameof(fCombatStealthPointRegenMin))]
            public FloatSetting fCombatStealthPointRegenMin = new();

            [SettingName(nameof(iCombatStealthPointDetectionThreshold))]
            public StructSetting<int> iCombatStealthPointDetectionThreshold = new();

            [SettingName(nameof(iCombatStealthPointSneakDetectionThreshold))]
            public StructSetting<int> iCombatStealthPointSneakDetectionThreshold = new();

            [SettingName(nameof(fCombatStealthPointAttackedMaxValue))]
            public FloatSetting fCombatStealthPointAttackedMaxValue = new();

            [SettingName(nameof(fCombatStealthPointDetectedEventMaxValue))]
            public FloatSetting fCombatStealthPointDetectedEventMaxValue = new();

            [SettingName(nameof(fCombatStealthPointMax))]
            public FloatSetting fCombatStealthPointMax = new();
        }
    }
}
