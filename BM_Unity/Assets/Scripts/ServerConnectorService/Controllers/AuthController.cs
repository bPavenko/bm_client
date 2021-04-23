using System;
using Server.Models;

namespace Server.Controllers
{
    public class AuthController
    {
        public void Auth(string login, string password, Action<AuthResponse> onResponseHandler)
        {
            //TODO: realize authorization to server with login and password
            var response = new AuthResponse
            {
                Status = AuthStatus.Success,
                Data = new UserData()
            };
            onResponseHandler.Invoke(response);//TEMP
        }

        [Serializable]
        public class AuthResponse
        {
            public AuthStatus Status { get; set; }
            public UserData Data { get; set; }
        }

        public enum AuthStatus
        {
            Success,
            UnknownLogin,
            InvalidPassword,
            InvalidOrganizationIp,
            UnknownError
        }
    }
}
