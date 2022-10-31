using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class SkillSystemGameSettings : IGameSettingsCategory
        {

            [SettingName(nameof(fSneakSkillMult))]
            public FloatSetting fSneakSkillMult = new();

            [SettingName(nameof(fPlayerDetectionSneakMult))]
            public FloatSetting fPlayerDetectionSneakMult = new();

            [SettingName(nameof(fPlayerDetectionSneakBase))]
            public FloatSetting fPlayerDetectionSneakBase = new();

            [SettingName(nameof(fSneakPerceptionSkillMax))]
            public FloatSetting fSneakPerceptionSkillMax = new();

            [SettingName(nameof(fSneakPerceptionSkillMin))]
            public FloatSetting fSneakPerceptionSkillMin = new();

        }
    }
}
