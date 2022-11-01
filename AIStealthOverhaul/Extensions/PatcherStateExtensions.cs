using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using Noggog;

namespace AIStealthOverhaul.Extensions
{
    /// <summary>
    /// Extends <see cref="IPatcherState{TModSetter, TModGetter}"/> objects.
    /// </summary>
    public static class PatcherStateExtensions
    {
        /// <remarks>
        /// <b>This is a wrapper method for <see cref="AddOrReplaceGameSettingInternal(IPatcherState{ISkyrimMod, ISkyrimModGetter}, string, object)"/> that includes console logging.</b>
        /// </remarks>
        /// <inheritdoc cref="AddOrReplaceGameSettingInternal(IPatcherState{ISkyrimMod, ISkyrimModGetter}, string, object)"/>
        public static bool AddOrReplaceGameSetting(this IPatcherState<ISkyrimMod, ISkyrimModGetter> state, string editorID, object data)
        {
            bool success = AddOrReplaceGameSettingInternal(state, editorID, data);

            string recordName = $"\"{editorID}\"";

            if (state.LinkCache.TryResolveIdentifier<IGameSettingGetter>(editorID, out FormKey formKey))
            {
                recordName = $"[GMST:{formKey.IDString()}] {recordName}";
            }

            if (success)
            {
                Console.WriteLine($"Set {recordName} to \"{data}\"");
                return true;
            }
            else
            {
                Console.WriteLine($"{recordName} was already set to \"{data}\"");
                return false;
            }
        }
        /// <summary>
        /// Adds a new game setting with the specified name &amp; value, or replaces it if it already exists.
        /// </summary>
        /// <remarks>
        /// Note that the <paramref name="data"/> parameter ONLY accepts values of one of the following types:
        /// <list type="bullet">
        /// <item><description><see cref="float"/></description></item>
        /// <item><description><see cref="int"/></description></item>
        /// <item><description><see cref="bool"/></description></item>
        /// <item><description><see cref="string"/></description></item>
        /// </list>
        /// Also note that if a game setting named <paramref name="editorID"/> already exists, the value type of <paramref name="data"/> <b>must be convertible to</b> the pre-existing type, or an <see cref="InvalidOperationException"/> is thrown.
        /// </remarks>
        /// <param name="state">The <see cref="IPatcherState"/> instance.</param>
        /// <param name="editorID">Value of the <see cref="GameSetting.EditorID"/> property.</param>
        /// <param name="data">The value to assign to the GMST specified by <paramref name="editorID"/>.</param>
        /// <returns><see langword="true"/> when the specified game setting was added or replaced an existing value; otherwise <see langword="false"/> if the current value is already set to <paramref name="data"/> and no changes were made.</returns>
        /// <exception cref="InvalidOperationException">
        /// The type of the <paramref name="data"/> parameter didn't match the type of the existing value, or it was an unexpected type.<br/>
        /// Expected types: <see cref="float"/>, <see cref="int"/>, <see cref="bool"/>, &amp; <see cref="string"/>.
        /// </exception>
        public static bool AddOrReplaceGameSettingInternal(this IPatcherState<ISkyrimMod, ISkyrimModGetter> state, string editorID, object data)
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
                else throw new InvalidOperationException($"The type '{data.GetType().FullName}' is invalid for parameter '{nameof(data)}' in function '{nameof(AddOrReplaceGameSetting)}'; expected 'float', 'int', 'string', or 'bool'!");

                state.PatchMod.GameSettings.Set(gameSettingCopy);
                return true;
            }
            else
            { // RECORD DOES NOT EXIST:
                GameSetting? gameSetting = null;

                if (data is float floatVal)
                    gameSetting = new GameSettingFloat(state.PatchMod.GetNextFormKey(), state.PatchMod.SkyrimRelease) { EditorID = editorID, Data = floatVal };
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
                else throw new InvalidOperationException($"The type '{data.GetType().FullName}' is invalid for parameter '{nameof(data)}' in function '{nameof(AddOrReplaceGameSetting)}'; expected 'float', 'int', 'string', or 'bool'!");

                state.PatchMod.GameSettings.Set(gameSetting);
                return true;
            }
        }
    }
}
