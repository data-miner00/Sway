﻿namespace Sway.Common;

public static class StoredProcedureNames
{
    public const string GetShoppingCartByUserId = "usp_GetShoppingCartByUserId";

    public const string GetShoppingCartItemsByUserId = "usp_GetUserCartItemDetails";

    public const string CreateNewUser = "usp_CreateNewUser";

    public const string AddItemIntoCartForUser = "usp_AddItemIntoCartForUser";

    public const string IncrementCartItemQuantity = "usp_IncrementCartItemQuantity";

    public const string DecrementCartItemQuantity = "usp_DecrementCartItemQuantity";

    public const string SoftDeleteCartItem = "usp_SoftDeleteCartItem";

    public const string UndoDeletedCartItem = "usp_UndoDeletedCartItem";

    public const string AddProductRating = "usp_AddProductRating";

    public const string UpdateProductRatingById = "usp_UpdateProductRatingById";

    public const string DeleteProductRatingById = "usp_DeleteProductRatingById";

    public const string GetRatingsForProduct = "usp_GetRatingsForProduct";

    public const string AddFavourite = "usp_AddFavourite";

    public const string DeleteFavourite = "usp_DeleteFavourite";

    public const string GetAddressesByUserId = "usp_GetAddressesByUserId";
}
