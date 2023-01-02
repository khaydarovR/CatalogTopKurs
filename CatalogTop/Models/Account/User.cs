using System;
using System.Collections.Generic;

namespace CatalogTop.Models.Account
{
    public partial class User
    {
        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public DateOnly? LastVisit { get; set; }
        public int? Coin { get; set; }
        public string Status { get; set; } = null!;

        public virtual Status StatusNavigation { get; set; } = null!;
    }
}
