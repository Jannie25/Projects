using Euromonitor.JWTHelper.Interfaces;
using Euromonitor.Models.General;
using Euromonitor.Models.Requests;
using Euromonitor.Models.Responses;
using Euromonitor.Repository.Interfaces;
using Euromonitor.Services.Interfaces;

namespace Euromonitor.Services.Classes
{
    public class UserService : IUserService
    {
        private IJWTService _jwtService;
        private IUserRepository _userRepository;

        public UserService(IJWTService jwtService, IUserRepository userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        public bool Register(RegisterRequest model)
        {
            return _userRepository.InsertUser(model);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository.GetUser(model);

            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = _jwtService.GenerateSecurityToken(user);

            return new AuthenticateResponse
            {
                UserId = user.UserId,
                UserName = user.Username,
                UserToken = token
            };
        }
    }
}