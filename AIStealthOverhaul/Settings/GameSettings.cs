using AIStealthOverhaul.Settings;

namespace StealthOverhaul.Settings
{
    public partial class GameSettings : IGameSettingsCategory
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
    }
}
