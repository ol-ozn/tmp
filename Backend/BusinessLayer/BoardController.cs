using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardController
    {
        private Dictionary<int, Board> boards;
        private UserController userController;


        public BoardController(ServiceFactory factory)
        {
            boards = new Dictionary<int, Board>();
            userController = factory.UserController;
        }

        public void joinBoard(string email, int id)
        {
            return;
        }

        public void transferOwnerShip(string currentOwnerEmail, string newOwnerEmail, string boardName)
        {
            return;
        }

        public void leaveBoard(string email, int boardId)
        {
            return;
        }
    }
}