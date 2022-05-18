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

            // Console.WriteLine(JsonController.toJson(task));
            GradingService gradingService = new GradingService();
            Console.WriteLine(gradingService.Register("amir@gmail.com","985415Amir"));
            Console.WriteLine(gradingService.Logout("amir@gmail.com"));
            Console.WriteLine(gradingService.Login("amir@gmail.com", "985415Amir"));
            Console.WriteLine(gradingService.AddBoard("amir@gmail.com","board1"));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com","board1","title2","bla bla 2",new DateTime(2026,5,5)));
            Console.WriteLine(gradingService.GetColumnLimit("amir@gmail.com", "board1", 1));

        }
    }
}
