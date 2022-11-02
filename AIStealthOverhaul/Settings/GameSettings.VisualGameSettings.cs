using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings
    {
        public class VisualGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fDetectionViewCone))]
            [Tooltip("Total angle (in degrees) of NPC sight, beyond which they are blind. High values increase peripheral vision. while in real life humans have 190deg field of view, skyrim fails to model that peripheral vision is less capable than central vision.")]
            public Setting<float> fDetectionViewCone = new();

            [SettingName(nameof(fDetectionSneakLightMod))]
            [Tooltip("Applies a static offset to light levels for NPCs only. This affects how well NPCs can see in the dark, lower (or negative) values make it harder for enemies to see in the dark.")]
            public Setting<float> fDetectionSneakLightMod = new();

            [SettingName(nameof(fSneakLightMult))]
            [Tooltip("How 'powerful' NPC sight is indoors. This affects both range (below the maximum range of fSneakMaxDistance) & sneak eye indicator open speed at a given light level (this multiplies the raw light level value provided by weather/imagespace/light template records).\nNote that this WILL affect the result of the `player.gll` command in-game.\n(Vanilla: 0.33)")]
            public Setting<float> fSneakLightMult = new();

            [SettingName(nameof(fSneakLightExteriorMult))]
            [Tooltip($"How 'powerful' NPC sight is outdoors. This affects both range (below the maximum range of fSneakMaxDistance) & sneak eye indicator open speed at a given light level.\nGameplay considerations, level design differences, and differences in imagespaces between indoors and outdoors generally means HIGHER values are needed when compared to {nameof(fSneakLightMult)}.\n(Vanilla: 0.5)")]
            public Setting<float> fSneakLightExteriorMult = new();

            [SettingName(nameof(fSneakLightMoveMult))]
            [Tooltip("Multiplier that determines how much easier it is for NPCs to see the player when they are moving slowly, compared to not moving.")]
            public Setting<float> fSneakLightMoveMult = new();

            [SettingName(nameof(fSneakLightRunMult))]
            [Tooltip("Multiplier that determines how much easier it is for NPCs to see the player when they are running (NOT sprinting), compared to not moving.")]
            public Setting<float> fSneakLightRunMult = new();

            [SettingName(nameof(iLightLevelInteriorMod))]
            [Tooltip("Similar but opposite effect to fDetectionSneakLightMod, high values make NPCs see worse in the dark.\nNote that this WILL affect the result of the `player.gll` command in-game.")]
            public Setting<int> iLightLevelInteriorMod = new();

            [SettingName(nameof(iLightLevelExteriorMod))]
            [Tooltip("Similar but opposite effect to fDetectionSneakLightMod, high values make NPCs see worse in the dark.\nNote that this WILL affect the result of the `player.gll` command in-game.")]
            public Setting<int> iLightLevelExteriorMod = new();

            [SettingName(nameof(iLightLevelMax))]
            [Tooltip("The maximum light intensity value after which more light will no longer have an effect on detection. This is useful for preventing NPC detection from getting too powerful in bright areas, such as in full sunlight."
                 + "\nNote that this WILL affect the result of the `player.gll` command in-game, where the maximum possible return value is equal to (iLightLevelMax * fSneakLightExteriorMult)")]
            public Setting<int> iLightLevelMax = new();
        }
    }
}
