using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class UserDTO : DTO
    {
        public const string UsersEmailColumnName = "email";
        public const string UsersPasswordColumnName = "password";

        private string email;
        public string Email { get => email;set { email = value; _controller.Update(id,UsersEmailColumnName,value); } }
        
        private string password;
        public string Password { get => password; set { password = value; _controller.Update(id, UsersPasswordColumnName, value); } }

        public UserDTO(long id, string email, string password) : base(new UserDalController())
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }
    }
}
