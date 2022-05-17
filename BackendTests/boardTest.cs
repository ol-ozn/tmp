using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
using IntroSE.Kanban.Backend.BusinessLayer;

namespace BackendTests
{
    public class BoardTest
    {
        private readonly BoardService bs;
        private readonly UserService us;

        public BoardTest(BoardService bs, UserService us)
        {
            this.bs = bs;
            this.us = us;
        }

        public void runBoardTests()
        {
            User user = (User)(us.createUser("yonatan@gamil.com", "Aa13456")).ReturnValue;
            addBoard1();
            us.logout("yonatan@gamil.com");
            addBoard2();
            us.login("yonatan@gamil.com", "Aa13456");
            addBoard3();
        }

        public void addBoard1()
        {
            Response res = bs.createBoard("boardName", "yonatan@gamil.com"); //should create a board
            if (res.ErrorMessage.Equals(""))
                Console.WriteLine("Account with email: olga1@gmail.com was created successfully");
            else
                Console.WriteLine(res.ErrorMessage);
            us.logout("olga1@gmail.com"); //logging out in order to test later login
        }

        public void addBoard2()
        {
            bs.createBoard("oflineBoard", "yonatan@gamil.com"); //create board while offline
        }

        public void addBoard3()
        {
            bs.createBoard("boardName", "yonatan@gamil.com"); //same board name 

        }

        public void addBoard4()
        {
            bs.createBoard("", "yonatan@gamil.com"); //same board name 
        }

        public void runTests()
        {
            string res1 = bs.createBoard("yonatan");
            Response res1j = JsonSerializer.Deserialize<Response>(res1);
            if (res1j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been added successfully");
            }
            else
            {
                Console.WriteLine(res1j.ErrorMessage);
            }

            String res2 = bs.createBoard("yonatan");
            Response res2j = JsonSerializer.Deserialize<Response>(res2);
            if (res2j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been added successfully");
            }
            else
            {
                Console.WriteLine(res2j.ErrorMessage);
            }

            String res3 = bs.remove(1);
            Response res3j = JsonSerializer.Deserialize<Response>(res3);
            if (res3j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res3j.ErrorMessage);
            }

            String res4 = bs.remove(-2);
            Response res4j = JsonSerializer.Deserialize<Response>(res4);
            if (res4j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res4j.ErrorMessage);
            }

            String res5 = bs.changeState(0, "Milestone_1");
            Response res5j = JsonSerializer.Deserialize<Response>(res5);
            if (res5j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the task has been advenced successfully");
            }
            else
            {
                Console.WriteLine(res5j.ErrorMessage);
            }

            String res6 = bs.changeState(1, "Milestone_1");
            Response res6j = JsonSerializer.Deserialize<Response>(res6);
            if (res6j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been advenced successfully");
            }
            else
            {
                Console.WriteLine(res6j.ErrorMessage);
            }

            String res7 = bs.changeState(2, "none such a board");
            Response res7j = JsonSerializer.Deserialize<Response>(res7);
            if (res7j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been advenced successfully");
            }
            else
            {
                Console.WriteLine(res7j.ErrorMessage);
            }
        }
    }
}