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
        private String name;
        private Dictionary<int, string> columnsId; // dictionary< columnsId, ColumnsTitle>
        private Dictionary<string, List<Task>> columns; // dictionary <board title, tasks list>
        private readonly int id;
        private int limitBacklog = -1;
        private int limitInProgress = -1;
        private int limitDone = -1;
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
        }

        public void initColumns()
        {
            columns.Add("limitBacklog", new List<Task>());
            columns.Add("in progress", new List<Task>());
            columns.Add("done", new List<Task>());
        }

        public String getName()
        {
            return name;
        }

        public int getID()
        {
            return id;
        }

        public Dictionary<string, List<Task>> getColumns()
        {
            return columns;
        }

        public int getLimitToDo()
        {
            return limitDone;
        }

        public void setLimitToDo(int newLimit)
        {
            this.limitDone = newLimit;
        }

        public int getLimitInProgress()
        {
            return limitInProgress;
        }

        public void setLimitInProgress(int newLimit)
        {
            this.limitInProgress = newLimit;
        }

        public int getLimitDone()
        {
            return limitDone;
        }

        public void setLimitDone(int newLimit)
        {
            this.limitDone = newLimit;
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
                return getLimitToDo();
            }

            else if (columnId == 1)
            {
                return getLimitInProgress();
            }
            else
            {
                return getLimitDone();
            }
        }

        public void setColumnLimit(int columnId, int newLimit)
        {
            if (columnId == 0)
            {
                setLimitToDo(newLimit);
            }

            else if (columnId == 1)
            {
                setLimitInProgress(newLimit);
            }
            else
            {
                setLimitDone(newLimit);
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
                if (currentTask.getId() == id)
                {
                    return currentTask;
                }
            }

            throw new Exception("This Task Does not exist in this column");
        }
    }
}