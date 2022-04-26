using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    internal interface TaskService
    {
        /// <summary>
        /// This method creates a new task. 
        /// </summary>
        /// <param name="taskName">The name of the new board</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public String add(string taskName);

        /// <summary>
        /// This method changes the state of task. 
        /// </summary>
        /// <param name="id">The id of the board in which the task is in</param>
        /// <param name="taskTitle">The title of the task of which to change state</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public String changeState(int id, string taskTitle);

        /// <summary>
        /// This method changes the attributes of a task. 
        /// </summary>
        /// <param name="id">The id of the board in which the task is in</param>
        /// <param name="taskTitle">The title of the task to be changed</param>
        /// <param name="text">The new text to be inserted</param>
        /// <returns>The string "{}", unless an error occurs</returns>
        public String editTask(string id, string taskTitle, string text);
    }
}
