using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardController
    {
        private Dictionary<int, Board> boards;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int boardIdCOunter;
        
        

        public BoardController()
        {
            boards = new Dictionary<int, Board>();
            this.boardIdCOunter = 0;
        }

        public Board addBoard(String boardName, User user)
        {
            if (string.IsNullOrWhiteSpace(boardName))
            {
                log.Debug("Attempt to create a board with a invaild name");
                throw new Exception("board name is not valid");
            }

            if (!user.getIsLoggedIn())
            {
                log.Debug("Attempt to create a board when user isn't logged in");
                throw new Exception("User isn't logged in");
            }

            Dictionary<string, Board> userBoardsbyName = user.getBoardListByName();
            Dictionary<int, Board> userBoardsbyId = user.getBoardListById();

            if (userBoardsbyName.ContainsKey(boardName)) // check if user has baord with given name
            {
                log.Debug("a board with this name: " + boardName + " for: " + user.email + " already exists");
                throw new Exception("A board with this name already exist");
            }

            int futureID = boardIdCOunter; //TODO: add counter for id 
            Board toAdd = new Board(boardName, futureID);
            boards.Add(futureID, toAdd); //add new board to gloabal board list
            userBoardsbyName.Add(boardName, toAdd); // add nre board to user board list
            userBoardsbyId.Add(futureID, toAdd);
            log.Debug("a board with this name: " + boardName + " has been add to user: " + user.email);
            boardIdCOunter++;
            return toAdd;
        }

        public void remove(string boardName, User user)
        {
            if (!user.getIsLoggedIn())
            {
                log.Debug("Attempt to remove a board when user isn't logged in");
                throw new Exception("User isn't logged in");
            }

            Dictionary<string, Board> userBoardsbyName = user.getBoardListByName();
            Dictionary<int, Board> userBoardsbyId = user.getBoardListById();
            if (userBoardsbyName.ContainsKey(boardName))
            {
                int boardId = userBoardsbyName[boardName].getID();
                userBoardsbyName.Remove(boardName); //board has been removed from userBoardByName
                userBoardsbyId.Remove(boardId); // board has been removed from the userBoardById
                boards.Remove(boardId); //board has been remove from global board list
                log.Debug("a board with this name : " + boardName + " has been removed from user: " + user.email);
            }
            else
            {
                log.Debug("Attempt to remove a board with this name: " + boardName + " from user: " + user.email +
                          " which doesn't exist");
                throw new Exception("Try to remove a non existing board");
            }
        }

        public void changeState(Task task, User user)
        {
            if (task == null)
            {
                log.Debug("Attempt to advance null task");
                throw new Exception("null pointer exception");
            }

            if (!user.getIsLoggedIn())
            {
                log.Debug("Attempt to remove a board when user isn't logged in");
                throw new Exception("User isn't logged in");
            }

            Dictionary<string, Board> userBoards = user.getBoardListByName();

            Board board = boards[task.getBoardID()];
            if (!userBoards.ContainsKey(board.getName())) //check if user owns this tasks
            {
                log.Debug("user" + user + "doesn't have task" + task.getTitle());
                throw new Exception("user has no permission to advance this task");
            }

            foreach (string state in board.getColumns().Keys) //looking for task state
            {
                foreach (Task t in board.getColumns()[state])
                {
                    if (t.getId() == task.getId())
                    {
                        if (state.Equals("toDo")) //advance task to in progress
                        {
                            board.getColumns()[state].Remove(t);
                            board.getColumns()["inProgress"].Add(t);
                            log.Debug(task.getTitle() + "has advanced from 'toDo' to 'inProgress' ");
                        }

                        else if (state.Equals("inProgress")) // advance to done
                        {
                            board.getColumns()[state].Remove(t);
                            board.getColumns()["done"].Add(t);
                            log.Debug(task.getTitle() + "has advanced from 'inProgress' to 'done' ");
                        }

                        else
                        {
                            log.Debug(user.email + " tried to advance task that is already done");
                            throw new Exception("Try do advance from done");
                        }

                        return; //Break all
                    }
                }
            }
        }
    }
}