using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace AIStealthOverhaul.Synth
{
    public interface ISetting : IValue
    {
        internal const string IsEnabledName = "Enable";
        [SettingName(IsEnabledName)]
        [JsonDiskName(IsEnabledName)]
        [Tooltip($"When you disable a setting, the patcher skips it and does not modify that record.")]
        bool IsEnabled { get; set; }
    }
    public interface ISetting<T> : ISetting, IValue, IGetValueOrAlternative<T> { }
}
