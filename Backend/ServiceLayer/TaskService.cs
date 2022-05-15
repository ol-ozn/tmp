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

        public TaskService()
        {
            taskController = new TaskController();
        }


        /// <summary>
        /// This method creates and adds a new task. 
        /// </summary>
        /// <param name="userName">The username that wants to add a new task</param>
        /// <param name="title">The title the new task</param>
        /// <param name="description">The description of the task</param>
        /// <param name="dueDate">The dueDate of the task</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response add(User user, string title, string description, DateTime dueTime, int boardId)
        {
            try
            {
                taskController.addTask(title, description, dueTime, boardId, user);
                log.Debug("a task was added to user: " + user.email);
                return new Response();
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }


        /// <summary>
        /// This method changes the attributes of a task. 
        /// </summary>
        /// <param name="id">The id of the board in which the task is in</param>
        /// <param name="taskTitle">The title of the task to be changed</param>
        /// <param name="text">The new text to be inserted</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public Response editTaskTitle(string description, Task task, User user)
        {
            try
            {
                taskController.editDescription(description, task, user);
                log.Debug("User: " + user.email + "edited thier task title");
                return new Response();
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        public Response editTaskDescription(string description, Task task, User user)
        {
            try
            {
                taskController.editDescription(description, task, user);
                log.Debug("User: " + user.email + "edited thier task title");
                return new Response();
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }

        public Response editTaskDueDate(DateTime dateTime, Task task, User user)
        {
            try
            {
                taskController.editDueDate(dateTime, task, user);
                log.Debug("User: " + user.email + "edited thier task title");
                return new Response();
            }
            catch (Exception e)
            {
                return new Response(e.Message, null);
            }
        }
    }
}