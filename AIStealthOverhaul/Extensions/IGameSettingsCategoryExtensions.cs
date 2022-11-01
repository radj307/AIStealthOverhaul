using AIStealthOverhaul.Extensions;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using StealthOverhaul.Settings;

namespace AIStealthOverhaul.Settings
{
    public static class IGameSettingsCategoryExtensions
    {
        /// <summary>
        /// Uses reflection to enumerate all FIELDs within the type of <paramref name="inst"/>
        /// </summary>
        /// <param name="inst">An instance of an object that implements <see cref="IGameSettingsCategory"/>.</param>
        /// <param name="state">Patcher state</param>
        /// <param name="changed">Outputs the number of changes added to the PatchMod.</param>
        public static void ApplyGameSettingsToPatch(this IGameSettingsCategory inst, IPatcherState<ISkyrimMod, ISkyrimModGetter> state, out int changed)
        {
            changed = 0;

            foreach (var fInfo in inst.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                var fieldValue = fInfo.GetValue(inst);

                if (fieldValue is null)
                    continue;
                else if (fieldValue is IGameSettingsCategory category)
                    changed.RefAdd(category.AddToPatch(state));
                else if (fieldValue is IValueSetting valueSetting && valueSetting.IsEnabled)
                    changed.RefAdd(state.AddOrReplaceGameSetting(fInfo.Name, valueSetting.ValueObject));
                else
                    Console.WriteLine($"[WARN]\tReflection skipped member \"{typeof(StealthGameSettings).FullName}.{fInfo.Name}\" because type \"{fInfo.FieldType.FullName}\" does not implement \"{nameof(IGameSettingsCategory)}\" or \"{nameof(IValueSetting)}\"!");
            }
        }
        /// <summary>
        /// Uses reflection to enumerate all FIELDs within the type of <paramref name="category"/>.
        /// </summary>
        /// <param name="category">An instance of a class that implements <see cref="IGameSettingsCategory"/>.</param>
        /// <param name="state">The <see cref="IPatcherState"/> instance.</param>
        /// <returns>The number of modified items that were added to the patchmod.</returns>
        public static int AddToPatch(this IGameSettingsCategory category, IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            int changed = 0;
            foreach (var fInfo in category.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                var fVal = fInfo.GetValue(category);

                if (fVal is IValueSetting valueSetting && valueSetting.IsEnabled)
                    changed.RefAdd(state.AddOrReplaceGameSetting(fInfo.Name, valueSetting.ValueObject));
                else if (fVal is IGameSettingsCategory subCategory)
                    changed.RefAdd(subCategory.AddToPatch(state)); //< RECURSE
            }
            return changed;
        }
    }
}
