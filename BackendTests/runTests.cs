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
            // UserService userService = new UserService();
            // BoardService boardService = new BoardService(userService);
            // TaskService taskService = new TaskService(userService);
            //
            // UserTest ut = new UserTest(userService);
            // // ut.runUserTests();
            // BoardTest bt = new BoardTest(boardService, userService, taskService);
            // bt.runBoardTests();
            // TaskTest tt = new TaskTest(taskService, userService, boardService);
            // // tt.runTaskTests();
            User user = new User("blablabla@gmail.com", "51518Aa",0);
            Task task = new Task("task1", "bla bla bla", new DateTime(2023, 5, 8), "bla bla", user, 0);
            // Console.WriteLine(task);
            Console.WriteLine(toJson(user));
            // string s = JsonSerializer.Serialize(task);
            // Console.WriteLine(s);
            
        }

        public static string toJson(object obj)
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            return JsonSerializer.Serialize(obj, obj.GetType(), options);
        }

    }
}
