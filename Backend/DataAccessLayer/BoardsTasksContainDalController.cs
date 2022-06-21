using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.DataAccessLayer.DTOs;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    internal class BoardsTasksContainDalController : DalController
    {

        private const string BoardsTasksContainTableName = "BoardsTasksContain";

        public BoardsTasksContainDalController() : base(BoardsTasksContainTableName)
        {
        }

        public List<BoardsTasksContainDTO> SelectAllBoardsMembersDtos()
            {
                List<BoardsTasksContainDTO> result = Select().Cast<BoardsTasksContainDTO>().ToList();

                return result;
            }

        protected override DTO ConvertReaderToObject(SQLiteDataReader reader)
        {
            BoardsTasksContainDTO result = new BoardsTasksContainDTO((int)(long)reader.GetValue(0), (int)(long)reader.GetValue(1));

            return result;
        }
        public bool Insert(BoardsTasksContainDTO boardsTasksDTO)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(null, connection);
                int res = -1;
                try
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO {BoardsTasksContainTableName} (board_id, task_id) " + //TODO: fix constant
                                          $"VALUES (@boardIdVal,@taskIdVal);";

                    SQLiteParameter taskIdParam = new SQLiteParameter(@"taskIdVal", boardsTasksDTO.TaskID);
                    SQLiteParameter boardIdParam = new SQLiteParameter(@"boardIdVal", boardsTasksDTO.BoardId);

                    command.Parameters.Add(taskIdParam);
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
    }
}
