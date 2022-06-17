using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class TaskController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private UserController uc;
        private int taskId;

        public TaskController(ServiceFactory serviceFactory)
        {
            this.uc = serviceFactory.UserController;
            this.taskId = 0;
            // this.uc = uc;
        }


        public Task addTask(string title, string description, DateTime dueTime, string boardName, string email)
        {
            User user = uc.getUser(email);

            if (!checkTitleValidity(title, user, boardName))
            {
                throw new Exception("user tried to create a new task" +
                                    " with either an empty title or a title with more than" +
                                    " 50 characters");
            }

            if (!checkDescriptionValidity(description))
            {
                throw new Exception("user tried to create a new task" +
                                    " with a description that has more than 300 characters");
            }

            if (user.hasBoardByName(boardName).isColumnFull(0))
            {
                throw new Exception("Column overflow");
            }

            Task newTask = new Task(title, description, dueTime, boardName, user, taskId);
            taskId++;
            Dictionary<string, Board> userBoardByName = user.getBoardListByName();
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
            User currentUser = uc.getUser(email);
            if (!checkTitleValidity(title, currentUser, boardName))
            {
                throw new Exception("user tried to either enter an empty title or a title with more than: " +
                                    "50 characters");
            }

            Board boardByName = currentUser.hasBoardByName(boardName);
            Task task = findTaskById(boardByName, taskId, columnOrdinal);
            if (task == null)
            {
                throw new Exception("User: " + email + " tried to change a task that does not exist " +
                                    "or not in this board");
            }

            task.Title = title;
        }


        /// <summary>
        /// This method updates the dueDate of the task to the new dueDate entered by the user
        /// </summary>
        /// <param name="dueDate">// sets the DueDate of the task</param>
        public void editDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueTime)
        {
            User user = uc.getUser(email);

            Board board = user.hasBoardByName(boardName);
            Task task = findTaskById(board, taskId, columnOrdinal);
            if (task == null)
            {
                throw new Exception("this task does not exist in this column");
            }

            task.DueTime = dueTime;
        }


        /// <summary>
        /// This method edits the description of an existing task.
        /// descriptions length can't be longer than 300 chars.
        /// </summary>
        /// <param name="title">// sets the title of the task</param>
        public void editDescription(string email, string boardName, int columnOrdinal, int taskId, string description)
        {
            User user = uc.getUser(email);

            if (!checkDescriptionValidity(description))
            {
                throw new Exception("user tried to edit a description with more than 300 characters");
            }

            Board board = user.hasBoardByName(boardName);
            Task task = findTaskById(board, taskId, columnOrdinal);
            if (task == null)
            {
                throw new Exception("this task does not exist in this column");
            }

            task.Description = description;
        }


        private bool checkDescriptionValidity(string description)
        {
            return ((description != null) && ((description.Length <= 300) && (description.Length > 0)));
        }

        private bool checkTitleValidity(string newTitle, User user, string boardName)
        {
            // checks whether the title is not empty or has more than 50 characters
            if (String.IsNullOrEmpty(newTitle))
            {
                return false;
            }

            if (newTitle.Length > 50)
            {
                return false;
            }

            // checks whether the user already has task with this name on the given board
            if (taskNameAlreadyExists(user, newTitle, boardName))
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
                    if (task.Title == title)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Task findTaskById(Board board, int taskId, int columnOrdinal)
        {
            List<Task> currentTaskList = board.getColumn(columnOrdinal);
            if (!currentTaskList.Any())
            {
                throw new Exception("There are no tasks in this column");
            }

            foreach (Task currentTask in currentTaskList)
            {
                if (currentTask.Id == taskId)
                {
                    return currentTask;
                }
            }

            return null;
        }

        public List<Task> listTaskInProgress(string email)
        {
            User currentUser = uc.getUser(email);
            Dictionary<string, Board> boardListByName = currentUser.getBoardListByName();
            if (!boardListByName.Any())
            {
                throw new Exception("User has no Boards");
            }

            List<Task> list = new List<Task>();
            foreach (Board board in boardListByName.Values)
            {
                List<Task> l = (board.getColumns())["in progress"];
                if (!l.Any())
                {
                    continue;
                }


                foreach (Task task in l)
                {
                    if (task.Assignie.Equals(currentUser
                            .email)) // add task only if the user is the assignie of the task
                    {
                        list.Add(task);
                    }
                }
            }

            if (!list.Any())
            {
                throw new Exception("no tasks in in progress");
            }

            return list;
        }

        public void assignTask(string email, string boardName, int columnOrdinal, int taskId, string asignee)
        {
            Board board = uc.getUser(email).getBoardListByName()[boardName];
            Task task = board.findTaskById(taskId, columnOrdinal);
            if (task.Assignie == null)
            {
                task.Assignie = asignee;
            }
        }
    }
}