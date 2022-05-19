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

    }
}