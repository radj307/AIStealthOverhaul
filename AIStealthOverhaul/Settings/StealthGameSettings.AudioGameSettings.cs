using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class AudioGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fSneakSoundsMult))]
            [Tooltip("Multiplier that controls how detectable sounds are, and thus determines how far away enemies can detect sound sources.\n" +
                "Higher values mean enemies can hear sounds further away.\n" +
                "Enemies are never able to detect sound sources that are beyond the maximum distance set by `fSneakMaxDistance`.\n\n(Vanilla: 1)")]
            public FloatSetting fSneakSoundsMult = new();

            [SettingName(nameof(fSneakSoundLosMult))]
            [Tooltip("Multiplier that controls how well enemies can hear sounds through walls.\n" +
                "Values less than `1.0` make it harder for enemies to hear through walls, while values greater than `1.0` make it easier.\n\n" +
                "Note that the game engine only checks whether there IS a wall between an NPC and a sound source, it does NOT check what the wall is made of.\n" +
                "That means the game engine treats the wall of a tent the same way as the wall of a house or keep.\n\n(Vanilla: 0.3)")]
            public FloatSetting fSneakSoundLosMult = new();

            [SettingName(nameof(fSneakEquippedWeightBase))]
            [Tooltip("The initial value when calculating how much noise an actor makes when moving, this specifies the minimum possible amount of noise made by moving.\n" +
                "Higher values increase the amount of sound made by moving.\n\n(Vanilla: 12)")]
            public FloatSetting fSneakEquippedWeightBase = new();

            [SettingName(nameof(fSneakEquippedWeightMult))]
            [Tooltip("Multiplier that controls how much easier it is to detect someone with heavy equipped gear.\n" +
                "This only affects the weight of EQUIPPED gear. (Carry weight is NOT checked by the stealth system, unless you're overencumbered.)\n\n(Vanilla: 0.5)")]
            public FloatSetting fSneakEquippedWeightMult = new();

            [SettingName(nameof(fSneakActionMult))]
            [Tooltip("how loud non-movement sounds are, and thus how far away they are heard and how much they open the sneak eye indicator.\n" +
                "includes melee weapon attacks (even if they only hit air), spell casting sounds, and projectile impacts etc.\n" +
                "NOTE: despite being a \"float\", it strangely seems to behave like an \"integer\" that rounds down to the nearest whole number (eg: 1.9 = 1.0), and any value below 1 is interpreted as 1.")]
            public FloatSetting fSneakActionMult = new();

            [SettingName(nameof(fSneakRunningMult))]
            public FloatSetting fSneakRunningMult = new();
        }
    }
}
