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
}
