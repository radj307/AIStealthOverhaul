using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Newtonsoft.Json;

namespace AIStealthOverhaul.Synth
{
    /// <summary>
    /// <see langword="abstract"/> base class of <see cref="Setting{T}"/>.
    /// </summary>
    public abstract class Setting : ISetting, IValue
    {
        #region Properties
        public abstract bool IsEnabled { get; set; }
        [Ignore]
        [JsonIgnore]
        public abstract object? ValueObject { get; set; }
        #endregion Properties
    }
    public class Setting<T> : Setting, ISetting<T>, ISetting, IValue<T>, IValue
    {
        #region Constructors
        public Setting(T? value) => this.ValueContainer = (this.IsEnabled = value is not null) ? value! : SettingValue<T>.Default;
        public Setting() => this.ValueContainer = SettingValue.NewValue<T>();
        #endregion Constructors

        #region Properties
        [JsonProperty]
        [SettingName(ISetting.IsEnabledName)]
        [JsonDiskName(ISetting.IsEnabledName)]
        [Tooltip($"When you disable a setting, the patcher skips it and does not modify that record.")]
        public override bool IsEnabled
        {
            get => _isEnabled && ValueContainer.ValueObject is not null;
            set => _isEnabled = value;
        }
        private bool _isEnabled = false;
        /// <summary>
        /// Container that owns &amp; provides the values of <see cref="ValueObject"/> and <see cref="Value"/>
        /// </summary>
        [Ignore]
        [JsonIgnore]
        public IValue<T> ValueContainer { get; set; }
        [Ignore]
        [JsonIgnore]
        public override object? ValueObject
        {
            get => this.ValueContainer.ValueObject;
            set => this.ValueContainer.ValueObject = value;
        }
        internal const string ValueName = "Value";
        public T Value
        {
            get => this.ValueContainer.Value;
            set => this.ValueContainer.Value = value;
        }
        #endregion Properties

        #region Methods
        public T GetValueOrAlternative(T defaultValue, out bool changed) => throw new NotImplementedException();
        #endregion Methods

        #region Operators
        public static implicit operator Setting<T>(T value) => new(value);
        #endregion Operators
    }
}
