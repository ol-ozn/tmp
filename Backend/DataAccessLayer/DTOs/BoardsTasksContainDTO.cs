using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTOs
{
    public class BoardsTasksContainDTO : DTO
    {
        public const string boardIdColumn = "board_id";
        public const string taskIdColumn = "task_id";

        private int boardId;

        public int BoardId { get => boardId; set { boardId = value; _controller.Update(id, boardIdColumn, value); } }

        private int taskID;
        public int TaskID { get => taskID; set { taskID = value; _controller.Update(id, taskIdColumn, value); } }

        public BoardsTasksContainDTO(int boardID, int memberID) : base(new BoardsTasksContainDalController())
        {
            this.boardId = boardID;
            this.taskID = memberID;
        }
    }
}
