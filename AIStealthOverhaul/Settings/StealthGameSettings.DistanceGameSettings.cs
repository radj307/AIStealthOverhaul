using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class DistanceGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fSneakMaxDistance))]
            public FloatSetting fSneakMaxDistance = new();

            [SettingName(nameof(fSneakExteriorDistanceMult))]
            public FloatSetting fSneakExteriorDistanceMult = new();

            [SettingName(nameof(fSneakFlyingDistanceMult))]
            public FloatSetting fSneakFlyingDistanceMult = new();

            [SettingName(nameof(fDetectProjectileDistanceNPC))]
            public FloatSetting fDetectProjectileDistanceNPC = new();

            [SettingName(nameof(fDetectProjectileDistancePlayer))]
            public FloatSetting fDetectProjectileDistancePlayer = new();

            [SettingName(nameof(fDetectEventDistanceNPC))]
            public FloatSetting fDetectEventDistanceNPC = new();

            [SettingName(nameof(fDetectEventDistancePlayer))]
            public FloatSetting fDetectEventDistancePlayer = new();

            [SettingName(nameof(iCrimeAlarmLowRecDistance))]
            public StructSetting<int> iCrimeAlarmLowRecDistance = new();

            [SettingName(nameof(iCrimeAlarmRecDistance))]
            public StructSetting<int> iCrimeAlarmRecDistance = new();

            [SettingName(nameof(fDeadReactionDistance))]
            public FloatSetting fDeadReactionDistance = new();
        }
    }
}
