namespace AuthServer.Api.Models
{
    public class LoginResponse
    {
        public bool IsLogedIn { get; set; } = false;
        public string Token { get; set; }
        public string RefreshToken { get; internal set; }
    }
}
