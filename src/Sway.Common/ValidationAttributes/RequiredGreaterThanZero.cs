namespace Sway.Common.ValidationAttributes;

using System.ComponentModel.DataAnnotations;

public sealed class RequiredGreaterThanZero : ValidationAttribute
{
    /// <summary>
    /// Validates a value that is integer greater than zero.
    /// </summary>
    /// <param name="value">The integer value.</param>
    /// <returns><c>true</c> if it is greater than zero.</returns>
    public override bool IsValid(object? value)
    {
        return value != null && int.TryParse(value.ToString(), out var i) && i > 0;
        return value is int integer && integer > 0;
    }
}
