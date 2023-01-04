using CatalogTop.Models;
using CatalogTop.Models.Account;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CatalogTop.Helpers
{
    public static class DbInit
    {
        public static void InsertUserStatus(CatalogDbContext context)
        {
            try
            {
                context.Statuses.Add(new Status() { Title = GetEnumDescription(UserStatusEnum.SuperAdmin)});
                context.Statuses.Add(new Status() { Title = GetEnumDescription(UserStatusEnum.Admin) });
                context.Statuses.Add(new Status() { Title = GetEnumDescription(UserStatusEnum.Moderator) });
                context.Statuses.Add(new Status() { Title = GetEnumDescription(UserStatusEnum.User) });
                context.Statuses.Add(new Status() { Title = GetEnumDescription(UserStatusEnum.NewUser) });
                context.Statuses.Add(new Status() { Title = GetEnumDescription(UserStatusEnum.Unknown) });

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex + ": Status insert to DB error");
            }

        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
