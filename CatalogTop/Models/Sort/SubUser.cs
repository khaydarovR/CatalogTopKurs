using CatalogTop.Models.Account;

namespace CatalogTop.Models.Sort
{
    public partial class SubUser
    {
        public long SubId { get; set; }
        public long UserId { get; set; }

        public virtual Sub Sub { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
