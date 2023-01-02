using System;
using System.Collections.Generic;

namespace CatalogTop.Models
{
    public partial class StrAtr
    {
        public long? PId { get; set; }
        public string AtrKey { get; set; } = null!;
        public string? AtrValue { get; set; }

        public virtual Product? PIdNavigation { get; set; }
    }
}
