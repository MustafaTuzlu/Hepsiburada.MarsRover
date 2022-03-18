namespace HepsiBurada.MarsRover.Data.Const
{
    public enum DirectionEnum
    {
        N, E, S, W
    }

    public static class EnumExtensions
    {
        public static T ToEnumValue<T>(this string value) where T : System.Enum
        {
            try
            {
                return (T)System.Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default;
            }
        }
    }
}
