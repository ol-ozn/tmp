using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class User
    {
        private readonly int id;
        public string email;
        private string password;
        private bool isLoggedIn;
        private Dictionary<string, Board> boardListByName;
        private Dictionary<int, Board> boardListById;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //when we create user, we assume that all the fields are valid
        public User(string email, string password, int id)
        {
            this.id = id; //consider dropping id for user (ONLY)
            this.email = email;
            this.password = password;
            isLoggedIn = false;
            boardListByName = new Dictionary<string, Board>();
            boardListById = new Dictionary<int, Board>();
        }

        public bool getIsLoggedIn()
        {
            return isLoggedIn;
        }

        public void setIsLoggedIn(bool value)
        {
            if (value)
                log.Debug(email + " logged in successfully");
            else
                log.Debug(email + " logged out successfully");

            isLoggedIn = value;
        }

        public void changePassword(string password)
        {
            this.password = password;
        }

        public void login(string password)
        {
            if (password.Equals(this.password))
                setIsLoggedIn(true);
            else
            {
                log.Debug("Attempt to log in to " + email + " with wrong password.");
                throw new Exception("Wrong password");
            }
        }

        public Task findTask(int taskId)
        {
            foreach (Board board in boardListByName.Values)
            {
                //TODO: find better way to iterate over dict
                List<Task> toDoList = (board.getColumns())["toDo"];
                foreach (Task task in toDoList)
                {
                    if (taskId == task.getId())
                        return task;
                }

                List<Task> inProgressList = (board.getColumns())["inProgress"];
                foreach (Task task in inProgressList)
                {
                    if (taskId == task.getId())
                        return task;
                }

                List<Task> doneList = (board.getColumns())["done"];
                foreach (Task task in doneList)
                {
                    if (taskId == task.getId())
                        return task;
                }
            }

            throw new Exception("Given task doesn't exist in any of this user's boards");
        }

        public List<Task> listInProgress()
        {
            List<Task> list = new List<Task>();
            foreach (Board board in boardListByName.Values)
            {
                List<Task> l = (board.getColumns())["inProgress"];
                foreach (Task task in l)
                {
                    list.Add(task);
                }
            }

            return list;
        }

        public Dictionary<string, Board> getBoardListByName()
        {
            return boardListByName;
        }

        public Dictionary<int, Board> getBoardListById()
        {
            return boardListById;
        }

        public Board hasBoardByName(string boardName)
        {
            if (boardListByName.ContainsKey(boardName))
            {
                return boardListByName[boardName];
            }
            else
            {
                throw new Exception("The user doesn't own board with given name");
            }
        }

        public Board hasBoardById(int boardId)
        {
            if (boardListById.ContainsKey(boardId))
            {
                return boardListById[boardId];
            }
            else
            {
                throw new Exception("The user doesn't own board with given id");
            }
        }
    }
}