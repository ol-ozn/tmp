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
        private int boardIdCOunter;


        public BoardController(ServiceFactory serviceFactory)
        {
            boards = new Dictionary<int, Board>();
            userController = serviceFactory.UserController;
            boardIdCOunter = 0;
        }


        /// <summary>
        ///  This method adds a board to a user and to the global boards list.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <returns>The created Board</returns>
        public Board addBoard(string boardName, string email)
        {
            if (string.IsNullOrWhiteSpace(boardName)) // in case the user tries to enter an empty title
            {
                throw new Exception("board name is not valid");
            }

            User user = userController.getUserAndLogeddin(email);

            // if (!user.IsLoggedIn) //TODO: this can be removed
            // {
            //     throw new Exception("User with email " + email + " isn't logged in");
            // }

            Dictionary<string, Board> userBoardsbyName = user.getBoardListByName();
            Dictionary<int, Board> userBoardsbyId = user.getBoardListById();

            if (userBoardsbyName.ContainsKey(boardName)) // check if user has board with given name
            {
                throw new Exception("A board named " + boardName + " already exist");
            }

            int futureID = boardIdCOunter; //TODO: add counter for id 
            Board toAdd = new Board(boardName, futureID);
            toAdd.owner = user.Id; //assigns the board owner to be the User
            userBoardsbyName.Add(boardName, toAdd); // adds the board to users board list by name
            userBoardsbyId.Add(futureID, toAdd); // adds the board to users board list by ID
            boards.Add(futureID, toAdd); // adds the board to the global boards list
            boardIdCOunter++; // advances the global board id counter
            return toAdd;
        }


        /// <summary>
        /// This method lets a user join a board. 
        /// </summary>
        /// <param name="email">// the email of the user that wants to join</param>
        /// <param name="id">// the id of the user that wants to join</param>
        public void joinBoard(string email, int id)
        {
            User currentUser = userController.getUserAndLogeddin(email);

            if (boards.ContainsKey(id))
            {
                Board boardToAdd = boards[id]; // the board to Add
                Dictionary<string, Board>
                    userBoardsByName = currentUser.getBoardListByName(); // the users boards by name
                Dictionary<int, Board> userBoardsById = currentUser.getBoardListById(); // the user boards by Id

                if (!userBoardsByName.ContainsKey(boardToAdd.Name)) // in case the user is not a part of this board 
                {
                    userBoardsByName.Add(boardToAdd.Name, boardToAdd); // adds the board to boards dict by name
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

        /// <summary>
        /// This method lets the owner of the board to transfer it's ownership. 
        /// </summary>
        /// <param name="currentOwnerEmail">// the mail of the owner of the board</param>
        /// <param name="newOwnerEmail">// the mail of the user that will be the new owner of the board</param>
        /// <param name="boardName">// the name of the board </param>
        public void transferOwnerShip(string currentOwnerEmail, string newOwnerEmail, string boardName)
        {
            User currentOwner = userController.getUserAndLogeddin(currentOwnerEmail);
            User newOwner = userController.getUser(newOwnerEmail);


            if (!currentOwner.getBoardListByName().ContainsKey(boardName)) // checks if the user is a member of this board
            {
                throw new Exception("this board does not exist");
            }

            if (newOwner.getBoardListByName().ContainsKey(boardName))
            {
                throw new Exception(newOwnerEmail + " already has board named: " + boardName);
            }

            Board currentBoard = currentOwner.getBoardListByName()[boardName];
            if (currentBoard.owner != currentOwner.Id) // if the user who's trying to perform the action is not the owner
            {
                throw new Exception("a user who is not the owner tried to transfer board ownership");
            }

            if (!currentBoard.MemeberList.Contains(newOwnerEmail))
            {
                throw new Exception(newOwnerEmail + " isn't a member of " + boardName);
            }

            currentBoard.owner = userController.getUser(newOwnerEmail).Id;
        }


        /// <summary>
        /// This method lets a user leave a board unless he's an owner. 
        /// </summary>
        /// <param name="email">// the mail of the user that wants to leave the board</param>
        /// <param name="boardId">// the Id of the board the user wants to leave </param>
        public void leaveBoard(string email, int boardId)
        {
            User leavingUser = userController.getUserAndLogeddin(email);

            if (!leavingUser.getBoardListById().ContainsKey(boardId)) // if the user is already not part of this board
            {
                throw new Exception("The user: " + email + " is already not part of board: " + boardId);
            }

            Board boardToLeave = boards[boardId];
            if (leavingUser.Id == boardToLeave.owner) // in case the user who's trying to leave is the owner
            {
                throw new Exception("user: " + leavingUser + "who's a board owner tried to leave board: " + boardId);
            }

            boardToLeave.MemeberList.Remove(email); // removes the user from the boards users list
            leavingUser.getBoardListById().Remove(boardId); // removes the board from the boardList by ID
            leavingUser.getBoardListByName().Remove(boardToLeave.Name); // removes board from the users list by name
            foreach (Task task in boardToLeave.getColumn(boardToLeave.columnsId.FirstOrDefault(x => x.Value == "backlog").Key))
            {
                if (task.Assignie.Equals(email))
                {
                    task.Assignie = null;
                }
            }

            foreach (Task task in boardToLeave.getColumn(boardToLeave.columnsId.FirstOrDefault(x => x.Value == "in progress").Key))
            {
                if (task.Assignie.Equals(email))
                {
                    task.Assignie = null;
                }
            }
        }

        /// <summary>
        /// This method lets a user remove a board if he's the owner
        /// </summary>
        /// <param name="boardName">// the mail of the user that wants to leave the board</param>
        /// <param name="email">// the Id of the board the user wants to leave </param>
        public void removeBoard(string boardName, string email)
        {
            User owner = userController.getUserAndLogeddin(email);

            Dictionary<string, Board> userBoardsbyName = owner.getBoardListByName();
            Dictionary<int, Board> userBoardsbyId = owner.getBoardListById();
            
            if (!userBoardsbyName.ContainsKey(boardName))
            {
                throw new Exception("Try to remove a board with the name " + boardName + " which doesn't exist to the email: " + email);
            }
            Board board = userBoardsbyName[boardName];
            if (!board.owner.Equals(owner.Id))
            {
                throw new Exception(email + " is not the owner of " + boardName);
            }

            if (board.MemeberList != null) //no need for exception, if null then only owner is in the board
            {
                foreach (string username in board.MemeberList) //remove board from all members 
                {
                    User user = userController.getUser(username);
                    user.getBoardListByName().Remove(boardName);
                    user.getBoardListById().Remove(board.Id);
                }
            }

            userBoardsbyName.Remove(boardName); //board has been removed from userBoardByName
            userBoardsbyId.Remove(board.Id); // board has been removed from the userBoardById


            boards.Remove(board.Id); // removes the board from the global board list
           
        }
    }
}