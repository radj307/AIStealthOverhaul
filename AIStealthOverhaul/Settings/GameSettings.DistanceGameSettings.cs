using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings
    {
        public class DistanceGameSettings : IGameSettingsCategory
        {
            // TODO: Fix tooltips in DistanceGameSettings

            [SettingName(nameof(fSneakMaxDistance))]
            [Tooltip("distance master-control for visual/audio/skill based detection (there are other forms of detection than those 3 which are not affected). in practice, detection ranges are much shorter than this value, especially when using high attenuation exponents like RAID does. values affect detection at all distances, not just the max distance.\n\n(Vanilla: 2500)")]
            public Setting<float> fSneakMaxDistance = new();

            [SettingName(nameof(fSneakExteriorDistanceMult))]
            [Tooltip("multiplies range of visual/audio/skill detection for outside compared to in a dungeon etc (in vanilla detection range outside is 2.1x more than inside). 2500 x 2.1 = 5250 vanilla range, which is equivalent to about 6200 RAID range due to attenuation exponent differences.\n\n(Default: 2.1)")]
            public Setting<float> fSneakExteriorDistanceMult = new();

            [SettingName(nameof(fSneakFlyingDistanceMult))]
            [Tooltip("controls how capable dragons are at detecting targets while flying. it behaves a bit oddly - same as fSneakMaxDistance but only for flying dragons, but seemingly only within the distance set by fSneakMaxDistance (and the exterior mult) - high values above 3 results in very capable dragon detection, but will still instantly cut off at the distance set by fSneakMaxDistance.\n\n(Vanilla: 3)")]
            public Setting<float> fSneakFlyingDistanceMult = new();

            [SettingName(nameof(fDetectProjectileDistanceNPC))]
            [Tooltip("distance NPC can notice arrows/spells fly past. values below 512 effectively become \"0\" due to game engine low polling rate. walls only reduce this distance if they block ALL ray-traces between arrow and detector as it travels through air. \n\n(Vanilla: 512)")]
            public Setting<float> fDetectProjectileDistanceNPC = new();

            [SettingName(nameof(fDetectProjectileDistancePlayer))]
            [Tooltip("distance NPC can notice arrows/spells fly past (from the player). walls only reduce this distance if they block ALL ray-traces between arrow and detector as it travels through air. values below 512 effectively become \"0\" with NPCs completely failing to notice, due to game engine low polling rate\n\n(Vanilla: 1024)")]
            public Setting<float> fDetectProjectileDistancePlayer = new();

            [SettingName(nameof(fDetectEventDistanceNPC))]
            [Tooltip("distance NPC can notice an arrow/spell impact. distance is reduced by walls depending on fSneakSoundLosMult\n\n(Vanilla: 512)")]
            public Setting<float> fDetectEventDistanceNPC = new();

            [SettingName(nameof(fDetectEventDistancePlayer))]
            [Tooltip("distance NPC can notice an arrow/spell impact (from the player). distance is reduced by walls depending on fSneakSoundLosMult\n\n(Vanilla: 1536)")]
            public Setting<float> fDetectEventDistancePlayer = new();

            [SettingName(nameof(iCrimeAlarmLowRecDistance))]
            [Tooltip("when an NPC witnesses you commit a crime, this value controls the distance guards are instantly alerted, and will approach to make an arrest. also affects the distance beyond a loading door. this GMST and the one below has a similar effect, I cannot discern the precise difference between them\n\n(Vanilla: 2000)")]
            public Setting<int> iCrimeAlarmLowRecDistance = new();

            [SettingName(nameof(iCrimeAlarmRecDistance))]
            [Tooltip("when an NPC witnesses you commit a crime, this value controls the distance guards are instantly alerted, and will approach to make an arrest. also affects the distance beyond a loading door. other mods tend to lower this too much - to as little as \"1000\", which allows you to butcher everyone in \"the bannered mare\" with a battleaxe, while a guard right outside will not notice anything\n\n(Vanilla: 4000)")]
            public Setting<int> iCrimeAlarmRecDistance = new();

            [SettingName(nameof(fDeadReactionDistance))]
            [Tooltip("within this distance a relaxed enemy will walk towards a dead ally, and then start a random search pattern. distance is unaffected by ambient light (even a pitch black cave).\n\n(Vanilla: 400)")]
            public Setting<float> fDeadReactionDistance = new();
        }
    }
}
