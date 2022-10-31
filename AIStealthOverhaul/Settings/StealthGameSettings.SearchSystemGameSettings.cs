using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class SearchSystemGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fCombatSearchExteriorRadiusMax))]
            public FloatSetting fCombatSearchExteriorRadiusMax = new();

            [SettingName(nameof(fCombatSearchExteriorRadiusMin))]
            public FloatSetting fCombatSearchExteriorRadiusMin = new();

            [SettingName(nameof(fCombatSearchInteriorRadiusMax))]
            public FloatSetting fCombatSearchInteriorRadiusMax = new();

            [SettingName(nameof(fCombatSearchInteriorRadiusMin))]
            public FloatSetting fCombatSearchInteriorRadiusMin = new();

            [SettingName(nameof(fCombatSearchSightRadius))]
            public FloatSetting fCombatSearchSightRadius = new();

            [SettingName(nameof(fCombatSearchInvestigateTime))]
            public FloatSetting fCombatSearchInvestigateTime = new();

            [SettingName(nameof(fCombatSearchLookTime))]
            public FloatSetting fCombatSearchLookTime = new();

            [SettingName(nameof(fCombatSearchStartWaitTime))]
            public FloatSetting fCombatSearchStartWaitTime = new();
        }
    }
}
