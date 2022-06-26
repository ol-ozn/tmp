using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class UserModel : NotifiableModelObject
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                this.email = value;
                RaisePropertyChanged("Username");
            }
        }


        // private string password;
        //
        // public string Password
        // {
        //     get { return password; }
        //     set
        //     {
        //         this.password = value;
        //         RaisePropertyChanged("Password");
        //     }
        // }

        //TODO: add board Model

        public UserModel(BackendController controller, string email) : base(controller)
        {
            this.Email = email;
        }
    }
}