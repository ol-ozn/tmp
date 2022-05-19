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
        private readonly BoardService boardService;
        private readonly UserService userService;
        private readonly TaskService taskService;

        public BoardTest(BoardService boardService, UserService userService, TaskService taskService)
        {
            this.boardService = boardService;
            this.userService = userService;
            this.taskService = taskService;
        }

        public void runBoardTests()
        {
            Response res = userService.createUser("yonatan@gamil.com", "Aa13456");
             addBoard1();
             addBoard2();
             addBoard3();
             addBoard4();
             addBoard5();
             
             removeBoard1();
             removeBoard2();
             removeBoard3();
             removeBoard4();
            
            changeState1();
             changeState2();
             changeState3();
             changeState4();
        }

        public void addBoard1() //should create a board successfully
        {
            Response res = boardService.createBoard("board1", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals("{}"))
                Console.WriteLine("Account with email: yonatan@gamil.com has created a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard2() //should return that board with such name already exists
        {
            Response res = boardService.createBoard("board1", "yonatan@gamil.com"); //should create a board
            if (res.ErrorMessage == null)
                Console.WriteLine("Account with email: yonatan@gamil.com has created a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard3() //should return illegal board name
        {
            Response res = boardService.createBoard("", "yonatan@gamil.com"); //should create a board
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan@gamil.com has created a board with name \"\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard4() //should return attempt to create board to a logged-out user
        {
            userService.logout("yonatan@gamil.com");
            Response res = boardService.createBoard("board2", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan@gamil.com has created a board with name \"board2\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard5() //should return attempt to create board to a non-existing user
        {
            userService.login("yonatan@gamil.com", "Aa13456");
            Response res = boardService.createBoard("board222", "yonatan222@gamil.com"); 
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan222@gamil.com has created a board with name \"board222\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard1() //should remove successfully
        {
            Response res = boardService.remove("board1", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan@gamil.com has removed a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard2() //should return attempt to remove board that didn't exist in the first place
        {
            Response res = boardService.remove("board2", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan@gamil.com has removed a board with name \"board2\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }
        public void removeBoard3() //should return the account doesn't even exist
        {
            Response res = boardService.remove("board222", "yonatan222@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan222@gamil.com has removed a board with name \"board222\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard4() //should return the account isn't even logged in
        {
            userService.logout("yonatan@gamil.com");
            Response res = boardService.remove("board1", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine("Account with email: yonatan222@gamil.com has removed a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }


        public void changeState1() //should change state successfully
        {
            User user = (User)userService.login("yonatan@gamil.com", "Aa13456").ReturnValue;
            boardService.createBoard("try", "yonatan@gamil.com");
            taskService.add("hello", "beep boop", new DateTime(2022 , 5,17), "try", "yonatan@gamil.com");

            Response res = boardService.changeState("yonatan@gamil.com", "try", 0, 0);
            if (res.ErrorMessage.Equals(null))
            {
                Console.WriteLine("changed the task with title hello successfully from backlog to inprogress");
            }
            else
            {
                Console.Write(res.ErrorMessage);
            }
        }

        public void changeState2() //should return we advanced from inprogress to done
        {
            Response res = boardService.changeState("yonatan@gamil.com", "try", 1, 0);
            if (res.ErrorMessage.Equals(null))
            {
                Console.WriteLine("changed the task with title hello successfully from inprogress to done");
            }
            else
            {
                Console.Write(res.ErrorMessage);
            }
        }

        public void changeState3() //should return we cant advance task from done
        {
            Response res = boardService.changeState("yonatan@gamil.com", "try", 2, 0);
            if (res.ErrorMessage.Equals(null))
            {
                Console.WriteLine("changeState 3 failed");
            }
            else
            {
                Console.Write(res.ErrorMessage);
            }
        }
        public void changeState4() // should return that the task with this id wasn't found in the column
        {
            Response ignore = taskService.add("test4", "bla bla bla", new DateTime(2022, 5, 18), "try",
                "yonatan@gamil.com");
            Response res = boardService.changeState("yonatan@gamil.com", "try", 0, 3984);
            if (res.ErrorMessage.Equals(null))
            {
                Console.WriteLine("changed the task with id 3984 successfully from backlog to inprogress");
            }
            else
            {
                Console.Write(res.ErrorMessage);
            }
        }

    }
}