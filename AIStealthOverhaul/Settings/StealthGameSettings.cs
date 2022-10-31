using AIStealthOverhaul.Extensions;
using AIStealthOverhaul.Settings;
using AIStealthOverhaul.Synth;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace StealthOverhaul.Settings
{
    public partial class StealthGameSettings : IGameSettingsCategory
    {
        #region Fields
        public FormulaCoreGameSettings Core = new();
        public VisualGameSettings Visual = new();
        public AudioGameSettings Audio = new();
        public DistanceGameSettings Distances = new();
        public TimerGameSettings Timers = new();
        public ContextualModifierGameSettings ContextualModifiers = new();
        public SkillSystemGameSettings SkillSystem = new();
        public StealthPointSystemGameSettings StealthPointSystem = new();
        public SearchSystemGameSettings SearchSystem = new();
        #endregion Fields

        #region Methods
        public void ApplyGameSettingsToPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, out int changed)
        {
            changed = 0;

            foreach (var fInfo in typeof(StealthGameSettings).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                var fieldValue = fInfo.GetValue(this);

                if (fieldValue is null)
                    continue;
                else if (fieldValue is IGameSettingsCategory category)
                    changed.RefAdd(category.AddToPatch(state));
                else if (fieldValue is IValueSetting valueSetting)
                    changed.RefAdd(state.AddOrReplaceGameSetting(fInfo.Name, valueSetting.ValueObject));
                else
                    Console.WriteLine($"[WARN]\tReflection skipped member \"{typeof(StealthGameSettings).FullName}.{fInfo.Name}\" because type \"{fInfo.FieldType.FullName}\" does not implement \"{nameof(IGameSettingsCategory)}\" or \"{nameof(IValueSetting)}\"!");
            }
        }
        #endregion Methods
    }
}
