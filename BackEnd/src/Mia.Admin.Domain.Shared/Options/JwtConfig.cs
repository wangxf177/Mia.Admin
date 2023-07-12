namespace Mia.Admin.Options
{
    public class JwtConfig
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpiryInMinutes { get; set; } = 1440;
        public int RefreshExpiryInMinutes { get; set; } = 43200;
    }
}
