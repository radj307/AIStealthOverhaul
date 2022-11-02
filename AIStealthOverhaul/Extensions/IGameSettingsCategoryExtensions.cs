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
                else if (fieldValue is ISetting setting)
                {
                    if (!setting.IsEnabled || setting.ValueObject is null)
                        continue;
                    changed.RefAdd(state.AddOrReplaceGameSetting(fInfo.Name, setting.ValueObject));
                }
                else
                    Console.WriteLine($"[WARN]\tReflection skipped member \"{typeof(GameSettings).FullName}.{fInfo.Name}\" because type \"{fInfo.FieldType.FullName}\" does not implement \"{nameof(IGameSettingsCategory)}\" or \"{nameof(ISetting)}\"!");
            }
        }
        /// <summary>
        /// Uses reflection to enumerate all FIELDs within the type of <paramref name="category"/>.
        /// </summary>
        /// <param name="category">An instance of a class that implements <see cref="IGameSettingsCategory"/>.</param>
        /// <param name="state">The <see cref="IPatcherState"/> instance.</param>
        /// <param name="changed">The number of changes made to the PatchMod.</param>
        /// <returns>The number of modified items that were added to the patchmod.</returns>
        public static int AddToPatch(this IGameSettingsCategory category, IPatcherState<ISkyrimMod, ISkyrimModGetter> state, out int changed)
        {
            changed = 0;
            var categoryType = category.GetType();
            var fields = categoryType.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            foreach (var fInfo in fields)
            {
                var fVal = fInfo.GetValue(category);

                if (fVal is ISetting setting)
                {
                    if (!setting.IsEnabled)
                    {
                        Console.WriteLine($"Reflection skipped member \"{categoryType.Name}.{fInfo.Name}\" because {ISetting.IsEnabledName} is {setting.IsEnabled}. (Value: {setting.ValueObject})");
                        continue;
                    }
                    if (setting.ValueObject is null)
                    {
                        Console.WriteLine($"Reflection skipped member \"{categoryType.Name}.{fInfo.Name}\" because the {nameof(setting.ValueObject)} was null!");
                        continue;
                    }
                    changed.RefAdd(state.AddOrReplaceGameSetting(fInfo.Name, setting.ValueObject));
                }
                else if (fVal is IGameSettingsCategory subCategory)
                {
                    changed.RefAdd(subCategory.AddToPatch(state)); //< RECURSE
                }
                else Console.WriteLine($"Reflection skipped member \"{categoryType.Name}.{fInfo.Name}\" because it doesn't implement {nameof(ISetting)} or {nameof(IGameSettingsCategory)}.");
            }

            return changed;
        }
        /// <inheritdoc cref="AddToPatch(IGameSettingsCategory, IPatcherState{ISkyrimMod, ISkyrimModGetter}, out int)"/>
        public static int AddToPatch(this IGameSettingsCategory category, IPatcherState<ISkyrimMod, ISkyrimModGetter> state) => AddToPatch(category, state, out _);
    }
}
