using Mutagen.Bethesda.WPF.Reflection.Attributes;

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
}
