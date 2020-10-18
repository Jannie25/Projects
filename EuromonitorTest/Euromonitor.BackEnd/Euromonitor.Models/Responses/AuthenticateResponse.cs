namespace Euromonitor.Models.Responses
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserToken { get; set; }
    }
}
