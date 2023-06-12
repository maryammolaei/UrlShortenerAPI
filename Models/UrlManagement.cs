namespace UrlShortener.Models
{
    public class UrlManagement: BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
    }
}
