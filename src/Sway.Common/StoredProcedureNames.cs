namespace Sway.Common;

public static class StoredProcedureNames
{
    public const string GetShoppingCartByUserId = "usp_GetShoppingCartByUserId";

    public const string GetShoppingCartItemsByUserId = "usp_GetUserCartItemDetailsSorted";

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

    public const string UpdateUserProfile = "usp_UpdateUserProfile";

    public const string SelectCartItem = "usp_SelectCartItem";

    public const string DeselectCartItem = "usp_DeselectCartItem";

    public const string GetSelectedUserCartItemDetailsSorted = "usp_GetSelectedUserCartItemDetailsSorted";

    public const string AddAddress = "usp_AddAddress";

    public const string UpdateAddress = "usp_UpdateAddress";

    public const string DeleteAddressById = "usp_DeleteAddressById";

    public const string AddPaymentMethod = "usp_AddPaymentMethod";

    public const string UpdatePaymentMethod = "usp_UpdatePaymentMethod";

    public const string DeletePaymentMethodById = "usp_DeletePaymentMethodById";

    public const string UpdateUserPassword = "usp_UpdateUserPasswordV2";

    public const string AddNotification = "usp_AddNotification";

    public const string GetNotificationsByUserId = "usp_GetNotificationsByUserId";

    public const string MarkNotificationAsRead = "usp_MarkNotificationsAsRead";

    public const string AddOrder = "usp_AddOrder";

    public const string ClearOrderedCartItemsForUser = "usp_ClearOrderedCartItemsForUser";

    public const string GetOrderLinesByOrderId = "usp_GetOrderLinesByOrderId";

    public const string CopyAddressToOrderAddress = "usp_CopyAddressToOrderAddress";

    public const string CopyPaymentMethodsToOrderPaymentMethods = "usp_CopyPaymentMethodToOrderPaymentMethods";

    public const string GetCouponsForUser = "usp_GetCouponsForUser";

    public const string DeleteCouponById = "usp_DeleteCouponById";

    public const string AddCouponForUser = "usp_AddCouponForUser";
}
