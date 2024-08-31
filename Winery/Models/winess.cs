using Microsoft.AspNetCore.Mvc.Rendering;

namespace Winery.Models
{
    public class winess
    {
        public List<Wine>? Wineis { get; set; }
        public SelectList? WinGen { get; set; }
        public string? WineGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
