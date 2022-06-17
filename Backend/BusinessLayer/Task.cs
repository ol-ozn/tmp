using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class Task
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string assignie;
        public string Assignie { get; set; }


        private readonly DateTime creationTime;
        public DateTime CreationTime
        {
            get { return creationTime; }
        }

        private DateTime dueTime;
        public DateTime DueTime
        {
            get { return dueTime; }
            set { dueTime = value; }
        }

        public string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }



        private string boardName;
        public string BoardName { get; }


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
            this.creationTime = DateTime.Now;
            this.title = title;
            this.description = description;
            this.dueTime = dueTime;
            this.boardName = boardName;
            this.id = id;
        }

    }
}