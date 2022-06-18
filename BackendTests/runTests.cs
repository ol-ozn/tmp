using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.DataAccessLayer;
using Task = IntroSE.Kanban.Backend.BusinessLayer.Task;


namespace BackendTests
{
    public class runTests
    {
        static void Main(string[] args)
        {
            // ServiceFactory serviceFactory = new ServiceFactory();
            //
            //
            // GradingService gradingService = new GradingService();
            // Console.WriteLine("if the user managed to register this should return: {} ");
            // Console.WriteLine(gradingService.Register("amir@gmail.com", "Test12345"));

            // Console.WriteLine("if the user managed to register this should return: {} ");
            // Console.WriteLine(gradingService.Register("Amir@gmail.com", "Test12345"));
            // Console.WriteLine("\n");
            // Console.WriteLine("if the user managed to logout this should return: {} ");
            // Console.WriteLine(gradingService.Logout("Amir@gmail.com"));
            // Console.WriteLine("if the user managed to login, this should return the users email:  ");
            // Console.WriteLine(gradingService.Login("Amir@gmail.com", "Test12345"));
            //
            // Console.WriteLine("\n");
            //

            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine("if user added a board this should return: {} ");
            // Console.WriteLine(gradingService.AddBoard("amir@gmail.com", "board1"));
            // Console.WriteLine(gradingService.AddBoard("amir@gmail.com", "board2"));
            //
            // Console.WriteLine("\n");
            //
            // // Console.WriteLine("if user removed board this should return: {} ");
            // // Console.WriteLine(gradingService.RemoveBoard("amir@gmail.com", "board1"));
            // // Console.WriteLine(gradingService.RemoveBoard("amir@gmail.com", "board2"));
            //
            //
            // Console.WriteLine("if user managed to limit the number of tasks in his column this should return: {} ");
            // Console.WriteLine(gradingService.LimitColumn("amir@gmail.com", "board1", 0, 4));
            //
            // Console.WriteLine("\n");
            //
            //
            // Console.WriteLine("if the user added a task, his email should be the returned value:");
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title1", "bla bla 1",
            //     new DateTime(2026, 5, 5)));
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title1", "bla bla 2 ",
            //     new DateTime(2026, 6, 5)));
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title3", "bla bla 3",
            //     new DateTime(2026, 7, 5)));
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title4", "bla bla 4",
            //     new DateTime(2026, 8, 5)));
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title5", "bla bla 5",
            //     new DateTime(2026, 9, 5)));
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title6", "bla bla 5",
            //     new DateTime(2026, 9, 5)));
            // Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board2", "title7", "bla bla 6",
            //     new DateTime(2026, 10, 5)));
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine(
            //     "if user managed to get the limit number of tasks in his column this should return: int value");
            // Console.WriteLine(gradingService.GetColumnLimit("amir@gmail.com", "board1", 0));
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine(
            //     "(this should return an error)if user managed to get the column name this should return: column name");
            // Console.WriteLine(gradingService.GetColumnName("amir@gmail.com", "board1", 0));
            //
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine("if the user updated a task due date this should return: {}");
            // Console.WriteLine(gradingService.UpdateTaskDueDate("amir@gmail.com", "board1", 0, 0,
            //     new DateTime(2028, 11, 5)));
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine("if the user updated a tasks title successfully this should return: {}");
            // Console.WriteLine(gradingService.UpdateTaskTitle("amir@gmail.com", "board1", 0, 0, "a new title yay!"));
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine("if the user updated a tasks description successfully this should return: {}");
            // Console.WriteLine(
            //     gradingService.UpdateTaskDescription("amir@gmail.com", "board1", 0, 0, "a new description yay!"));
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine("if the task was advanced correctly this will return: {}");
            // Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1", 0, 3));
            // Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board2", 0, 1));
            // Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1", 1, 3));
            // Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1", 2, 3));
            //
            // Console.WriteLine("\n");
            //
            // Console.WriteLine("if the column has any lists in it, this will return: a Response" +
            //                   " with the list of the columns tasks");
            // Console.WriteLine(gradingService.GetColumn("amir@gmail.com", "board2", 2));
            //
            //
            // Console.WriteLine("if the column has any lists in it, this will return: a Response" +
            //                   " with the list of the columns tasks");
            // Console.WriteLine(gradingService.InProgressTasks("amir@gmail.com"));

            // UserDalController userDalController = new UserDalController();
            // UserDTO user = new UserDTO(15, "olga@mail.com", "1234");
            // UserDTO user2 = new UserDTO(16, "danny@mail.com", "1111");

            // bool ans = userDalController.Delete(user);
            // Console.WriteLine(ans);

            // bool ans = userDalController.Insert(user2);
            // Console.WriteLine(ans);
            // List<UserDTO> messages = userDalController.SelectAllUsers();
            // foreach (UserDTO m in messages)
            // {
            //     Console.WriteLine(m.Email);
            // }
            // Console.Read();

            // BoardDalController boardDalController = new BoardDalController();
            // BoardDTO board1 = new BoardDTO(15,"board1",15,-1,-1,-1);
            // BoardDTO board2 = new BoardDTO(16,"board2",16,-1,-1,-1);


            // bool ans = boardDalController.Delete(board1);
            // Console.WriteLine(ans);
            //
            // bool ans = boardDalController.Insert(board2);
            // Console.WriteLine(ans);
            //
            // List<BoardDTO> messages = boardDalController.SelectAllBoards();
            // foreach (BoardDTO m in messages)
            // {
            //     Console.WriteLine(m.BoardName);
            // }

            // TaskDalController taskDalController = new TaskDalController();
            // TaskDTO task1 = new TaskDTO(15, "task1", "beep boop", 15, DateTime.Now,DateTime.Parse("Jan 1, 2023 13:00:00"));
            // TaskDTO task2 = new TaskDTO(16, "task2", "beep boop", 16, DateTime.Now, DateTime.Parse("Jan 3, 2023 13:00:00"));

            // bool ans = taskDalController.Delete(task1);
            // Console.WriteLine(ans);

            // bool ans = taskDalController.Insert(task2);
            // Console.WriteLine(ans);
            //
            // List<TaskDTO> messages = taskDalController.SelectAllTasks();
            // foreach (TaskDTO m in messages)
            // {
            //     Console.WriteLine(m.Title);
            // }

            // Console.WriteLine(gs.AddBoard("olga@gmail.com", "board1"));
            // Console.WriteLine(gs.AddBoard("olga@gmail.com", ""));
            // Console.WriteLine(gs.AddBoard("daniel@gmail.com", ""));
            // Console.WriteLine(gs.Register("daniel@gmail.com", "12345Ab"));
            // Console.WriteLine(gs.AddBoard("daniel@gmail.com", "board1"));
            // Console.WriteLine(gs.Login("olga@gmail.com", "12345Ab"));
            // Console.WriteLine(gs.AddTask("olga@gmail.com", "board1", "title1", "f this s", DateTime.Now));
            // Console.WriteLine(gs.AddTask("amit@gmail.com", "board1", "title1", "f this s", DateTime.Now));
            // Console.WriteLine(gs.AddTask("olga@gmail.com", "board2", "title1", "f this s", DateTime.Now));
            // Console.WriteLine(gs.AddTask("olga@gmail.com", "board1", "", "f this s", DateTime.Now));
            // Console.WriteLine(gs.AddTask("olga@gmail.com", "board1", "title2", "", DateTime.Now));
            // Console.WriteLine(gs.AddTask("olga@gmail.com", "board1", "title2", "f this s", DateTime.Now));
            // Console.WriteLine(gs.AddTask("olga@gmail.com", "board1", "title3", "f this s", DateTime.Now));
            // Console.WriteLine("\n");
            // Console.WriteLine("if the column has any lists in it, this will return: a Response" +
            //                   " with the list of the columns tasks");
            //
            // Console.WriteLine(gs.GetColumn("olga@gmail.com", "board1", 0));
            // Console.WriteLine(gs.GetColumn("olga@gmail.com", "board1", 1));
            // Console.WriteLine(gs.GetColumn("olga@gmail.com", "board1", 2));

            // Console.WriteLine("\n");

            GradingService gs = new GradingService();
            Console.WriteLine("if the user managed to register this should return: {} ");
            Console.WriteLine(gs.Register("olga@gmail.com", "12345Ab"));

            Console.WriteLine("\n");

            Console.WriteLine("if user removed board this should return: {} ");
            Console.WriteLine(gs.AddBoard("olga@gmail.com", "board1"));
            Console.WriteLine(gs.AddBoard("olga@gmail.com", "board2"));

            Console.WriteLine("\n");

            Console.WriteLine("if the user added a task, this should return: {} :");
            Console.WriteLine(gs.AddTask("olga@gmail.com", "board1", "title1", "f this s", DateTime.Now));
            Console.WriteLine(gs.AddTask("olga@gmail.com", "board2", "title1", "f this s", DateTime.Now));

            Console.WriteLine("\n");

            Console.WriteLine("trying to advance a task");
            // Console.WriteLine(gs.AdvanceTask("olga@gmail.com", "board1", 0, 0));
            // Console.WriteLine(gs.AdvanceTask("olga@gmail.com", "board2", 0, 1));
            //
            // Console.WriteLine(gs.AdvanceTask("olga@gmail.com", "board1", 0, 1));

            Console.WriteLine("\n");
            Console.WriteLine("backlog: ");
            Console.WriteLine(gs.GetColumn("olga@gmail.com", "board1", 0));
            Console.WriteLine("\n");
            Console.WriteLine("in progress: ");
            Console.WriteLine(gs.GetColumn("olga@gmail.com", "board1", 1));
            Console.WriteLine(gs.GetColumn("olga@gmail.com", "board2", 1));
            Console.WriteLine("\n");
            Console.WriteLine("done: ");
            Console.WriteLine(gs.GetColumn("olga@gmail.com", "board1", 2));

            Console.WriteLine("\n");
            Console.WriteLine("In progress Tasks: ");
            Console.WriteLine(gs.InProgressTasks("olga@gmail.com"));
        }
    }
}