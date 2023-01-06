namespace CatalogTop.Models.Sort
{
    public partial class NumAtr
    {
        public long PId { get; set; }
        public string AtrKey { get; set; } = null!;
        public float? AtrValue { get; set; }

        public virtual Product PIdNavigation { get; set; } = null!;
    }
}
