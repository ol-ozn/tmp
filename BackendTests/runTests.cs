using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
using IntroSE.Kanban.Backend.BusinessLayer;
using Task = IntroSE.Kanban.Backend.BusinessLayer.Task;


namespace BackendTests
{
    public class runTests
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            BoardService boardService = new BoardService(userService);
            TaskService taskService = new TaskService(userService);
            //
            // UserTest ut = new UserTest(userService);
            // // ut.runUserTests();
            // BoardTest bt = new BoardTest(boardService, userService, taskService);
            // bt.runBoardTests();
            // TaskTest tt = new TaskTest(taskService, userService, boardService);
            // // tt.runTaskTests();
            User user = new User("blablabla@gmail.com", "51518Aa",0);
            Task task = new Task("task1", "bla bla bla", new DateTime(2023, 5, 8), "bla bla", user, 0);
            // Console.WriteLine(JsonController.toJson(task));
            GradingService gradingService = new GradingService();
            Console.WriteLine(gradingService.Register("amir@gmail.com","5484894Amir"));
            Console.WriteLine(gradingService.AddBoard("amir@gmail.com","board1"));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com","board1","title1","bla bla",new DateTime(2025,5,5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com","board1","title2","bla bla 2",new DateTime(2026,5,5)));
            Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1",0,0));
            Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1",0,1));
            Console.WriteLine(gradingService.InProgressTasks("amir@gmail.com"));

            // Console.WriteLine(gradingService.Login("amir@gmail.com","5484894Amir"));
            // Console.WriteLine(gradingService.Logout("amir@gmail.com"));
            // Console.WriteLine(gradingService.LimitColumn("amir@gmail.com","board1",0,-1));
            // Console.WriteLine(gradingService.InProgressTasks("amir@gmail.com"));
            // string s = JsonSerializer.Serialize(task);
            // Console.WriteLine(s);

        }
    }
}
