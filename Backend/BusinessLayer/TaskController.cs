using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class TaskController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private UserController uc;
        private int taskId;

        public TaskController(UserController uc)
        {
            this.uc = uc;
            this.taskId = 0;
        }


        public Task addTask(string title, string description, DateTime dueTime, string boardName, string email)
        {
            if (checkTitleValidity(title, uc.getUser(email), boardName))
            {
                throw new Exception("user tried to create a new task" +
                                    "with either an empty title or a title with more than" +
                                    "50 characters");
            }

            if (checkDescriptionValidity(description))
            {
                throw new Exception("user tried to create a new task" +
                                    "with a description that has more than 300 characters");
            }

            if (uc.getUser(email).hasBoardByName(boardName).isColumnFull(0))
            {
                throw new Exception("Column overflow");
            }

            Task newTask = new Task(title, description, dueTime, boardName, uc.getUser(email), taskId);
            taskId++;
            Dictionary<string, Board> userBoardByName = uc.getUser(email).getBoardListByName();
            Board boardbyName = userBoardByName[boardName];
            boardbyName.getColumns()["backlog"].Add(newTask);
            return newTask;
        }


        /// <summary>
        /// This method edits the title of an existing task. 
        /// </summary>
        /// /// titles name length can't be longer than 50 chars.
        /// <param name="title">// sets the title of the task</param>
        public void editTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            if (!uc.getUser(email).getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            User currentUser = uc.getUser(email);
            if (!checkTitleValidity(title, currentUser, boardName)) ;
            {
                throw new Exception("user tried to either enter an empty title or a title with more than" +
                                    "50 characters");
            }

            Board boardByName = currentUser.hasBoardByName(boardName);
            Task task = findTaskById(boardByName, taskId, columnOrdinal);
            if (task == null)
            {
                throw new Exception("User:" + email + "tried to change task: " + taskId
                                    + "from board " + boardName);
            }

            task.setTitle(title);
        }


        /// <summary>
        /// This method updates the dueDate of the task to the new dueDate entered by the user
        /// </summary>
        /// <param name="dueDate">// sets the DueDate of the task</param>
        public void editDueDate(DateTime dueDate, Task task, User user)
        {
            if (!user.getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            task.setDueTime(dueDate);
        }


        /// <summary>
        /// This method edits the description of an existing task.
        /// descriptions length can't be longer than 300 chars.
        /// </summary>
        /// <param name="title">// sets the title of the task</param>
        public void editDescription(string description, Task task, User user)
        {
            if (!user.getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            if (!checkDescriptionValidity(description))
            {
                throw new Exception("user tried to edit a description with more than 300 characters");
            }

            task.setDescription(description);
        }


        private bool checkDescriptionValidity(string description)
        {
            return ((description != null) || (description.Length > 300));
        }

        private bool checkTitleValidity(string newTitle, User user, string boardName)
        {
            // checks whether the title is not empty or has more than 50 characters
            if (!(newTitle == null || newTitle.Length > 50))
            {
                return false;
            }

            // checks whether the user already has task with this name on the given board
            if (!taskNameAlreadyExists(user, newTitle, boardName))
            {
                throw new Exception("a task with this title already exists");
            }

            return true;
        }

        private bool taskNameAlreadyExists(User user, string title, string boardName)
        {
            Board board = user.hasBoardByName(boardName);

            foreach (List<Task> list in board.getColumns().Values)
            {
                foreach (Task task in list)
                {
                    if (task.getTitle() == title)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Task findTaskById(Board board, int id, int columnOrdinal)
        {
            List<Task> currentTaskList = board.getColumn(columnOrdinal);
            foreach (Task currentTask in currentTaskList)
            {
                if (currentTask.getId() == id)
                {
                    return currentTask;
                }
            }

            return null;
        }
    }
}