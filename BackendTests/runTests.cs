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
            BoardService bs = new BoardService();
            TaskService ts = new TaskService();
            UserService us = new UserService();
            new BoardTest(bs).runTests();
            new TaskTest(ts).runTests();
            new UserTest(us).runTests();
          

        }
    }
}
