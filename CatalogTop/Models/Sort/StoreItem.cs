using System;
using System.Collections.Generic;

namespace CatalogTop.Models.Sort
{
    public partial class StoreItem
    {
        public long Id { get; set; }
        public long PId { get; set; }
        public short SId { get; set; }
        public int? Price { get; set; }
        public string Link { get; set; } = null!;

        public virtual Product PIdNavigation { get; set; } = null!;
        public virtual Store SIdNavigation { get; set; } = null!;
    }
}
