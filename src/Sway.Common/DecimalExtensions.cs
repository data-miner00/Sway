namespace Sway.Common;

public static class DecimalExtensions
{
    public static string ToMoney(this decimal value)
    {
        return value.ToString("0.00");
    }

    public static string ToMoney(this decimal value, string currencySymbol)
    {
        return string.Concat(currencySymbol, value.ToMoney());
    }
}
