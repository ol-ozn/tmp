using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class Board
    {
        //private String name { get; set; }
        private String name;
        private List<List<Task>> board;
        private readonly int id;
        public Board(String boardName,int id)
        {
            name = boardName;
            board = new List<List<Task>>();
            id = id;
        }

        public String getName() { return name; }
    }
}
