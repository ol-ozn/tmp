using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.BusinessLayer;
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

        public Response<string> Login(string username, string password)
        {
            Response<string> response = JsonController<string>.fromJson(serviceFactory.userService.login(username, password));
            
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            // return new UserModel(this, username);
            return response;
        }

        public Response<string> Register(string username, string password)
        {
            Response<string> response = JsonController<string>.fromJson(serviceFactory.userService.createUser(username, password));
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            return response;
        }

        public Response<string> logOut(string username)
        {
            Response<string> response = JsonController<string>.fromJson(serviceFactory.userService.logout(username));
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            // return new UserModel(this, username);
            return response;
        }

        public Response<List<int>> getBoards(string username)
        {
            Response<List<int>> response = JsonController<List<int>>.fromJson(serviceFactory.userService.GetUserBoards(username));
            if (response.ErrorMessage != null)
            {
                throw new Exception(response.ErrorMessage);
            }

            // return new UserModel(this, username);
            return response;
        }
    }
}