﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.DataAccessLayer;
using IntroSE.Kanban.Backend.DataAccessLayer.DTOs;
using IntroSE.Kanban.Backend.ServiceLayer;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class TaskController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private int taskId;
        private UserController uc;

        private TaskDalController taskDalController;
        public TaskController(ServiceFactory serviceFactory)
        {
            taskDalController = new TaskDalController();
            // boardsTasksContainDalController = new BoardsTasksContainDalController();
            this.uc = serviceFactory.UserController;
            this.taskId = (int)taskDalController.getSeq() + 1;
            
        }

        public Task addTask(string title, string description, DateTime dueTime, string boardName, string email)
        {
            User user = uc.getUserAndLogeddin(email);

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


            Dictionary<string, Board> userBoardByName = user.getBoardListByName();
            Board boardbyName = userBoardByName[boardName]; //getting the needed board from list of user's boards
            Task newTask = new Task(title, description, dueTime, taskId, boardbyName.Id);
            
            //adding to db
            taskDalController.Insert(new TaskDTO(taskId, title, description, boardbyName.Id,
                newTask.CreationTime, dueTime, "backlog", newTask.Assignie));
            // boardsTasksContainDalController.Insert(new BoardsTasksContainDTO(boardbyName.Id, user.Id));
            
            taskId++; 
            boardbyName.columns["backlog"].Add(newTask);
            
            return newTask;
        }


        /// <summary>
        /// This method edits the title of an existing task. 
        /// </summary>
        /// /// titles name length can't be longer than 50 chars.
        /// <param name="title">// sets the title of the task</param>
        public void editTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            User currentUser = uc.getUserAndLogeddin(email);
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

            //updating in db
            taskDalController.Update(taskId, "title", title);
            task.Title = title;
        }


        /// <summary>
        /// This method updates the dueDate of the task to the new dueDate entered by the user
        /// </summary>
        /// <param name="dueDate">// sets the DueDate of the task</param>
        public void editDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueTime)
        {
            User user = uc.getUserAndLogeddin(email);

            Board board = user.hasBoardByName(boardName);
            Task task = findTaskById(board, taskId, columnOrdinal);
            if (task == null)
            {
                throw new Exception("this task does not exist in this column");
            }

            //updating in db
            taskDalController.Update(taskId, "due_date" ,dueTime.ToString());
            task.DueDate = dueTime;
        }


        /// <summary>
        /// This method edits the description of an existing task.
        /// descriptions length can't be longer than 300 chars.
        /// </summary>
        /// <param name="title">// sets the title of the task</param>
        public void editDescription(string email, string boardName, int columnOrdinal, int taskId, string description)
        {
            User user = uc.getUserAndLogeddin(email);

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

            //updating in db
            taskDalController.Update(taskId, "description", description);
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

            foreach (List<Task> list in board.columns.Values)
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
            User currentUser = uc.getUserAndLogeddin(email);
            Dictionary<string, Board> boardListByName = currentUser.getBoardListByName();
            if (!boardListByName.Any())
            {
                throw new Exception("User has no Boards");
            }

            List<Task> list = new List<Task>();
            foreach (Board board in boardListByName.Values)
            {
                List<Task> l = board.columns["in progress"];
                if (!l.Any()) //in case the current list is null
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


            return list;
        }

        public void assignTask(string email, string boardName, int columnOrdinal, int taskId, string asignee)
        {
            Board board = uc.getUserAndLogeddin(email).getBoardListByName()[boardName];
            if (!uc.userExists(asignee))
            {
                throw new Exception("user assignee with email " + asignee + " doesn't exist");
            }
            Task task = board.findTaskById(taskId, columnOrdinal);
            if (task.Assignie == "unassigned" || email.Equals(task.Assignie))
            {
                task.Assignie = asignee; // sets the new assignee in the RAM
                taskDalController.Update(taskId, "assignee", asignee);
            }
        }

        /// <summary>
        ///  This method changes the state of a task.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnOrdinal">The id of the column</param>
        /// <param name="taskId">The id of the task to advance</param>
        /// <returns></returns>
        public void changeState(string email, string boardName, int columnOrdinal, int taskId)
        {
            if (columnOrdinal > 2 || columnOrdinal < 0)
            {
                throw new Exception(columnOrdinal + " is invalid");
            }

            if (columnOrdinal == 2)
            {
                throw new Exception("cannot advance task from done");
            }

            User user = uc.getUserAndLogeddin(email); //user is logged in
            bool found = false;

            Board board = user.hasBoardByName(boardName);
            Task task = findTaskById(board, taskId, columnOrdinal);
            if ((!email.Equals(task.Assignie)) &&
                task.Assignie != null) // in case the user who's trying to progress the task isn't the asignee 
            {
                throw new Exception("user: " + email + " tried to progress task:" + taskId +
                                    "which he is not assigned to");
            }

            if (board.isColumnFull(columnOrdinal + 1)) //check column limit
            {
                throw new Exception("next column is full");
            }

            string newColumnOrdinal = board.getColumnName(board.getColumnNumber(task.columnOrdinal) + 1);
            task.columnOrdinal = newColumnOrdinal;
            List<Task> tasksList = board.getColumn(columnOrdinal);
            tasksList.Remove(task);
            List<Task> newtasksList = board.getColumn(columnOrdinal + 1);
            newtasksList.Add(task);
            // taskDalController.Advance(taskId, newColumnOrdinal);
            taskDalController.Update(taskId, TaskDTO.TaskColumnOrdianlName, newColumnOrdinal);
        }

        public void resetData()
        {
            taskDalController.resetTable();
            taskId = 1;
        }
    }
}