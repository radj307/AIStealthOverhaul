using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class FormulaCoreGameSettings : IGameSettingsCategory
        {
            [SettingName(nameof(fSneakBaseValue))]
            [Tooltip("The 'starting' value for the core detection formula, around which everything else is balanced.\nLower values (more negative values) make it harder for NPCs to detect anything.")]
            public FloatSetting fSneakBaseValue = new();

            [SettingName(nameof(fSneakDistanceAttenuationExponent))]
            [Tooltip("Used in various parts of the formula to control how distance affects detection power.\nIf you were to plot distance on the x-axis and detection power on the y-axis, you get something that looks a bit like a half-life decay graph, and higher values of this GMST give that slope a more aggressive 'curve'.")]
            public FloatSetting fSneakDistanceAttenuationExponent = new();
        }
    }
}
