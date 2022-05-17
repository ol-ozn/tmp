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
        private readonly TaskController taskController;

        public TaskService(UserService userService)
        {
            this.userController = userService.userController;
            this.taskController = new TaskController(userController);
        }


        /// <summary>
        /// This method creates and adds a new task. 
        /// </summary>
        /// <param name="user">The username that wants to add a new task</param>
        /// <param name="title">The title of the new task</param>
        /// <param name="description">The description of the new task</param>
        /// <param name="dueTime">The dueDate of the new task</param>
        /// <param name="boardId">The boardId of the new task</param>
        /// <returns>creates a new task and adds it to the users task list</returns>
        public Response add(string title, string description, DateTime dueTime, string boardName, string email)
        {
            try
            {
                taskController.addTask(title, description, dueTime, boardName, email);
                log.Debug("a task was added to user: " + email);
                return new Response("{}", null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }


        /// <summary>
        /// This method is called when the user tries to edit the task title. 
        /// </summary>
        /// <param name="title">The title of the new task</param>
        /// <param name="task">The task that it's title needs to be edited</param>
        /// <param name="user">The username that wants to edit the task title</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response editTaskTitle(string email, string boardName, int columnOrdinal, int taskId, string title)
        {
            try
            {
                taskController.editTitle(email, boardName, columnOrdinal, taskId, title);
                log.Debug("User: " + email + "edited the task's title");
                return new Response("{}", null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method is called when the user tries to edit the task description. 
        /// </summary>
        /// <param name="description">The task that it's description is edited</param>
        /// <param name="task">The task that it's description needs to be edited</param>
        /// <param name="user">The username that wants to edit the task description</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response editTaskDescription(string email, string boardName, int columnOrdinal, int taskId,
            string description)
        {
            try
            {
                taskController.editDescription(email, boardName, columnOrdinal, taskId, description);
                log.Debug("User: " + email + "edited thier task title");
                return new Response("{}", null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        /// <summary>
        /// This method is called when the user tries to change the dueDate. 
        /// </summary>
        /// <param name="dateTime">the new due date that the user wants to change to</param>
        /// <param name="task">The task that it's description needs to be edited</param>
        /// <param name="user">The username that wants to edit the task description</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response editTaskDueDate(string email, string boardName, int columnOrdinal, int taskId, DateTime dueDate)
        {
            try
            {
                taskController.editDueDate(email, boardName, columnOrdinal, taskId, dueDate);
                log.Debug("User: " + email + "edited thier task title");
                return new Response("{}", null);
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }
    }
}