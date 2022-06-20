using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class BoardDalController : DalController
    {
        private const string BoardsTableName = "Boards";

        public BoardDalController() : base(BoardsTableName)
        {

        }

        public List<BoardDTO> SelectAllBoards()
        {
            List<BoardDTO> result = Select().Cast<BoardDTO>().ToList();

            return result;
        }

        protected override DTO ConvertReaderToObject(SQLiteDataReader reader)
        {
            BoardDTO result = new BoardDTO((long)reader.GetValue(0), reader.GetString(1), (int)(long)reader.GetValue(2), (int)(long)reader.GetValue(3), (int)(long)reader.GetValue(4), (int)(long)reader.GetValue(5));

            return result;
        }

        public bool Insert(BoardDTO board)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(null, connection);
                int res = -1;
                try
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO {BoardsTableName} ({DTO.IDColumnName} ,{BoardDTO.BoardsBoardNameColumnName},{BoardDTO.BoardsBoardOwnerIdColumnName}, {BoardDTO.BoardsBacklogLimitColumnName},{BoardDTO.BoardsInProgressLimitColumnName},{BoardDTO.BoardsDoneLimitColumnName}) " +
                        $"VALUES (@idVal,@boardNameVal,@boardOwnerVal,@backlogLimitVal,@inProgressLimitVal,@doneLimitVal);";

                    SQLiteParameter idParam = new SQLiteParameter(@"idVal", board.id);
                    SQLiteParameter boardNameParam = new SQLiteParameter(@"boardNameVal", board.BoardName);
                    SQLiteParameter boardOwnerParam = new SQLiteParameter(@"boardOwnerVal", board.BoardOwnerId);
                    SQLiteParameter backlogLimitParam = new SQLiteParameter(@"backlogLimitVal", board.BacklogLimit);
                    SQLiteParameter inProgressLimitParam = new SQLiteParameter(@"inProgressLimitVal", board.InProgressLimit);
                    SQLiteParameter doneLimitParam = new SQLiteParameter(@"doneLimitVal", board.DoneLimit);

                    command.Parameters.Add(idParam);
                    command.Parameters.Add(boardNameParam);
                    command.Parameters.Add(boardOwnerParam);
                    command.Parameters.Add(backlogLimitParam);
                    command.Parameters.Add(inProgressLimitParam);
                    command.Parameters.Add(doneLimitParam);


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

        public bool setColumnLimit(int boardId, string columnName, int newlimit)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(null, connection);
                int res = -1;
                try
                {
                    connection.Open();
                    command.CommandText =
                        $"UPDATE {BoardsTableName} SET {columnName} = @newlimit Where id = @boardid; ";


                    SQLiteParameter boardidParam = new SQLiteParameter(@"boardid", boardId);
                    // SQLiteParameter columnnameParam = new SQLiteParameter(@"columnname", columnName);
                    SQLiteParameter newlimitParam = new SQLiteParameter(@"newlimit", newlimit);

                    command.Parameters.Add(boardidParam);
                    // command.Parameters.Add(columnnameParam);
                    command.Parameters.Add(newlimitParam);


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
    }
}
