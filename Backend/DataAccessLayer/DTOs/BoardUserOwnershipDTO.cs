using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.DTOs
{
    public class BoardUserOwnershipDTO : DTO
    {
        public const string boardIdColumn = "board_id";
        public const string userIdColumn = "user_id";

        private int boardId;

        public int BoardId { get => boardId; set { boardId = value; _controller.Update(id, boardIdColumn, value); } }

        private int userID;
        public int UserID { get => userID; set { userID = value; _controller.Update(id, userIdColumn, value); } }

        public BoardUserOwnershipDTO(int boardID, int userID) : base(new BoardsUserOwnershipDalController())
        {
            this.boardId = boardID;
            this.userID = userID;

        }
    }

}
