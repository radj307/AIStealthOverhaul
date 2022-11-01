using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings
    {
        public class SearchSystemGameSettings : IGameSettingsCategory
        {
            // TODO: Fix tooltips in SearchSystemGameSettings

            [SettingName(nameof(fCombatSearchExteriorRadiusMax))]
            [Tooltip("once an enemy starts a search outside, this controls how far out they can search in every direction (the starting point is usually the player's last known position, or the location of a spell/arrow impact)\n\n(Default: 2048)")]
            public FloatSetting fCombatSearchExteriorRadiusMax = new();

            [SettingName(nameof(fCombatSearchExteriorRadiusMin))]
            [Tooltip("once an enemy starts a search outside, this controls how far out they can search in every direction (the starting point is usually the player's last known position, or the location of a spell/arrow impact)\n\n(Default: 1280)")]
            public FloatSetting fCombatSearchExteriorRadiusMin = new();

            [SettingName(nameof(fCombatSearchInteriorRadiusMax))]
            [Tooltip("once an enemy starts a search inside, this controls how far out they can search in every direction (the starting point is usually the player's last known position, or the location of a spell/arrow impact)\n\n(Default: 1280)")]
            public FloatSetting fCombatSearchInteriorRadiusMax = new();

            [SettingName(nameof(fCombatSearchInteriorRadiusMin))]
            [Tooltip("once an enemy starts a search inside, this controls how far out they can search in every direction (the starting point is usually the player's last known position, or the location of a spell/arrow impact)\n\n(Default: 768)")]
            public FloatSetting fCombatSearchInteriorRadiusMin = new();

            [SettingName(nameof(fCombatSearchSightRadius))]
            [Tooltip("approx distance between each sub-destination in a search pattern. low values make the NPC check more corners, but it takes longer. high values make NPCs sweep large areas quickly but they will skip more small areas. vanilla was forced to use a high value because enemies had a very short time limit to search. RAID does not have that problem, so enemies can afford to check more corners when searching \n\n(Default: 1536)")]
            public FloatSetting fCombatSearchSightRadius = new();

            [SettingName(nameof(fCombatSearchInvestigateTime))]
            [Tooltip("after arriving at the location of a detection event, this controls how long the enemy will stand still there before starting a random search pattern, or returning to where they were before.\n\n(Default: 2.5)")]
            public FloatSetting fCombatSearchInvestigateTime = new();

            [SettingName(nameof(fCombatSearchLookTime))]
            [Tooltip("during a search pattern, NPCs will stand still this long after each movement (each change of direction during a search). low values produce more \"energetic\" and \"erratic\" search movement, and makes it harder for the player to sneak up and backstab them. low values also increases the chance NPC will run past the player without noticing in dark environments.\n\n(Default: 1)")]
            public FloatSetting fCombatSearchLookTime = new();

            [SettingName(nameof(fCombatSearchStartWaitTime))]
            [Tooltip("delay after entering alert state before starting to search (movement reaction time after noticing something). also applies if enemy is moving on patrol. if enemy is seated, add the duration of standing-up animation to this timer.\n\n(Default: 1)")]
            public FloatSetting fCombatSearchStartWaitTime = new();
        }
    }
}
