using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.WPF.Reflection.Attributes;
using StealthOverhaul.Settings;

namespace AIStealthOverhaul.Settings
{
    public class TopLevelSettings
    {
        #region Constructor
        public TopLevelSettings()
        {
            PresetIO = new();
            GameSettings = new()
            {
                Core = new()
                {
                    fSneakBaseValue = -4f,
                    fSneakDistanceAttenuationExponent = 5f,
                },
                Visual = new()
                {
                    fDetectionViewCone = 160f,
                    fDetectionSneakLightMod = -2f,
                    fSneakLightMult = 0.5f,
                    fSneakLightExteriorMult = 0.7f,
                    fSneakLightMoveMult = 0.2f,
                    fSneakLightRunMult = 0.7f,
                    iLightLevelInteriorMod = 25,
                    iLightLevelExteriorMod = 15,
                    iLightLevelMax = 200,
                },
                Audio = new()
                {
                    fSneakSoundsMult = 0.7f,
                    fSneakSoundLosMult = 0.28f,
                    fSneakEquippedWeightBase = 5f,
                    fSneakEquippedWeightMult = 0.25f,
                    fSneakActionMult = 1,
                    fSneakRunningMult = 1.9f,
                },
                Distances = new()
                {
                    fSneakMaxDistance = 5000f,
                    fSneakExteriorDistanceMult = 1.3f,
                    fSneakFlyingDistanceMult = 3f,
                    fDetectProjectileDistanceNPC = 512f,
                    fDetectProjectileDistancePlayer = 1024f,
                    fDetectEventDistanceNPC = 512f,
                    fDetectEventDistancePlayer = 1536f,
                    iCrimeAlarmLowRecDistance = 1100,
                    iCrimeAlarmRecDistance = 2200,
                    fDeadReactionDistance = 700f,
                },
                Timers = new()
                {
                    fCombatStealthPointRegenAlertWaitTime = 15f,
                    fCombatStealthPointRegenDetectedEventWaitTime = 30f,
                    fCombatStealthPointRegenAttackedWaitTime = 50f,
                    fCombatStealthPointRegenLostWaitTime = 20f,
                    fCombatDetectionLostTimeLimit = 15f,
                    fCombatDetectionNoticedTimeLimit = 5f,
                    fActorAlertSoundTimer = 2f,
                    fDetectionEventExpireTime = 2f,
                },
                ContextualModifiers = new()
                {
                    fSneakAlertMod = 1f,
                    fSneakCombatMod = -2f,
                    fSneakSleepBonus = -0.3f,
                },
                SkillSystem = new()
                {
                    fSneakSkillMult = 0.08f,
                    fPlayerDetectionSneakMult = 0.7f,
                    fPlayerDetectionSneakBase = 5f,
                    fSneakPerceptionSkillMax = 100f,
                    fSneakPerceptionSkillMin = 0f,
                },
                StealthPointSystem = new()
                {
                    fCombatStealthPointDrainMult = 3f,
                    fCombatStealthPointRegenMult = 0.08f,
                    fCombatStealthPointRegenMin = 2.5f,
                    iCombatStealthPointDetectionThreshold = 25,
                    iCombatStealthPointSneakDetectionThreshold = 70,
                    fCombatStealthPointAttackedMaxValue = 50f,
                    fCombatStealthPointDetectedEventMaxValue = 75f,
                    fCombatStealthPointMax = 100f,
                },
                SearchSystem = new()
                {
                    fCombatSearchExteriorRadiusMax = 2560f,
                    fCombatSearchExteriorRadiusMin = 1536f,
                    fCombatSearchInteriorRadiusMax = 1536f,
                    fCombatSearchInteriorRadiusMin = 1024f,
                    fCombatSearchSightRadius = 1024f,
                    fCombatSearchInvestigateTime = 3.5f,
                    fCombatSearchLookTime = 1f,
                    fCombatSearchStartWaitTime = 1f,
                }
            };
        }
        #endregion Constructor

        #region Fields
        internal const string ConfigPresetsName = "Import/Export Presets";
        [SettingName(ConfigPresetsName)]
        [Tooltip("Allows you to save & recall settings presets from the local filesystem.\n" +
            "If you choose to load a preset file, any values set in the 'Game Settings' section are overwritten with the values from the preset file.")]
        public StealthGameSettingsCategoryIO PresetIO;

        internal const string GameSettingsName = "Game Settings";
        [SettingName(GameSettingsName)]
        [Tooltip("Game Settings are separated into groups based on what they do & what they are used for.")]
        public GameSettings GameSettings;

        public bool EnableDebugLogging = false;
        #endregion Fields

        #region Methods
        public void AddGameSettingsToPatchMod(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, out int changed) => GameSettings.AddToPatch(state, out changed);
        public bool ImportPresetIfAvailable()
        {
            if (PresetIO.Import(out var gmst) && gmst is not null)
            {
                GameSettings = gmst;
                return true;
            }
            return false;
        }
        public bool ExportPresetIfAvailable() => PresetIO.Export(GameSettings);
        #endregion Methods
    }
}
