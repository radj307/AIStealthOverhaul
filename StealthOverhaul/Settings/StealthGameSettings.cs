using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.WPF.Reflection.Attributes;
using StealthOverhaul.Synth;

namespace StealthOverhaul.Settings
{
    public class StealthGameSettings
    {
        #region Fields
        [SettingName(nameof(fSneakBaseValue))]
        public StructSetting<float> fSneakBaseValue = new();

        [SettingName(nameof(fSneakDistanceAttenuationExponent))]
        public StructSetting<float> fSneakDistanceAttenuationExponent = new();

        [SettingName(nameof(fDetectionViewCone))]
        public StructSetting<float> fDetectionViewCone = new();

        [SettingName(nameof(fDetectionSneakLightMod))]
        public StructSetting<float> fDetectionSneakLightMod = new();

        [SettingName(nameof(fSneakLightMult))]
        public StructSetting<float> fSneakLightMult = new();

        [SettingName(nameof(fSneakLightExteriorMult))]
        public StructSetting<float> fSneakLightExteriorMult = new();

        [SettingName(nameof(fSneakLightMoveMult))]
        public StructSetting<float> fSneakLightMoveMult = new();

        [SettingName(nameof(fSneakLightRunMult))]
        public StructSetting<float> fSneakLightRunMult = new();

        [SettingName(nameof(iLightLevelInteriorMod))]
        public StructSetting<int> iLightLevelInteriorMod = new();

        [SettingName(nameof(iLightLevelExteriorMod))]
        public StructSetting<int> iLightLevelExteriorMod = new();

        [SettingName(nameof(iLightLevelMax))]
        public StructSetting<int> iLightLevelMax = new();

        [SettingName(nameof(fSneakSoundsMult))]
        public StructSetting<float> fSneakSoundsMult = new();

        [SettingName(nameof(fSneakSoundLosMult))]
        public StructSetting<float> fSneakSoundLosMult = new();

        [SettingName(nameof(fSneakEquippedWeightBase))]
        public StructSetting<float> fSneakEquippedWeightBase = new();

        [SettingName(nameof(fSneakEquippedWeightMult))]
        public StructSetting<float> fSneakEquippedWeightMult = new();

        [SettingName(nameof(fSneakActionMult))]
        public StructSetting<float> fSneakActionMult = new();

        [SettingName(nameof(fSneakRunningMult))]
        public StructSetting<float> fSneakRunningMult = new();

        [SettingName(nameof(fSneakMaxDistance))]
        public StructSetting<float> fSneakMaxDistance = new();

        [SettingName(nameof(fSneakExteriorDistanceMult))]
        public StructSetting<float> fSneakExteriorDistanceMult = new();

        [SettingName(nameof(fSneakFlyingDistanceMult))]
        public StructSetting<float> fSneakFlyingDistanceMult = new();

        [SettingName(nameof(fDetectProjectileDistanceNPC))]
        public StructSetting<float> fDetectProjectileDistanceNPC = new();

        [SettingName(nameof(fDetectProjectileDistancePlayer))]
        public StructSetting<float> fDetectProjectileDistancePlayer = new();

        [SettingName(nameof(fDetectEventDistanceNPC))]
        public StructSetting<float> fDetectEventDistanceNPC = new();

        [SettingName(nameof(fDetectEventDistancePlayer))]
        public StructSetting<float> fDetectEventDistancePlayer = new();

        [SettingName(nameof(iCrimeAlarmLowRecDistance))]
        public StructSetting<int> iCrimeAlarmLowRecDistance = new();

        [SettingName(nameof(iCrimeAlarmRecDistance))]
        public StructSetting<int> iCrimeAlarmRecDistance = new();

        [SettingName(nameof(fDeadReactionDistance))]
        public StructSetting<float> fDeadReactionDistance = new();

        [SettingName(nameof(fCombatStealthPointRegenAlertWaitTime))]
        public StructSetting<float> fCombatStealthPointRegenAlertWaitTime = new();

        [SettingName(nameof(fCombatStealthPointRegenDetectedEventWaitTime))]
        public StructSetting<float> fCombatStealthPointRegenDetectedEventWaitTime = new();

        [SettingName(nameof(fCombatStealthPointRegenAttackedWaitTime))]
        public StructSetting<float> fCombatStealthPointRegenAttackedWaitTime = new();

        [SettingName(nameof(fCombatStealthPointRegenLostWaitTime))]
        public StructSetting<float> fCombatStealthPointRegenLostWaitTime = new();

        [SettingName(nameof(fCombatDetectionLostTimeLimit))]
        public StructSetting<float> fCombatDetectionLostTimeLimit = new();

        [SettingName(nameof(fCombatDetectionNoticedTimeLimit))]
        public StructSetting<float> fCombatDetectionNoticedTimeLimit = new();

        [SettingName(nameof(fActorAlertSoundTimer))]
        public StructSetting<float> fActorAlertSoundTimer = new();

        [SettingName(nameof(fDetectionEventExpireTime))]
        public StructSetting<float> fDetectionEventExpireTime = new();

        [SettingName(nameof(fSneakAlertMod))]
        public StructSetting<float> fSneakAlertMod = new();

        [SettingName(nameof(fSneakCombatMod))]
        public StructSetting<float> fSneakCombatMod = new();

        [SettingName(nameof(fSneakSleepBonus))]
        public StructSetting<float> fSneakSleepBonus = new();

        [SettingName(nameof(fSneakSkillMult))]
        public StructSetting<float> fSneakSkillMult = new();

        [SettingName(nameof(fPlayerDetectionSneakMult))]
        public StructSetting<float> fPlayerDetectionSneakMult = new();

        [SettingName(nameof(fPlayerDetectionSneakBase))]
        public StructSetting<float> fPlayerDetectionSneakBase = new();

        [SettingName(nameof(fSneakPerceptionSkillMax))]
        public StructSetting<float> fSneakPerceptionSkillMax = new();

        [SettingName(nameof(fSneakPerceptionSkillMin))]
        public StructSetting<float> fSneakPerceptionSkillMin = new();

        [SettingName(nameof(fCombatStealthPointDrainMult))]
        public StructSetting<float> fCombatStealthPointDrainMult = new();

        [SettingName(nameof(fCombatStealthPointRegenMult))]
        public StructSetting<float> fCombatStealthPointRegenMult = new();

        [SettingName(nameof(fCombatStealthPointRegenMin))]
        public StructSetting<float> fCombatStealthPointRegenMin = new();

        [SettingName(nameof(iCombatStealthPointDetectionThreshold))]
        public StructSetting<int> iCombatStealthPointDetectionThreshold = new();

        [SettingName(nameof(iCombatStealthPointSneakDetectionThreshold))]
        public StructSetting<int> iCombatStealthPointSneakDetectionThreshold = new();

        [SettingName(nameof(fCombatStealthPointAttackedMaxValue))]
        public StructSetting<float> fCombatStealthPointAttackedMaxValue = new();

        [SettingName(nameof(fCombatStealthPointDetectedEventMaxValue))]
        public StructSetting<float> fCombatStealthPointDetectedEventMaxValue = new();

        [SettingName(nameof(fCombatStealthPointMax))]
        public StructSetting<float> fCombatStealthPointMax = new();

        [SettingName(nameof(fCombatSearchExteriorRadiusMax))]
        public StructSetting<float> fCombatSearchExteriorRadiusMax = new();

        [SettingName(nameof(fCombatSearchExteriorRadiusMin))]
        public StructSetting<float> fCombatSearchExteriorRadiusMin = new();

        [SettingName(nameof(fCombatSearchInteriorRadiusMax))]
        public StructSetting<float> fCombatSearchInteriorRadiusMax = new();

        [SettingName(nameof(fCombatSearchInteriorRadiusMin))]
        public StructSetting<float> fCombatSearchInteriorRadiusMin = new();

        [SettingName(nameof(fCombatSearchSightRadius))]
        public StructSetting<float> fCombatSearchSightRadius = new();

        [SettingName(nameof(fCombatSearchInvestigateTime))]
        public StructSetting<float> fCombatSearchInvestigateTime = new();

        [SettingName(nameof(fCombatSearchLookTime))]
        public StructSetting<float> fCombatSearchLookTime = new();

        [SettingName(nameof(fCombatSearchStartWaitTime))]
        public StructSetting<float> fCombatSearchStartWaitTime = new();
        #endregion Fields

        #region Methods
        private bool AddToPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, string editorID, object data)
        {
            if (state.LinkCache.TryResolveIdentifier<IGameSettingGetter>(editorID, out FormKey formKey) && state.LinkCache.TryResolve<IGameSettingGetter>(formKey, out IGameSettingGetter? gameSettingGetter))
            { // RECORD ALREADY EXISTS:
                var gameSettingCopy = gameSettingGetter.DeepCopy();

                if (gameSettingCopy is GameSettingFloat floatGameSetting)
                {
                    var val = Convert.ToSingle(data);
                    if (val.Equals(floatGameSetting.Data))
                        return false;

                    floatGameSetting.Data = val;
                }
                else if (gameSettingCopy is GameSettingInt intGameSetting)
                {
                    var val = Convert.ToInt32(data);
                    if (val.Equals(intGameSetting.Data))
                        return false;

                    intGameSetting.Data = val;
                }
                else if (gameSettingCopy is GameSettingString strGameSetting)
                {
                    var val = Convert.ToString(data);
                    if (val is null || val.Equals(strGameSetting.Data))
                        return false;

                    strGameSetting.Data = val;
                }
                else if (gameSettingCopy is GameSettingBool boolGameSetting)
                {
                    var val = Convert.ToBoolean(data);
                    if (val.Equals(boolGameSetting.Data))
                        return false;

                    boolGameSetting.Data = val;
                }
                else throw new InvalidOperationException($"The type '{data.GetType().FullName}' is invalid for parameter '{nameof(data)}' in function '{nameof(AddToPatch)}'; expected 'float', 'int', 'string', or 'bool'!");

                state.PatchMod.GameSettings.Set(gameSettingCopy);
                return true;
            }
            else
            { // RECORD DOES NOT EXIST:
                GameSetting? gameSetting = null;

                if (data is float floatVal)
                {
                    gameSetting = new GameSettingFloat(state.PatchMod.GetNextFormKey(), state.PatchMod.SkyrimRelease) { EditorID = editorID, Data = floatVal };
                }
                else if (data is int intVal)
                {
                    gameSetting = new GameSettingInt(state.PatchMod.GetNextFormKey(), state.PatchMod.SkyrimRelease) { EditorID = editorID, Data = intVal };
                }
                else if (data is string || data is null)
                {
                    gameSetting = new GameSettingString(state.PatchMod.GetNextFormKey(), state.PatchMod.SkyrimRelease) { EditorID = editorID, Data = (string?)data };
                }
                else if (data is bool boolVal)
                {
                    gameSetting = new GameSettingBool(state.PatchMod.GetNextFormKey(), state.PatchMod.SkyrimRelease) { EditorID = editorID, Data = boolVal };
                }
                else throw new InvalidOperationException($"The type '{data.GetType().FullName}' is invalid for parameter '{nameof(data)}' in function '{nameof(AddToPatch)}'; expected 'float', 'int', 'string', or 'bool'!");

                state.PatchMod.GameSettings.Set(gameSetting);
                return true;
            }
        }

        public void ApplyGameSettingsToPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, out int changed)
        {
            changed = 0;
            changed += AddToPatch(state, nameof(fSneakBaseValue), fSneakBaseValue.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakDistanceAttenuationExponent), fSneakDistanceAttenuationExponent.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectionViewCone), fDetectionViewCone.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectionSneakLightMod), fDetectionSneakLightMod.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakLightMult), fSneakLightMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakLightExteriorMult), fSneakLightExteriorMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakLightMoveMult), fSneakLightMoveMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakLightRunMult), fSneakLightRunMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iLightLevelInteriorMod), iLightLevelInteriorMod.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iLightLevelExteriorMod), iLightLevelExteriorMod.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iLightLevelMax), iLightLevelMax.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakSoundsMult), fSneakSoundsMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakSoundLosMult), fSneakSoundLosMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakEquippedWeightBase), fSneakEquippedWeightBase.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakEquippedWeightMult), fSneakEquippedWeightMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakActionMult), fSneakActionMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakRunningMult), fSneakRunningMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakMaxDistance), fSneakMaxDistance.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakExteriorDistanceMult), fSneakExteriorDistanceMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakFlyingDistanceMult), fSneakFlyingDistanceMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectProjectileDistanceNPC), fDetectProjectileDistanceNPC.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectProjectileDistancePlayer), fDetectProjectileDistancePlayer.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectEventDistanceNPC), fDetectEventDistanceNPC.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectEventDistancePlayer), fDetectEventDistancePlayer.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iCrimeAlarmLowRecDistance), iCrimeAlarmLowRecDistance.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iCrimeAlarmRecDistance), iCrimeAlarmRecDistance.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDeadReactionDistance), fDeadReactionDistance.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointRegenAlertWaitTime), fCombatStealthPointRegenAlertWaitTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointRegenDetectedEventWaitTime), fCombatStealthPointRegenDetectedEventWaitTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointRegenAttackedWaitTime), fCombatStealthPointRegenAttackedWaitTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointRegenLostWaitTime), fCombatStealthPointRegenLostWaitTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatDetectionLostTimeLimit), fCombatDetectionLostTimeLimit.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatDetectionNoticedTimeLimit), fCombatDetectionNoticedTimeLimit.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fActorAlertSoundTimer), fActorAlertSoundTimer.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fDetectionEventExpireTime), fDetectionEventExpireTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakAlertMod), fSneakAlertMod.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakCombatMod), fSneakCombatMod.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakSleepBonus), fSneakSleepBonus.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakSkillMult), fSneakSkillMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fPlayerDetectionSneakMult), fPlayerDetectionSneakMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fPlayerDetectionSneakBase), fPlayerDetectionSneakBase.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakPerceptionSkillMax), fSneakPerceptionSkillMax.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fSneakPerceptionSkillMin), fSneakPerceptionSkillMin.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointDrainMult), fCombatStealthPointDrainMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointRegenMult), fCombatStealthPointRegenMult.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointRegenMin), fCombatStealthPointRegenMin.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iCombatStealthPointDetectionThreshold), iCombatStealthPointDetectionThreshold.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(iCombatStealthPointSneakDetectionThreshold), iCombatStealthPointSneakDetectionThreshold.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointAttackedMaxValue), fCombatStealthPointAttackedMaxValue.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointDetectedEventMaxValue), fCombatStealthPointDetectedEventMaxValue.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatStealthPointMax), fCombatStealthPointMax.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchExteriorRadiusMax), fCombatSearchExteriorRadiusMax.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchExteriorRadiusMin), fCombatSearchExteriorRadiusMin.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchInteriorRadiusMax), fCombatSearchInteriorRadiusMax.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchInteriorRadiusMin), fCombatSearchInteriorRadiusMin.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchSightRadius), fCombatSearchSightRadius.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchInvestigateTime), fCombatSearchInvestigateTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchLookTime), fCombatSearchLookTime.Value) ? 1 : 0;
            changed += AddToPatch(state, nameof(fCombatSearchStartWaitTime), fCombatSearchStartWaitTime.Value) ? 1 : 0;
        }
        #endregion Methods
    }
}
