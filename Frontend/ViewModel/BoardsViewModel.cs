using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Model;
using Frontend.View;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend.ViewModel
{
    internal class BoardsViewModel : NotifiableObject
    {
        public UserModel UserModel;
        public BackendController controller;
        public BoardModel Board { get; private set; }
        public string Title { get; private set; }
        public BoardsViewModel(UserModel user)
        {
            this.controller = user.Controller;
            this.UserModel = user;
            Title = "Boards of " + user.Email;
            Board = user.getBoards();
        }

        public Response logout()
        {
            try
            {
                return UserModel.Controller.logOut(UserModel.Email);
            }
            catch (Exception e)
            {
                // Message = e.Message;
                return new Response(e.Message, null);
            }
        }
    }
}
