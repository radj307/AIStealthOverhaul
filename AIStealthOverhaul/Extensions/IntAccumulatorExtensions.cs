namespace AIStealthOverhaul.Extensions
{
    internal static class IntAccumulatorExtensions
    {
        public static int RefAdd(this ref int i, params bool[] booleans) => i += booleans.Count(b => b);
        public static int RefAdd(this ref int i, params int[] integrals) => i += integrals.Sum();
        public static int RefAdd(this ref int i, params uint[] unsignedIntegrals) => i += unsignedIntegrals.Cast<int>().Sum();
    }
}
