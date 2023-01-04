using System.ComponentModel;

namespace CatalogTop.Helpers
{
    public enum UserStatusEnum
    {
        [Description("Аноним")]
        Unknown = 0,

        [Description("Новый пользователь")]
        NewUser = 1,

        [Description("Подтвержденный пользователь")]
        User = 2,

        [Description("Модератор")]
        Moderator = 3,

        [Description("Администратор")]
        Admin = 4,

        [Description("root")]
        SuperAdmin = 5
    }
}
