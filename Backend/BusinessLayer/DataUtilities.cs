using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.DataAccessLayer;
using IntroSE.Kanban.Backend.DataAccessLayer.DTOs;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public static class DataUtilities
    {


        /// <summary>
        /// loads the data of every board(id,board_name,board_owner,backlog_limit etc)
        /// </summary>
        /// <param name="boardDalController">// the boards dal controller</param>
        internal static Dictionary<int, Board> loadData(BoardDalController boardDalController)
        {
            Dictionary<int, Board> boardsLoaded = new Dictionary<int, Board>();
            List<BoardDTO> boardsDtos = boardDalController.SelectAllBoards();
            foreach (BoardDTO boardDTO in boardsDtos)
            {
                boardsLoaded.Add((int)boardDTO.id, new Board(boardDTO.BoardName, (int)boardDTO.id));
            }
            return boardsLoaded;
        }

        /// <summary>
        /// loads the data of every user(id,email,password)
        /// </summary>
        /// <param name="userDalController">// the users dal controller</param>
        internal static Dictionary<string, User> loadData(UserDalController userDalController)
        {
            Dictionary<string, User> usersLoaded = new Dictionary<string, User>();
            List<UserDTO> userDtos = userDalController.SelectAllUsers();
            foreach (UserDTO userDto in userDtos)
            {
                usersLoaded.Add(userDto.Email, new User(userDto.Email, userDto.Password, (int)userDto.id));
            }
            return usersLoaded;
        }

        /// <summary>
        /// loads the data of board and his owner(board_id, owner_id)
        /// </summary>
        /// <param name="boardsUserOwnershipDalController">// the board owners dal controller</param>
        internal static Dictionary<int, int> loadData(BoardsUserOwnershipDalController boardsUserOwnershipDalController)
        {
            Dictionary<int, int> boardsOwners = new Dictionary<int, int>();
            List<BoardUserOwnershipDTO> BoardUserOwnershipDtos = boardsUserOwnershipDalController.SelectAllBoardUserOwnershipDtos();
            foreach (BoardUserOwnershipDTO boardUserOwnershipDto in BoardUserOwnershipDtos)
            {
                boardsOwners.Add(boardUserOwnershipDto.BoardId,boardUserOwnershipDto.UserID);
            }
            return boardsOwners;
        }
    }
}
