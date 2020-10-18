using Euromonitor.Models.General;
using Euromonitor.Models.Requests;

namespace Euromonitor.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool InsertUser(RegisterRequest model);
        User GetUser(AuthenticateRequest model);
    }
}
