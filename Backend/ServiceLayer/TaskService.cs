using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IntroSE.Kanban.Backend.BusinessLayer;
using log4net;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class TaskService
    {
        private readonly UserController userController;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public readonly TaskController taskController;

        public TaskService(ServiceFactory serviceFactory)
        {
            this.userController = serviceFactory.UserController;
            this.taskController = serviceFactory.TaskController;
        }


        /// <summary>
        /// This method creates and adds a new task. 
        /// </summary>
        /// <param name="title">The title of the new task</param>
        /// <param name="description">The description of the new task</param>
        /// <param name="dueTime">The dueDate of the new task</param>
        /// <param name="boardName">The board name of the new task</param>
        /// <param name="email">The email of the user</param>
        /// <returns>creates a new task and adds it to the users task list</returns>
        public Response add(string title, string description, DateTime dueTime, string boardName, string email)
        {
            try
            {
                taskController.addTask(title, description, dueTime, boardName, email);
                log.Debug("a task was added to user: " + email);
                return new Response(null, null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }


        /// <summary>
        /// This method is called when the user tries to edit the task title. 
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board where the task should be</param>
        /// <param name="columnOrdinal">The id of the column where the task should be</param>
        /// <param name="taskId">The id of the task</param>
        /// <param name="title">The new title of the task</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response editTaskTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            try
            {
                taskController.editTitle(email, boardName, columnOrdinal, taskId, title);
                log.Debug("User: " + email + "edited the task's title");
                return new Response(null, null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method is called when the user tries to edit the task description. 
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The board name where the task should be in</param>
        /// <param name="columnOrdinal">The id of the column where the task should be in</param>
        /// <param name="taskId">The task's id</param>
        /// <param name="description">The new description for the task</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response editTaskDescription(string email, string boardName, int columnOrdinal, int taskId,
            string description)
        {
            try
            {
                taskController.editDescription(email, boardName, columnOrdinal, taskId, description);
                log.Debug("User: " + email + "edited thier task title");
                return new Response(null, null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method is called when the user tries to change the dueDate. 
        /// </summary>
        /// <param name="email">the email of the user</param>
        /// <param name="boardName">the board name where the task should be</param>
        /// <param name="columnOrdinal">the id of the column where the task should be</param>
        /// <param name="taskId">the task's id</param>
        /// <param name="dueDate">the task's new due date</param>
        /// <returns>The "{}", unless an error occurs</returns>
        public Response editTaskDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueDate)
        {
            try
            {
                taskController.editDueDate(email, boardName, columnOrdinal, taskId, dueDate);
                log.Debug("User: " + email + "edited the task title");
                return new Response(null, null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method returns a list of user's in progress tasks. 
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>Json formatted list of tasks, unless an error occurs</returns>
        public Response listTasksInProgress(string email)
        {
            try
            {
                List<Task> inProgress = taskController.listTaskInProgress(email);
                log.Info("in progress tasks were listed successfully");
                return new Response(null, inProgress);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method changes the state of task. 
        /// </summary>
        /// <param name="email">the email of the user</param>
        /// <param name="boardName">the name of the board in which the task should be</param>
        /// <param name="columnOrdinal">the id of the column in which the task should be</param>
        /// <param name="taskId">the id of the task</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response changeState(string email, string boardName, int columnOrdinal, int taskId)
        {
            try
            {
                taskController.changeState(email, boardName, columnOrdinal, taskId);
                log.Info("taks: " + taskId + " was advanced by " + email);
                return new Response(null, null);
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method assigns a task to a user. 
        /// </summary>
        /// <param name="email">the email of the user</param>
        /// <param name="boardName">the name of the board in which the task should be</param>
        /// <param name="columnOrdinal">the id of the column in which the task should be</param>
        /// <param name="taskId">the id of the task</param>
        /// <param name="emailAssignee">the email of the user to assign to</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response AssignTask(string email, string boardName, int columnOrdinal, int taskId, string emailAssignee)
        {
            try
            {
                taskController.assignTask(email, boardName, columnOrdinal, taskId, emailAssignee);
                log.Info("task " + taskId + " was assigned to " + emailAssignee);
                return new Response(null, null);
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
                return new Response(e.Message, null);
            }
        }
    }
}