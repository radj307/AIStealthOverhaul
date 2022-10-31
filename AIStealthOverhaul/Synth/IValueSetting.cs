using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace AIStealthOverhaul.Synth
{
    /// <summary>
    /// Represents a wrapper object for a single value type that can be enabled or disabled.<br/>
    /// </summary>
    public interface IValueSetting
    {
        /// <summary>
        /// Allows type-agnostic access to the value of <see cref="ValueSetting{T}.Value"/> as an <see cref="object"/> type.
        /// </summary>
        [Ignore]
        object ValueObject { get; set; }
        /// <summary>
        /// <see langword="true"/> when enabled; otherwise <see langword="false"/>.
        /// </summary>
        [Ignore]
        bool IsEnabled { get; set; }
    }
    //public abstract class ValueSetting<T, TInView> : ValueSetting<T>, IGetValueOrAlternative<TInView>, IValueSetting, IConvertible
    //    where T : IConvertible
    //    where TInView : IConvertible
    //{
    //    #region Constructor
    //    protected ValueSetting(bool enableProperty, T value) : base(enableProperty, value) { }
    //    #endregion Constructor

    //    #region Properties
    //    [Ignore]
    //    public new T Value;

    //    [SettingName(nameof(Value))]
    //    public TInView ValueView
    //    {
    //        get => ToView(Value);
    //        set => Value = FromView(value);
    //    }
    //    #endregion Properties

    //    #region Converters
    //    private static TInView ToView(T value) => (TInView)Convert.ChangeType(value, typeof(TInView));
    //    private static T FromView(TInView viewValue) => (T)Convert.ChangeType(viewValue, typeof(T));
    //    #endregion Converters

    //    public TInView GetValueOrAlternative(TInView defaultValue, out bool changed) => ToView(GetValueOrAlternative(FromView(defaultValue), out changed));
    //}
}
