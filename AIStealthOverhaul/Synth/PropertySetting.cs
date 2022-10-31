namespace AIStealthOverhaul.Synth
{
    public class PropertySetting<T>
        where T : struct, IConvertible
    {
        public PropertySetting(T? value)
        {
            EnableProperty = value is not null;
            _value = value ?? default;
        }
        public PropertySetting() : this(null) { }

        public bool EnableProperty;
        private T _value;
        public T Value
        {
            get => _value;
            set
            {

                _value = value;
            }
        }
    }
}
