using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace AIStealthOverhaul.Extensions
{
    public static class IGameSettingsCategoryExtension
    {
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

                if (fVal is IValueSetting valueSetting)
                    changed.RefAdd(state.AddOrReplaceGameSetting(fInfo.Name, valueSetting.ValueObject));
                else if (fVal is IGameSettingsCategory subCategory)
                    changed.RefAdd(subCategory.AddToPatch(state)); //< RECURSE
            }
            return changed;
        }
    }
}
