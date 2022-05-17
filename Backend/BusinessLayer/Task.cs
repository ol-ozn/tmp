using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{


    public class Task
    {
        private readonly string creationTime = DateTime.UtcNow.ToString("dd-mm-yyyy");
        private DateTime dueTime;
        private string title;
        private string description;
        private string boardName;
        private int id;


        /// <summary>
        ///  constructor
        /// </summary>
        /// <param name="dueTime">The dueTime of the task</param>
        /// <param name="title">The title of the task</param>
        /// <param name="description">The description of the task</param>
        /// <param name="boardId">The id of the board that the task is in</param>
        /// <param name="id">The id of the task</param>
        /// <returns> creates a new task >
        public Task(string title, string description, DateTime dueTime, string boardName, User user, int id)
        {
            this.title = title;
            this.description = description;
            this.dueTime = dueTime;
            this.boardName = boardName;
            this.id = id;
        }


        public int getId()
        {
            return id;
        }

        public string getBoardName()
        {
            return boardName;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }
        
        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setDueTime(DateTime dueTime)
        {
            this.dueTime = dueTime;
        }
    }
}