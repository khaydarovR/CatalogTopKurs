using System;
using System.Collections.Generic;

namespace CatalogTop.Models
{
    public partial class Store
    {
        public Store()
        {
            StoreItems = new HashSet<StoreItem>();
        }

        public short Id { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
