using System;

namespace StealthOverhaul.Synth
{
    /// <summary>
    /// Provides a toggleable value for an <see cref="Enum"/> type.
    /// </summary>
    /// <typeparam name="T">Any type that inherits from <see cref="Enum"/> (any enum type).<br/>For enums with <see cref="FlagsAttribute"/>, see <see cref="FlagSetting{T}"/>.</typeparam>
    public class EnumSetting<T> : ValueSetting<T> where T : struct, Enum
    {
        #region Constructors
        /// <summary>
        /// Creates a new disabled <see cref="EnumSetting{T}"/> instance with the default value.
        /// </summary>
        public EnumSetting() : base(false, default) { }
        /// <summary>
        /// Creates a new enabled <see cref="EnumSetting{T}"/> instance with the given <paramref name="value"/> if it isn't <see langword="null"/>; otherwise creates a new disabled instance with the default value.
        /// </summary>
        /// <param name="value">A starting value of type <typeparamref name="T"/>.<br/>When this is <see langword="null"/>, the base <see cref="ValueSetting{T}"/> starts disabled.</param>
        public EnumSetting(T? value) : base(value is not null, value ?? default) { }
        #endregion Constructors

        #region Operators
        public static implicit operator EnumSetting<T>(T? value) => new(value);
        #endregion Operators
    }
}
