using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;


namespace BackendTests
{
    public class runTests
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            BoardService boardService = new BoardService(userService);
            TaskService taskService = new TaskService(userService);

            UserTest ut = new UserTest(userService);
            // ut.runUserTests();
            BoardTest bt = new BoardTest(boardService, userService, taskService);
            bt.runBoardTests();
            TaskTest tt = new TaskTest(taskService, userService, boardService);
            // tt.runTaskTests();
        }
    }
}
