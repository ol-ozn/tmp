using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend.Model
{
    public class BackendController
    {
        private ServiceFactory serviceFactory;


        public BackendController(ServiceFactory service)
        {
            this.serviceFactory = service;
        }

        public BackendController()
        {
            this.serviceFactory = new ServiceFactory();
            serviceFactory.LoadData();
        }

        public Response Login(string username, string password)
        {
            Response response = serviceFactory.userService.login(username, password);
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            // return new UserModel(this, username);
            return response;
        }

        public Response Register(string username, string password)
        {
            Response response = serviceFactory.userService.createUser(username, password);
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            return response;
        }
    }
}