namespace PersonalCollection.Domain
{
    public static class Constants
    {
        public const string AdminRole = "Admin";

        public const int DbFieldShortStringLenght = 50;
        public const int DbFieldLongStringLenght = 500;

        public const string PolicyAdminOnly = "AdminOnly";
        public const string PolicyCanManageCollection = "CanManageCollection";
        public const string PolicyUserNotBlocked = "UserNotBlocked";
        public const string PolicyUserNotBlockedOrAnonymous = "UserNotBlockedOrAnonymous";

        public const int CustomFieldsCount = 3;

        public const string NavCollections = "collections";
        public const string NavItems = "items";
        public const string NavEdit = "edit";
        public const string NavCreate = "create";
        public const string NavCollectionId = "{CollectionId:int}";
        public const string NavItemId = "{ItemId:int}";
        public const string NavSearch = "search";

        public const string AppRouteUserManager = "/usermanager";
        public const string AppRouteCollections = $"/{NavCollections}";
        public const string AppRouteCollectionCreate = $"/{NavCollections}/{NavCreate}";
        public const string AppRouteCollectionDetails = $"/{NavCollections}/{NavCollectionId}";
        public const string AppRouteCollectionEdit = $"/{NavCollections}/{NavCollectionId}/{NavEdit}";
        public const string AppRouteItemCreate = $"/{NavCollections}/{NavCollectionId}/{NavCreate}";
        public const string AppRouteItemDetails = $"/{NavItems}/{NavItemId}";
        public const string AppRouteItemEdit = $"/{NavItems}/{NavItemId}/{NavEdit}";
        public const string AppRouteSearch = $"/{NavSearch}";
        public const string AppRouteNotFound = "/notfound";
        public const string AppRouteAccessDenied = "/Account/AccessDenied";

        public const string ParameterSearchTag = "SearchTag";
        public const string ParameterSearchString = "SearchString";

        public const string HubName = "/commentshub";
        public const string HubSendCommentsUpdate = "SendCommentsUpdate";
        public const string HubReceiveCommentsUpdate = "ReceiveCommentsUpdate";
        public const string HubJoinGroup = "JoinGroup";
        public const string HubLeaveGroup = "LeaveGroup";

        public const string RU = "ru-RU";
        public const string EN = "en-US";

        public const string JSGetTimeOffsetFuncName = "getTimezoneOffset";
        public const string EnvVariableSecrets = "PersonalCollectionSecrets";
    }
}
