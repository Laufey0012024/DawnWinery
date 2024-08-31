namespace Winery.Models
{
    public class Wine
    {
        public int WineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Vintage { get; set; } = string.Empty;
        public string WineSize { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal WinePrice { get; set; }
    }
}
