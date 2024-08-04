namespace Sway.Common;

public static class StoredProcedureNames
{
    public const string GetShoppingCartByUserId = "usp_GetShoppingCartByUserId";

    public const string GetShoppingCartItemsByUserId = "usp_GetUserCartItemDetails";

    public const string CreateNewUser = "usp_CreateNewUser";

    public const string AddItemIntoCartForUser = "usp_AddItemIntoCartForUser";

    public const string IncrementCartItemQuantity = "usp_IncrementCartItemQuantity";

    public const string DecrementCartItemQuantity = "usp_DecrementCartItemQuantity";
}
