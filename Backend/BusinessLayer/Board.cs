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
        private Dictionary<string, List<Task>> columns;
        private readonly int id;
        private int limitToDo = -1; 
        private int limitInProgress = -1;
        private int limitDone = -1;
        private Dictionary<int, string> columsId;


        public Board(String boardName, int id)
        {
            name = boardName;
            columns = new Dictionary<string, List<Task>>();
            this.id = id;
            columsId = new Dictionary<int, string>();
            initialColuumsId(columsId);
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
            return limitToDo;
        }

        public void setLimitToDo(int newLimit)
        {
            this.limitToDo = newLimit;
        }

        public int getlimitInProgress()
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

        private void initialColuumsId(Dictionary<int, string> collumsId)
        {
            columsId.Add(0, "toDo");
            columsId.Add(1, "inProgress");
            columsId.Add(2, "done");
        }

        public string getcolumname(int id)
        {
            return columsId[id];
        }

        public int getcolumLimit(int columnId)
        {
            if (columnId == 0)
            {
                return getLimitToDo();
            }

            else if (columnId == 1)
            {
                return getlimitInProgress();
            }
            else
            {
                return getLimitDone();
            }
        }
        public void setcolumLimit(int columnId, int newLimit)
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
            return columns[columsId[id]];
        }
    }
}