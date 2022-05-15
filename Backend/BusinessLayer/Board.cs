using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class Board
    {
        private String name;
        private Dictionary<string, List<Task>> columns;
        private readonly int id;

        public Board(String boardName, int id)
        {
            name = boardName;
            columns = new Dictionary<string, List<Task>>();
            this.id = id;
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
    }
}