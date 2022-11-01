using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class SkillSystemGameSettings : IGameSettingsCategory
        {
            // TODO: Fix tooltips in SkillSystemGameSettings

            [SettingName(nameof(fSneakSkillMult))]
            [Tooltip("how much the difference between your sneak skill level and the enemy's affects their ability to detect you (at the relative expense of other factors like vision and audio). also affects how much difference sneaking makes compared to standing. values above \"0\" can cause NPCs with high sneak skill levels to detect the player when out of sneak mode, at a rate depending on proximity, regardless of player action or cover, thus values that are too high can cause a bad \"wall-hacking\" NPC effect.\n\n(Default: 0.5)")]
            public FloatSetting fSneakSkillMult = new();

            [SettingName(nameof(fPlayerDetectionSneakMult))]
            [Tooltip("controls how effectively player can sneak depending on player sneak level (and unlike fSneakSkillMult, it ignores enemy sneak level). only works if fSneakSkillMult is more than \"0\" as value is multiplied by that. high values can reduce NPC wall-hacking effects (when in sneak mode).\n\n(Default: 0.4)")]
            public FloatSetting fPlayerDetectionSneakMult = new();

            [SettingName(nameof(fPlayerDetectionSneakBase))]
            [Tooltip("controls the minimum effectiveness of player sneaking, regardless of player/enemy sneak level. only works if fSneakSkillMult is more than \"0\". in a sense this GMST is similar but opposite to fSneakBaseValue (but only when player is sneaking). high values reduce NPC wall-hacking effects (when in sneak mode).\n\n(Default: 10)")]
            public FloatSetting fPlayerDetectionSneakBase = new();

            [SettingName(nameof(fSneakPerceptionSkillMax))]
            [Tooltip("controls the max sneak skill level NPCs can have as far as the detection formula is concerned. reducing the range between 0-100 reduces the difference between high and low skilled enemies. The magnitude of this GMST's effect is multiplied by fSneakSkillMult\n\n(Default: 100)")]
            public FloatSetting fSneakPerceptionSkillMax = new();

            [SettingName(nameof(fSneakPerceptionSkillMin))]
            [Tooltip("controls the min sneak skill (and thus detection power) NPCs can have as far as the detection formula is concerned. normaly the minimum ingame is \"15\", but if you set this value higher than \"15\", then all those enemies would get better at detecting you.\n\n(Default: 0)")]
            public FloatSetting fSneakPerceptionSkillMin = new();

        }
    }
}
