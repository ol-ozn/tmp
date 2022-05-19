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




            GradingService gradingService = new GradingService();
            Console.WriteLine("if the user managed to register this should return: {} ");
            Console.WriteLine(gradingService.Register("amir@gmail.com", "Test12345"));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the user managed to login, this should return the users email:  ");
            Console.WriteLine(gradingService.Login("amir@gmail.com", "Test12345"));
            
            Console.WriteLine("\n");
            
            // Console.WriteLine("if the user managed to logout this should return: {} ");
            // Console.WriteLine(gradingService.Logout("amir@gmail.com"));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if user added a board this should return: {} ");
            Console.WriteLine(gradingService.AddBoard("amir@gmail.com", "board1"));
            Console.WriteLine(gradingService.AddBoard("amir@gmail.com", "board2"));
            
            Console.WriteLine("\n");
            
            // Console.WriteLine("if user removed board this should return: {} ");
            // Console.WriteLine(gradingService.RemoveBoard("amir@gmail.com", "board1"));
            // Console.WriteLine(gradingService.RemoveBoard("amir@gmail.com", "board2"));
            
            
            Console.WriteLine("if user managed to limit the number of tasks in his column this should return: {} ");
            Console.WriteLine(gradingService.LimitColumn("amir@gmail.com", "board1", 0, 4));
            
            Console.WriteLine("\n");
            
            
            Console.WriteLine("if the user added a task, his email should be the returned value:");
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title1", "bla bla 1",
                new DateTime(2026, 5, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title1", "bla bla 2 ",
                new DateTime(2026, 6, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title3", "bla bla 3",
                new DateTime(2026, 7, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title4", "bla bla 4",
                new DateTime(2026, 8, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title5", "bla bla 5",
                new DateTime(2026, 9, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title6", "bla bla 5",
                new DateTime(2026, 9, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board2", "title7", "bla bla 6",
                new DateTime(2026, 10, 5)));
            
            Console.WriteLine("\n");
            
            Console.WriteLine(
                "if user managed to get the limit number of tasks in his column this should return: int value");
            Console.WriteLine(gradingService.GetColumnLimit("amir@gmail.com", "board1", 0));
            
            Console.WriteLine("\n");
            
            Console.WriteLine(
                "(this should return an error)if user managed to get the column name this should return: column name");
            Console.WriteLine(gradingService.GetColumnName("amir@gmail.com", "board1", 0));
            
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the user updated a task due date this should return: {}");
            Console.WriteLine(gradingService.UpdateTaskDueDate("amir@gmail.com", "board1", 0, 0,
                new DateTime(2028, 11, 5)));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the user updated a tasks title successfully this should return: {}");
            Console.WriteLine(gradingService.UpdateTaskTitle("amir@gmail.com", "board1", 0, 0, "a new title yay!"));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the user updated a tasks description successfully this should return: {}");
            Console.WriteLine(
                gradingService.UpdateTaskDescription("amir@gmail.com", "board1", 0, 0, "a new description yay!"));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the task was advanced correctly this will return: {}");
            Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1", 0, 3));
            Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board2", 0, 1));
            Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1", 1, 3));
            Console.WriteLine(gradingService.AdvanceTask("amir@gmail.com", "board1", 2, 3));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the column has any lists in it, this will return: a Response" +
                              " with the list of the columns tasks");
            Console.WriteLine(gradingService.GetColumn("amir@gmail.com", "board2", 2));
            
            
            Console.WriteLine("if the column has any lists in it, this will return: a Response" +
                              " with the list of the columns tasks");
            Console.WriteLine(gradingService.InProgressTasks("amir@gmail.com"));
        }
    }
}