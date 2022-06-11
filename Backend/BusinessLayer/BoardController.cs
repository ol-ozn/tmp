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
            User currentUser = userController.getUser(email);
            if (!currentUser.getIsLoggedIn())
            {
                throw new Exception("User is not logged in");
            }

            if (boards.ContainsKey(id))
            {
                Board boardToAdd = boards[id]; // the board to Add
                Dictionary<string, Board>
                    userBoardsByName = currentUser.getBoardListByName(); // the users boards by name
                Dictionary<int, Board> userBoardsById = currentUser.getBoardListById(); // the user boards by Id

                if (!userBoardsByName.ContainsKey(boardToAdd
                        .getName())) // in case the user is not a part of this board 
                {
                    userBoardsByName.Add(boardToAdd.getName(), boardToAdd); // adds the board to boards dict by name
                }
                else // else the user is already part of this board
                {
                    throw new Exception("user: " + email + " is already part of this board");
                }

                if (!userBoardsById.ContainsKey(id))
                {
                    userBoardsById.Add(id, boardToAdd); // adds the board to the users boards dict by Id
                }
                else // else the user is already part of this board
                {
                    throw new Exception("user: " + email + " is already part of this board");
                }

                boardToAdd.MemeberList.Add(email); //adds the user to the members list of the board
            }
            else
            {
                throw new Exception("board with: " + id + "does not exist");
            }
        }

        public void transferOwnerShip(string currentOwnerEmail, string newOwnerEmail, string boardName)
        {
            return;
        }

        public void leaveBoard(string email, int boardId)
        {
            return;
        }

        public void removeBoard(string email, string name)
        {
            return;
        }
    }
}