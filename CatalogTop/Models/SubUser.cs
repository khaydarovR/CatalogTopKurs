using System;
using System.Collections.Generic;

namespace CatalogTop.Models
{
    public partial class SubUser
    {
        public long SubId { get; set; }
        public long UserId { get; set; }

        public virtual Sub Sub { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
