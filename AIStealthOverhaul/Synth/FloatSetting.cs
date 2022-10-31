namespace AIStealthOverhaul.Synth
{
    public class FloatSetting : StructSetting<float>, IConvertible
    {
        #region Constructors
        public FloatSetting() : base(null) { }
        public FloatSetting(float? value) : base(value) { }
        public FloatSetting(double? value) : base(value is null ? null : Convert.ToSingle(value)) { }
        public FloatSetting(decimal? value) : base(value is null ? null : Convert.ToSingle(value)) { }
        #endregion Constructors

        #region Operators
        public static implicit operator FloatSetting(float? value) => new(value);
        public static implicit operator FloatSetting(double? value) => new(value);
        public static implicit operator FloatSetting(decimal? value) => new(value);
        public static implicit operator float(FloatSetting setting) => setting.Value;
        public static implicit operator double(FloatSetting setting) => setting.Value;
        public static implicit operator decimal(FloatSetting setting) => (decimal)setting.Value;
        #endregion Operators
    }
}
