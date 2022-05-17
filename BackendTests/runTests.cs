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
            UserTest ut = new UserTest(userService);
            ut.runUserTests();
            BoardService boardService = new BoardService(userService);
            BoardTest bt = new BoardTest(boardService, userService);
            // bt.runBoardTests();
        }
    }
}
