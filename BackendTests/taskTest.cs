using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
using System.Transactions;
using IntroSE.Kanban.Backend.BusinessLayer;
using Task = IntroSE.Kanban.Backend.BusinessLayer.Task;

namespace BackendTests
{
    public class TaskTest
    {
        private readonly TaskService taskService;
        private readonly string currentUser;

        public TaskTest(TaskService taskService, UserService userService, BoardService boardService)
        {
            Response response = userService.createUser("amitabr@mail.com", "987654Kanban");
            currentUser = "amitabr@mail.com";
            boardService.createBoard("board1", currentUser);
            this.taskService = taskService;
        }


        public void runTaskTests()
        {
            addTaskValidEntry();
            addTaskTitleIsNull();
            addTaskTitleTooLong();
            addTaskTitleAlreadyExists();
            addTaskDescriptionTooLong();
            editValidTitle();
            editInValidTitleEmpty();
            editInValidTitleTooLong();
            editValidDescription();
            editInValidDescriptionTooLong();
        }


        public void addTaskValidEntry()
        {
            DateTime dateTime = DateTime.UtcNow;
            Response response =
                taskService.add("task1", "new task description", dateTime, "board1", currentUser);
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task has been added successfully");
            }

            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void addTaskTitleIsNull()
        {
            DateTime dateTime = DateTime.UtcNow;
            Response response = taskService.add("", "new task description", dateTime, "board1", currentUser);
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task has been added successfully");
            }

            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void addTaskTitleTooLong()
        {
            DateTime dateTime = DateTime.UtcNow;
            Response response =
                taskService.add(
                    "dnmfjdsnmjkfddnjkfdsnjkfndsjdnfjsfkfjsnfddsjdnfknfdfjsdjnsjnsnsdjkjnkfjdfdnfsjkdjfnsjndsfdsjknfsdffndsnjsdjks",
                    "new task description", dateTime, "board1", currentUser);
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task has been added successfully");
            }

            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void addTaskTitleAlreadyExists()
        {
            DateTime dateTime = DateTime.UtcNow;
            taskService.add("task1", "first1", dateTime, "board1", currentUser);
            taskService.add("task1", "bla bla bla", dateTime, "board1", currentUser);
            Response response = taskService.add("task1", "new task description", dateTime, "board1", currentUser);
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task has been added successfully");
            }

            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void addTaskDescriptionTooLong()
        {
            DateTime dateTime = DateTime.UtcNow;
            Response response = taskService.add("title2",
                "a new task description new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task descriptiona new task description",
                dateTime, "board1", currentUser);
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task has been added successfully");
            }

            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void editValidTitle()
        {
            Response user = taskService.add("task1", "new task description", new DateTime(2022, 05, 16), "board1",
                currentUser);
            Response response = taskService.editTaskTitle(currentUser, "board1", 0, 0, "this is my new title");
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task title was edited successfully");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }


        public void editInValidTitleEmpty()
        {
            Response user = taskService.add("task1", "new task description", new DateTime(2022, 05, 16), "board1",
                currentUser);
            Response response = taskService.editTaskTitle(currentUser, "board1", 0, 0, "");
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task title was edited successfully");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void editInValidTitleTooLong()
        {
            Response user = taskService.add("task1", "new task description", new DateTime(2022, 05, 16), "board1",
                currentUser);
            Response response = taskService.editTaskTitle(currentUser, "board1", 0, 0,
                "dnmfjdsnmjkfddnjkfdsnjkfndsjdnfjsfkfjsnfddsjdnfknfdfjsdjnsjnsnsdjkjnkfjdfdnfsjkdjfnsjndsfdsjknfsdffndsnjsdjks");
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task title was edited successfully");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void editValidDescription()
        {
            Response user = taskService.add("task1", "new task description", new DateTime(2022, 05, 16), "board1",
                currentUser);
            Response response = taskService.editTaskDescription(currentUser, "board1", 0, 0, "an edited description");
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task title was edited successfully");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public void editInValidDescriptionTooLong()
        {
            Response user = taskService.add("task1", "new task description", new DateTime(2022, 05, 16), "board1",
                currentUser);
            Response response = taskService.editTaskDescription(currentUser, "board1", 0, 0,
                "this cannot continue this cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continuethis cannot continue");
            if (response.ErrorMessage == null)
            {
                Console.WriteLine("the task title was edited successfully");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        //
        // public void changeState1() //should change state successfully
        // {
        //     User user = (User)userService.login("yonatan@gamil.com", "Aa13456").ReturnValue;
        //     boardService.createBoard("try", "yonatan@gamil.com");
        //     taskService.add("hello", "beep boop", new DateTime(2022, 5, 17), "try", "yonatan@gamil.com");
        //
        //     Response res = boardService.changeState("yonatan@gamil.com", "try", 0, 0);
        //     if (res.ErrorMessage.Equals(null))
        //     {
        //         Console.WriteLine("changed the task with title hello successfully from backlog to inprogress");
        //     }
        //     else
        //     {
        //         Console.Write(res.ErrorMessage);
        //     }
        // }
        //
        // public void changeState2() //should return we advanced from inprogress to done
        // {
        //     Response res = boardService.changeState("yonatan@gamil.com", "try", 1, 0);
        //     if (res.ErrorMessage.Equals(null))
        //     {
        //         Console.WriteLine("changed the task with title hello successfully from inprogress to done");
        //     }
        //     else
        //     {
        //         Console.Write(res.ErrorMessage);
        //     }
        // }
        //
        // public void changeState3() //should return we cant advance task from done
        // {
        //     Response res = boardService.changeState("yonatan@gamil.com", "try", 2, 0);
        //     if (res.ErrorMessage.Equals(null))
        //     {
        //         Console.WriteLine("changeState 3 failed");
        //     }
        //     else
        //     {
        //         Console.Write(res.ErrorMessage);
        //     }
        // }
        //
        // public void changeState4() // should return that the task with this id wasn't found in the column
        // {
        //     Response ignore = taskService.add("test4", "bla bla bla", new DateTime(2022, 5, 18), "try",
        //         "yonatan@gamil.com");
        //     Response res = boardService.changeState("yonatan@gamil.com", "try", 0, 3984);
        //     if (res.ErrorMessage.Equals(null))
        //     {
        //         Console.WriteLine("changed the task with id 3984 successfully from backlog to inprogress");
        //     }
        //     else
        //     {
        //         Console.Write(res.ErrorMessage);
        //     }
        // }

    }
}