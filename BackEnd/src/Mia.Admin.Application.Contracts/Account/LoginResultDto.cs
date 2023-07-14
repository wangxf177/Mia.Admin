namespace Mia.Admin.Account
{
    public class LoginResultDto
    {
        public LoginResultDto(string accessToken, string refreshToken, string userName)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Username = userName;
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
    }
}
