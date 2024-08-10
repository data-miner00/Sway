namespace Sway.Web.Mvc;

using System.Diagnostics.CodeAnalysis;

internal static class Constants
{
    public const string Success = "success";

    public const string Error = "error";

    public const string Title = "Title";

    #region (( Development ))
    public const string TestUserId = "2BA7AD7C-4731-43BF-AE9C-28B0BD2B0095";

    [SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Development only")]
    public const string TestItemPhotoUrl = "https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.jpg";
    #endregion
}
