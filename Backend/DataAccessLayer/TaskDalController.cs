using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class TaskDalController : DalController
    {
        private const string TasksTableName = "Tasks";

        public TaskDalController() : base(TasksTableName)
        {

        }

        public List<TaskDTO> SelectAllTasks()
        {
            List<TaskDTO> result = Select().Cast<TaskDTO>().ToList();

            return result;
        }

        protected override DTO ConvertReaderToObject(SQLiteDataReader reader)
        {
            TaskDTO result = new TaskDTO((long)reader.GetValue(0), reader.GetString(1), reader.GetString(2), (int)(long)reader.GetValue(3), DateTime.Parse(reader.GetString(4)), DateTime.Parse(reader.GetString(5)), reader.GetString(6));

            return result;
        }

        public bool Insert(TaskDTO task)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(null, connection);
                int res = -1;
                try
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO {TasksTableName} ({DTO.IDColumnName} ,{TaskDTO.TasksTitleColumnName}, {TaskDTO.TasksDescriptionColumnName}, {TaskDTO.TasksBoardIdColumnName}, {TaskDTO.TasksCreationTimeColumnName}, {TaskDTO.TasksDueDateColumnName}, {TaskDTO.TaskColumnOrdianlName}) " +
                        $"VALUES (@idVal,@titleVal,@descriptionVal,@boardIdVal,@creationTimeVal,@dueDateVal,@ordinalVal);";

                    SQLiteParameter idParam = new SQLiteParameter(@"idVal", task.id);
                    SQLiteParameter titleParam = new SQLiteParameter(@"titleVal", task.Title);
                    SQLiteParameter descriptionParam = new SQLiteParameter(@"descriptionVal", task.Description);
                    SQLiteParameter boardIdParam = new SQLiteParameter(@"boardIdVal", task.BoardId);
                    SQLiteParameter creationTimeParam = new SQLiteParameter(@"creationTimeVal", task.CreationTime);
                    SQLiteParameter dueDateParam = new SQLiteParameter(@"dueDateVal", task.DueDate);
                    SQLiteParameter ordinalParam = new SQLiteParameter(@"ordinalVal", task.ColumnOrdinal);


                    command.Parameters.Add(idParam);
                    command.Parameters.Add(titleParam);
                    command.Parameters.Add(descriptionParam);
                    command.Parameters.Add(boardIdParam);
                    command.Parameters.Add(creationTimeParam);
                    command.Parameters.Add(dueDateParam);
                    command.Parameters.Add(ordinalParam);

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
