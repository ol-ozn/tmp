using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.DataAccessLayer.DTOs;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    internal class BoardsUserOwnershipDalController : DalController
    {
        private const string BoardsUsersOwnershipTableName = "BoardsUsersOwnership";

        public BoardsUserOwnershipDalController() : base(BoardsUsersOwnershipTableName)
        {

        }

        public List<BoardUserOwnershipDTO> SelectAllBoardUserOwnershipDtos()
        {
            List<BoardUserOwnershipDTO> result = Select().Cast<BoardUserOwnershipDTO>().ToList();

            return result;
        }

        protected override DTO ConvertReaderToObject(SQLiteDataReader reader)
        {
            BoardUserOwnershipDTO result = new BoardUserOwnershipDTO((int)(long)reader.GetValue(0), (int)(long)reader.GetValue(1));

            return result;
        }
        public bool Insert(BoardUserOwnershipDTO boardUserOwnershipDto)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(null, connection);
                int res = -1;
                try
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO {BoardsUsersOwnershipTableName} ( {BoardUserOwnershipDTO.boardIdColumn},{BoardUserOwnershipDTO.userIdColumn}) " +
                                          $"VALUES (@boardIdVal,@ownerIdVal);";

                    SQLiteParameter ownerIdParam = new SQLiteParameter(@"ownerIdVal", boardUserOwnershipDto.UserID);
                    SQLiteParameter boardIdParam = new SQLiteParameter(@"boardIdVal", boardUserOwnershipDto.BoardId);

                    command.Parameters.Add(ownerIdParam);
                    command.Parameters.Add(boardIdParam);

                    command.Prepare();
                    res = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //log error
                }
                finally
                {
                    command.Dispose();
                    connection.Close();

                }
                return res > 0;
            }
        }
        public bool Delete(BoardUserOwnershipDTO boardUserOwnershipDto)
        {
            int res = -1;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                var command = new SQLiteCommand
                {
                    Connection = connection,
                    CommandText = $"delete from {BoardsUsersOwnershipTableName} where board_id={boardUserOwnershipDto.BoardId} and user_id={boardUserOwnershipDto.UserID}"
                };
                try
                {
                    connection.Open();
                    res = command.ExecuteNonQuery();
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }

            }
            return res > 0;
        }

    }
}
