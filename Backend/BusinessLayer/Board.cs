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
        private Dictionary<string, List<Task>> columns; // dictionary <board title, tasks list>
        private Dictionary<int, string> columnsId; // dictionary< boardId, Title>
        private readonly int id;
        private int backlog = -1; 
        private int limitInProgress = -1;
        private int limitDone = -1;
        


        public Board(String boardName, int id)
        {
            name = boardName;
            columns = new Dictionary<string, List<Task>>();
            this.id = id;
            columnsId = new Dictionary<int, string>();
            initialColumnsId(columnsId);
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

        private void initialColumnsId(Dictionary<int, string> collumsId)
        {
            columnsId.Add(0, "backlog");
            columnsId.Add(1, "inProgress");
            columnsId.Add(2, "done");
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
            if (id >2 || id < 0)
            {
                throw new Exception("Id out of bounds");
            }
            return columns[columnsId[id]];
        }
      

        public List<Task> getTasksListById(int id)
        {
            return columns[columnsId[id]];
        }

        public bool isColumnFull(int colID)
        {
            return getColumn(colID).Count == getColumnLimit(colID);
        }

    }
}