using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings
    {
        public class StealthPointSystemGameSettings : IGameSettingsCategory
        {
            // TODO: Fix tooltips in StealthPointSystemGameSettings

            [SettingName(nameof(fCombatStealthPointDrainMult))]
            [Tooltip("when visual or audio factors are causing stealth point loss (sneak eye is opening), this multiples that loss. the multiplying effect can be a bit inconsistent at times though (seemingly due to some sort of hidden threshold of visual detection, usually when moving, not sure). see also fSneakActionMult if you want to adjust the effect of spellcasting on detection.\n\n(Vanilla: 3)")]
            public Setting<float> fCombatStealthPointDrainMult = new();

            [SettingName(nameof(fCombatStealthPointRegenMult))]
            [Tooltip("affects sneak eye indicator closing speed. not sure, but seems to multiply the effect of player sneak skill level on eye closing speed. lower it to increase eye closing time. has no effect on general formula balance (this does not compete with visual/audio detection power).\n\n(Default: 0.2)")]
            public Setting<float> fCombatStealthPointRegenMult = new();

            [SettingName(nameof(fCombatStealthPointRegenMin))]
            [Tooltip("affects sneak eye indicator closing speed. this controls the minimum closing speed. lower it to increase eye closing time. has no effect on general formula balance (this does not compete with visual/audio detection power). the vanilla min+mult values cause sneak eye to close in ~15sec, RAID values result in ~40sec)\n\n(Vanilla: 5)")]
            public Setting<float> fCombatStealthPointRegenMin = new();

            [SettingName(nameof(iCombatStealthPointDetectionThreshold))]
            [Tooltip("if the sneak eye indicator opens faster than this value per second while you are out of sneak mode, enemy will instantly detect and attack you, bypassing the \"search\" mode. the vanilla value of 25 (combined with the extremely high vanilla fSneakSkillMult value) is very unforgiving, resulting in machine-like reaction speeds from enemies. vanilla needs to do this to compensate for detection generally being so weak. higher values for this GMST can simulate more Friend-Foe-Identification (FFI) behavior in NPCs - a slower reaction time with a second or two of hesitation. however, values that are too high, will fully disable the appropriate taunts enemies say to you when they instantly detect you. RAID attempts a compromise.\n\n(Vanilla: 25)")]
            public Setting<int> iCombatStealthPointDetectionThreshold = new();

            [SettingName(nameof(iCombatStealthPointSneakDetectionThreshold))]
            [Tooltip("same as above, but when sneaking.\n\n(Vanilla: 70)")]
            public Setting<int> iCombatStealthPointSneakDetectionThreshold = new();

            [SettingName(nameof(fCombatStealthPointAttackedMaxValue))]
            [Tooltip("max amount of stealth points that can remain after the player has successfully attacked an enemy (missing with an arrow does not count). a value of \"50\" means the sneak eye is forced half way open after the attack. if it was already open that much, nothing happens.\n\n(Vanilla: 50)")]
            public Setting<float> fCombatStealthPointAttackedMaxValue = new();

            [SettingName(nameof(fCombatStealthPointDetectedEventMaxValue))]
            [Tooltip("max amount of stealth points that can remain after an enemy notices the missed shot from an arrow or spell. a value of \"75\" means the sneak eye is forced open a quarter. if it was already open that much, nothing happens.\n\n(Vanilla: 75)")]
            public Setting<float> fCombatStealthPointDetectedEventMaxValue = new();

            [SettingName(nameof(fCombatStealthPointMax))]
            [Tooltip("(I did not properly test this) assumed to control the max amount of stealth points the player can have (when no one is detecting them).\n\n(Vanilla: 100)")]
            public Setting<float> fCombatStealthPointMax = new();
        }
    }
}
