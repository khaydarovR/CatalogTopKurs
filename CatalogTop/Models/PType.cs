using System;
using System.Collections.Generic;

namespace CatalogTop.Models
{
    public partial class PType
    {
        public PType()
        {
            Products = new HashSet<Product>();
        }

        public string Title { get; set; } = null!;
        public string? IconUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
