using System;
using System.Collections.Generic;

namespace CatalogTop.Models
{
    public partial class Status
    {
        public Status()
        {
            Users = new HashSet<User>();
        }

        public string Title { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
