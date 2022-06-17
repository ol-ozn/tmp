using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class Board
    {
        private string name;
        public string Name { get; }
        private Dictionary<int, string> columnsId; // dictionary< columnsId, ColumnsTitle>
        private Dictionary<string, List<Task>> columns; // dictionary <board title, tasks list>
        private readonly int id;
        public int Id { get; }
        private int limitBacklog;
        public int LimitBacklog { get; set; }
        private int limitInProgress;
        public int LimitInProgress { get; set; }
        private int limitDone;
        public int LimitDone { get; set; }
        private int owner;

        public int Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private HashSet<string> memeberList; // each board holds its members

        public HashSet<string> MemeberList
        {
            get { return memeberList; }
        }


        public Board(String boardName, int id)
        {
            name = boardName;
            columns = new Dictionary<string, List<Task>>();
            initColumns();
            this.id = id;
            columnsId = new Dictionary<int, string>();
            initialColumnsId(columnsId);
            owner = id;
            memeberList = new HashSet<string>();
            this.limitBacklog = -1;
            this.limitInProgress = -1;
            this.limitDone = -1;
        }

        public void initColumns()
        {
            columns.Add("limitBacklog", new List<Task>());
            columns.Add("in progress", new List<Task>());
            columns.Add("done", new List<Task>());
        }


        public Dictionary<string, List<Task>> getColumns()
        {
            return columns;
        }


        private void initialColumnsId(Dictionary<int, string> columnsId)
        {
            this.columnsId.Add(0, "limitBacklog");
            this.columnsId.Add(1, "in progress");
            this.columnsId.Add(2, "done");
        }

        public string getColumnName(int id)
        {
            return columnsId[id];
        }

        public int getColumnLimit(int columnId)
        {
            if (columnId == 0)
            {
                return limitBacklog;
            }

            else if (columnId == 1)
            {
                return limitInProgress;
            }
            else
            {
                return limitDone;
            }
        }

        public void setColumnLimit(int columnId, int newLimit)
        {
            if (columnId == 0)
            {
                limitBacklog = newLimit;
            }

            else if (columnId == 1)
            {
                limitInProgress = newLimit;
            }
            else
            {
                limitDone = newLimit;
            }
        }

        public List<Task> getColumn(int id)
        {
            if (id > 2 || id < 0)
            {
                throw new Exception("Id out of bounds");
            }

            return columns[columnsId[id]];
        }


        public bool isColumnFull(int colID)
        {
            return getColumn(colID).Count == getColumnLimit(colID);
        }

        public Task findTaskById(int id, int columnOrdinal)
        {
            List<Task> currentTaskList = getColumn(columnOrdinal);
            foreach (Task currentTask in currentTaskList)
            {
                if (currentTask.Id == id)
                {
                    return currentTask;
                }
            }

            throw new Exception("This Task Does not exist in this column");
        }
    }
}