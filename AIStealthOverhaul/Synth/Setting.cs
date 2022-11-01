using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AIStealthOverhaul.Synth
{
    public interface IValue
    {
        [Ignore]
        object? ValueObject { get; set; }
    }
    public interface IValue<T> : IValue
    {
        abstract T Value { get; set; }
    }

    public abstract class SettingValue : IValue
    {
        public static readonly SettingValue<byte> Default = new(default);

        public abstract object? ValueObject { get; set; }

        public static SettingValue<T> NewValue<T>(T value) => new(value);
        public static SettingValue<T> NewValue<T>() => new();
    }
    public class SettingValue<T> : SettingValue, IValue<T>, IValue
    {
        public SettingValue(T value) => Value = value;
        public SettingValue() => Value = Activator.CreateInstance<T>();

        public T Value { get; set; }
        [JsonIgnore]
        [Ignore]
        public override object? ValueObject
        {
            get => Value;
            set
            {
                if (value is T valueAsT)
                {
                    Value = valueAsT;
                }
            }
        }

        public new static readonly SettingValue<T> Default = new();

        public static SettingValue<T> NewValue(T value) => new(value);
        public static SettingValue<T> NewValue() => new();
    }

    public interface ISetting : IValue
    {
        bool IsEnabled { get; set; }
    }
    public interface ISetting<T> : ISetting, IValue, IGetValueOrAlternative<T> { }

    public abstract class Setting : ISetting, IValue
    {
        [JsonProperty]
        public const string IsEnabledName = "Enable";
        [SettingName(IsEnabledName)]
        public abstract bool IsEnabled { get; set; }
        public abstract object? ValueObject { get; set; }
    }
    public class Setting<T> : Setting, ISetting<T>, ISetting, IValue<T>, IValue
    {
        public Setting(T value) => ValueContainer = SettingValue.NewValue(value);
        public Setting() => ValueContainer = SettingValue.NewValue<T>();

        public override bool IsEnabled { get; set; }
        [Ignore]
        [JsonIgnore]
        public IValue<T> ValueContainer { get; set; }
        [Ignore]
        [JsonIgnore]
        public override object? ValueObject
        {
            get => ValueContainer.ValueObject;
            set => ValueContainer.ValueObject = value;
        }
        public T Value
        {
            get => ValueContainer.Value;
            set => ValueContainer.Value = value;
        }

        public T GetValueOrAlternative(T defaultValue, out bool changed) => throw new NotImplementedException();
    }
}
