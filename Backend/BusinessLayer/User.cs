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

        public bool getIsLoggedIn() { return isLoggedIn; }

        public void setIsLoggedIn(bool value) { isLoggedIn = value; }

        public bool isPassword(string possiblePassword)
        {
            if(possiblePassword.Equals(password))
                return true;
            return false;
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

        public Dictionary<string, Board> getBoardListByName() { return boardListByName; }

        public Dictionary<int, Board> getBoardListById() { return boardListById; }

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