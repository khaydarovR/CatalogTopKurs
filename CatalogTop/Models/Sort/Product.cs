namespace CatalogTop.Models.Sort
{
    public partial class Product
    {
        public Product()
        {
            StoreItems = new HashSet<StoreItem>();
        }

        public long Id { get; set; }
        public string? Model { get; set; }
        public string PType { get; set; } = null!;
        public string? PhotoUrl { get; set; }

        public virtual PType PTypeNavigation { get; set; } = null!;
        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
