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
        private int boardId;
        private int id;

        public Task(string title, string description, DateTime dueTime, int boardId,User user)
        {
            this.title = title;
            this.description = description;
            this.dueTime = dueTime;
            this.boardId = boardId;
        }


        public int getId()
        {
            return id;
        }

        public int getBoardID()
        {
            return boardId;
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