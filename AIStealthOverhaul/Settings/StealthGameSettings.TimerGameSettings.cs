using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class TimerGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fCombatStealthPointRegenAlertWaitTime))]
            public FloatSetting fCombatStealthPointRegenAlertWaitTime = new();

            [SettingName(nameof(fCombatStealthPointRegenDetectedEventWaitTime))]
            public FloatSetting fCombatStealthPointRegenDetectedEventWaitTime = new();

            [SettingName(nameof(fCombatStealthPointRegenAttackedWaitTime))]
            public FloatSetting fCombatStealthPointRegenAttackedWaitTime = new();

            [SettingName(nameof(fCombatStealthPointRegenLostWaitTime))]
            public FloatSetting fCombatStealthPointRegenLostWaitTime = new();

            [SettingName(nameof(fCombatDetectionLostTimeLimit))]
            public FloatSetting fCombatDetectionLostTimeLimit = new();

            [SettingName(nameof(fCombatDetectionNoticedTimeLimit))]
            public FloatSetting fCombatDetectionNoticedTimeLimit = new();

            [SettingName(nameof(fActorAlertSoundTimer))]
            public FloatSetting fActorAlertSoundTimer = new();

            [SettingName(nameof(fDetectionEventExpireTime))]
            public FloatSetting fDetectionEventExpireTime = new();
        }
    }
}
