﻿using System;
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

        public TaskController()
        {
        }


        public Task addTask(string title, string description, DateTime dueTime, int boardId, User user)
        {
            if (checkTitleValidity(title, user, boardId))
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

            Task newTask = new Task(title, description, dueTime, boardId, user);

            Dictionary<int, Board> userBoardById = user.getBoardListById();
            Board boardbyID = userBoardById[boardId];
            boardbyID.getColumns()["inProgress"].Add(newTask);


            return newTask;
        }


        /// <summary>
        /// This method edits the title of an existing task. 
        /// </summary>
        /// /// titles name length can't be longer than 50 chars.
        /// <param name="title">// sets the title of the task</param>
        public void editTitle(string newTitle, Task task, User user, int boardId)
        {
            if (!user.getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            if (!checkTitleValidity(newTitle, user, boardId)) ;
            {
                throw new Exception("user tried to either enter an empty title or a title with more than" +
                                    "50 characters");
            }

            task.setTitle(newTitle);
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

        private bool checkTitleValidity(string newTitle, User user, int boardId)
        {
            if (!(newTitle == null || newTitle.Length > 50))
            {
                return false;
            }

            if (!taskNameAlreadyExists(user, newTitle, boardId))
            {
                throw new Exception("a task with this title already exists");
            }

            return true;
        }

        private bool taskNameAlreadyExists(User user, string title, int boardId)
        {
            Dictionary<int, Board> boardListById = user.getBoardListById();
            Board board = boardListById[boardId];

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
    }
}