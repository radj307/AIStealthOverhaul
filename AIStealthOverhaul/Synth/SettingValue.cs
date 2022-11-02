using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Newtonsoft.Json;

namespace AIStealthOverhaul.Synth
{
    public abstract class SettingValue : IValue
    {
        public static readonly SettingValue<byte> Default = new(default);

        public abstract object? ValueObject { get; set; }

        public static SettingValue<T> NewValue<T>(T value) => new(value);
        public static SettingValue<T> NewValue<T>() => new();
    }
    public class SettingValue<T> : SettingValue, IValue<T>, IValue
    {
        public SettingValue(T value) => this.Value = value;
        public SettingValue() => this.Value = Activator.CreateInstance<T>();

        public T Value { get; set; }
        [Ignore]
        [JsonIgnore]
        public override object? ValueObject
        {
            get => this.Value;
            set
            {
                if (value is null) return;
                if (value is T valueAsT)
                {
                    this.Value = valueAsT;
                }
                else throw new InvalidOperationException($"Cannot cast from object type \"{value.GetType().FullName}\" to \"{typeof(T).FullName}\"!");
            }
        }

        public static new readonly SettingValue<T> Default = new();

        public static SettingValue<T> NewValue(T value) => new(value);
        public static SettingValue<T> NewValue() => new();

        #region Operators
        public static implicit operator SettingValue<T>(T value) => new(value);
        #endregion Operators
    }
}
