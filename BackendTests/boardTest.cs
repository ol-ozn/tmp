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
        }

        public void addBoard1() //should create a board successfully
        {
            Response res = boardService.createBoard("board1", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals("{}"))
                Console.WriteLine(
                    "Account with email: yonatan@gamil.com has created a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard2() //should return that board with such name already exists
        {
            Response res = boardService.createBoard("board1", "yonatan@gamil.com"); //should create a board
            if (res.ErrorMessage == null)
                Console.WriteLine(
                    "Account with email: yonatan@gamil.com has created a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard3() //should return illegal board name
        {
            Response res = boardService.createBoard("", "yonatan@gamil.com"); //should create a board
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan@gamil.com has created a board with name \"\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard4() //should return attempt to create board to a logged-out user
        {
            userService.logout("yonatan@gamil.com");
            Response res = boardService.createBoard("board2", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan@gamil.com has created a board with name \"board2\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void addBoard5() //should return attempt to create board to a non-existing user
        {
            userService.login("yonatan@gamil.com", "Aa13456");
            Response res = boardService.createBoard("board222", "yonatan222@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan222@gamil.com has created a board with name \"board222\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard1() //should remove successfully
        {
            Response res = boardService.removeBoard("board1", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan@gamil.com has removed a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard2() //should return attempt to remove board that didn't exist in the first place
        {
            Response res = boardService.removeBoard("board2", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan@gamil.com has removed a board with name \"board2\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard3() //should return the account doesn't even exist
        {
            Response res = boardService.removeBoard("board222", "yonatan222@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan222@gamil.com has removed a board with name \"board222\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void removeBoard4() //should return the account isn't even logged in
        {
            userService.logout("yonatan@gamil.com");
            Response res = boardService.removeBoard("board1", "yonatan@gamil.com");
            if (res.ErrorMessage.Equals(null))
                Console.WriteLine(
                    "Account with email: yonatan222@gamil.com has removed a board with name \"board1\" successfully");
            else
                Console.WriteLine(res.ErrorMessage);
        }

        public void limitColumn1()
        {

        }
    }
}