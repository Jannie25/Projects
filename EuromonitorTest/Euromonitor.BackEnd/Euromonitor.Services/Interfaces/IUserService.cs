using Euromonitor.Models.Requests;
using Euromonitor.Models.Responses;

namespace Euromonitor.Services.Interfaces
{
    public interface IUserService
    {
        bool Register(RegisterRequest model);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
