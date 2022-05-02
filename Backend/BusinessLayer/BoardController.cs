using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BoardController
    {
        private List<Board> boards;

        BoardController()
        {
            List<Board> boards = new List<Board>();
        }

        public Board addBoard(String boardName)
        {
            Board toAdd;
            foreach (Board board in boards)
            {
                if (board.Equals(boardName))
                    throw new Exception("There already exists a board with this name!");
                
            }
            toAdd = new Board(boardName, 0); //TODO: after implementing id-counting, change the '0'
            boards.Add(toAdd);
            return toAdd;
        }
    }
}
