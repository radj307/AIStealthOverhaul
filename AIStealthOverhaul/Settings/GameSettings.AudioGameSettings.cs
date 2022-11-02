using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings
    {
        public class AudioGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fSneakSoundsMult))]
            [Tooltip("Multiplier that controls how detectable sounds are, and thus determines how far away enemies can detect sound sources.\n" +
                "Higher values mean enemies can hear sounds further away.\n" +
                "Enemies are never able to detect sound sources that are beyond the maximum distance set by `fSneakMaxDistance`.\n\n(Vanilla: 1)")]
            public Setting<float> fSneakSoundsMult = new();

            [SettingName(nameof(fSneakSoundLosMult))]
            [Tooltip("Multiplier that controls how well enemies can hear sounds through walls.\n" +
                "Values less than `1.0` make it harder for enemies to hear through walls, while values greater than `1.0` make it easier.\n\n" +
                "Note that the game engine only checks whether there IS a wall between an NPC and a sound source, it does NOT check what the wall is made of.\n" +
                "That means the game engine treats the wall of a tent the same way as the wall of a house or keep.\n\n(Vanilla: 0.3)")]
            public Setting<float> fSneakSoundLosMult = new();

            [SettingName(nameof(fSneakEquippedWeightBase))]
            [Tooltip("The initial value when calculating how much noise an actor makes when moving, this specifies the minimum possible amount of noise made by moving.\n" +
                "Higher values increase the amount of sound made by moving.\n\n(Vanilla: 12)")]
            public Setting<float> fSneakEquippedWeightBase = new();

            [SettingName(nameof(fSneakEquippedWeightMult))]
            [Tooltip("Multiplier that controls how much easier it is to detect someone with heavy equipped gear.\n" +
                "This only affects the weight of EQUIPPED gear. (Carry weight is NOT checked by the stealth system, unless you're overencumbered.)\n\n(Vanilla: 0.5)")]
            public Setting<float> fSneakEquippedWeightMult = new();

            [SettingName(nameof(fSneakActionMult))]
            [Tooltip("Multiplier that controls how loud non-movement sounds are, and thus how far away they can be detected.\n" +
                "This includes weapon swings (even if they don't hit anything), spell casting, projectile impacts, etc.\n\n" +
                "Note: Despite this Game Setting being stored as a floating-point number, it only accepts integral values that are greater than 1!\n\n" +
                "(Vanilla: 2)")]
            public Setting<int> fSneakActionMult = new();

            [SettingName(nameof(fSneakRunningMult))]
            [Tooltip("Multiplier that controls how much more noise is produced by running rather than walking.\n" +
                "Values larger than `1.0` make running louder than walking, while values below `1.0` make running quieter than walking.\n\n" +
                "(Vanilla: 2)")]
            public Setting<float> fSneakRunningMult = new();
        }
    }
}
