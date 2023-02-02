using LoginServer.API.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.API.Entities.Response
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDTO PersonalDetails { get; set; }
    }
}
