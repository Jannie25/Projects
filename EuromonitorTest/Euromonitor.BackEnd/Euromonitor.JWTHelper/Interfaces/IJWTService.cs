using Euromonitor.Models.General;

namespace Euromonitor.JWTHelper.Interfaces
{
    public interface IJWTService
    {
        string GenerateSecurityToken(User user);
    }
}
