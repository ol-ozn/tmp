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
            User currentOwner = userController.getUser(currentOwnerEmail);
            if (!currentOwner.getIsLoggedIn()) // if the user is not logged in 
            {
                throw new Exception("User is not logged in");
            }

            if (currentOwner.getBoardListByName()
                .ContainsKey(boardName)) // checks if the user is a member of this board
            {
                Board currentBoard =
                    currentOwner
                        .getBoardListByName()[
                            boardName]; // but what happens if there are 2 boards with the same name???
                if (currentBoard.Owner !=
                    currentOwner.ID) // if the user who's trying to perform the action is not the owner
                {
                    throw new Exception("a user who is not the owner tried to transfer board ownership");
                }

                currentBoard.Owner =
                    userController.getUser(newOwnerEmail).ID; // maybe I should also check whether the new user is part of that board and if not add him
            }
            else
            {
                throw new Exception("this board does not exist");
            }
        }

        public void leaveBoard(string email, int boardId)
        {
            User leavingUser = userController.getUser(email);
            if (!leavingUser.getIsLoggedIn()) // if the user is not logged in 
            {
                throw new Exception("User is not logged in");
            }

            if (!leavingUser.getBoardListById().ContainsKey(boardId)) // if the user is already not part of this board
            {
                throw new Exception("The user: " + email + " is already not part of board: " + boardId);
            }

            Board boardToLeave = boards[boardId];
            if (leavingUser.ID == boardToLeave.Owner) // in case the user who's trying to leave is the owner
            {
                throw new Exception("user: " + leavingUser + "who's a board owner tried to leave board: " + boardId);
            }

            boardToLeave.MemeberList.Remove(email); // removes the user from the boards users list
            leavingUser.getBoardListById().Remove(boardId); // removes the board from the boardList by ID
            leavingUser.getBoardListByName().Remove(boardToLeave.getName()); // removes board from the users list by name
            //TODO: needs to implement all users tasks on this board that he's assigned to should change to unassigned 
        }

        public void removeBoard(string email, string name)
        {
            return;
        }
    }
}