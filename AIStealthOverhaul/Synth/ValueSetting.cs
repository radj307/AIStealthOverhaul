using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace AIStealthOverhaul.Synth
{
    /// <summary>
    /// Wrapper object for a single value of type <typeparamref name="T"/> that also exposes a boolean that allows the user to disable the application of the value.
    /// </summary>
    /// <remarks>
    /// See <see cref="ClassSetting{T}"/>, <see cref="StructSetting{T}"/>, &amp; <see cref="EnumSetting{T}"/> for ready-to-use classes that implement <see cref="ValueSetting{T}"/>.
    /// </remarks>
    /// <typeparam name="T">The value type to wrap.</typeparam>
    public abstract class ValueSetting<T> : IGetValueOrAlternative<T>, IValueSetting, IConvertible
        where T : IConvertible
    {
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="ValueSetting{T}"/> instance.
        /// </summary>
        /// <param name="enableProperty"><see cref="EnableSetting"/></param>
        /// <param name="value"><see cref="Value"/></param>
        protected ValueSetting(bool enableProperty, T value)
        {
            EnableSetting = enableProperty;
            Value = value;
        }
        #endregion Constructor

        #region Fields
        /// <summary>
        /// When <see langword="true"/>, the setting is enabled; otherwise it is disabled. This setting's <see cref="Value"/> field is only applied to records when this is enabled.
        /// </summary>
        [Tooltip("This MUST be checked to apply the Value to records. When unchecked, the associated Value property is skipped, and no changes are made to the original value.")]
        public bool EnableSetting = false;
        /// <summary>
        /// The current value of this setting.
        /// </summary>
        public T Value;
        #endregion Fields

        #region Properties
        [Ignore]
        public object ValueObject
        {
            get => Value;
            set => Value = (T)value;
        }
        [Ignore]
        public bool IsEnabled
        {
            get => EnableSetting;
            set => EnableSetting = value;
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Gets the value of <see cref="Value"/> if it is <b>not</b> <see langword="null"/>.
        /// </summary>
        /// <param name="defaultValue">Some other value</param>
        /// <returns><see cref="Value"/> when <see cref="EnableSetting"/> is <see langword="true"/>; otherwise <paramref name="defaultValue"/>.</returns>
        public virtual T GetValueOrAlternative(T defaultValue, out bool changed)
        {
            T val = EnableSetting ? Value : defaultValue;
            changed = !defaultValue!.Equals(val);
            return val;
        }

        public TypeCode GetTypeCode() => Value.GetTypeCode();
        public bool ToBoolean(IFormatProvider? provider) => Value.ToBoolean(provider);
        public byte ToByte(IFormatProvider? provider) => Value.ToByte(provider);
        public char ToChar(IFormatProvider? provider) => Value.ToChar(provider);
        public DateTime ToDateTime(IFormatProvider? provider) => Value.ToDateTime(provider);
        public decimal ToDecimal(IFormatProvider? provider) => Value.ToDecimal(provider);
        public double ToDouble(IFormatProvider? provider) => Value.ToDouble(provider);
        public short ToInt16(IFormatProvider? provider) => Value.ToInt16(provider);
        public int ToInt32(IFormatProvider? provider) => Value.ToInt32(provider);
        public long ToInt64(IFormatProvider? provider) => Value.ToInt64(provider);
        public sbyte ToSByte(IFormatProvider? provider) => Value.ToSByte(provider);
        public float ToSingle(IFormatProvider? provider) => Value.ToSingle(provider);
        public string ToString(IFormatProvider? provider) => Value.ToString(provider);
        public object ToType(Type conversionType, IFormatProvider? provider) => Value.ToType(conversionType, provider);
        public ushort ToUInt16(IFormatProvider? provider) => Value.ToUInt16(provider);
        public uint ToUInt32(IFormatProvider? provider) => Value.ToUInt32(provider);
        public ulong ToUInt64(IFormatProvider? provider) => Value.ToUInt64(provider);
        #endregion Methods
    }
}
