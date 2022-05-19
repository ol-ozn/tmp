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
            //

            // GradingService gradingService = new GradingService();
            // string email = "rrr@gmial.com";
            // string board = "one";
            // var date = "5/1/2028 8:30:00 AM";
            // var dateN = "5/1/2020 8:30:00 AM";
            // DateTime DueDate = DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture);
            // DateTime DueDateN = DateTime.Parse(dateN, System.Globalization.CultureInfo.InvariantCulture);
            // Console.WriteLine("++" + gradingService.Register(email, "Aka123k123"));                                        //create user Aka123k123
            // Console.WriteLine("++" + gradingService.Login(email, "Aka123k123"));                                           //log in user Aka123k123
            // Console.WriteLine("++" + gradingService.Logout(email));                                           //log in user Aka123k123
            // Console.WriteLine("++" + gradingService.Login(email, "Aka1256563k123"));                                           //log in user Aka123k123
            // Console.WriteLine("++" + gradingService.Login(email, "Aka123k123"));                                           //log in user Aka123k123
            //
            // string invalid = "jgiosejiooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooojjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjoooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";
            // Console.WriteLine("++" + gradingService.AddBoard(email, "one"));                                               //add board one
            // Console.WriteLine("++" + gradingService.AddBoard(email, ""));                                               //add board one
            // Console.WriteLine("++" + gradingService.AddBoard(email, "     "));                                               //add board one
            //
            // Console.WriteLine("++" + gradingService.AddBoard(email, null));                                               //add board one
            //
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", "bRAND", "HELLOW WORLD", DueDate));         // task number 0
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", "bRAND", "HELLOW WORLD", DueDateN));         //false - early
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", "bRAND", "HELLOW WORLD", DateTime.Now));         //false - early
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", "new", "HELLOW WORLD", DueDate));           //add taskID 1 new
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", null, "HELLOW WORLD", DueDate));         //null - invalid
            // Console.WriteLine("+------+" + gradingService.AddTask(email, "one", "", "HELLOW WORLD", DueDate));         //only spaces - invalid
            // Console.WriteLine(gradingService.AddTask(email, "one", "liran", "   ", DueDate));         // task number 1
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", "liran", null, DueDate));         //task number 2
            //
            // Console.WriteLine("++" + gradingService.AdvanceTask(email, "one", 0, 0));                                      //advance taskID 0 to column 1
            // Console.WriteLine("++" + gradingService.AdvanceTask(email, "one", 0, 1));                                      //advance taskID 1 to column 1
            // Console.WriteLine("++" + gradingService.AdvanceTask(email, "one", 1, 0));                                      //advance taskID 0 to column 2
            // Console.WriteLine("++" + gradingService.AdvanceTask(email, "one", 1, 1));                                      //advance taskID 1 to column 2
            // Console.WriteLine("++" + gradingService.AddTask(email, "one", "new", "HELLOW WORLD", DueDate));           //add taskID 3 new
            // Console.WriteLine("++" + gradingService.AdvanceTask(email, "one", 2, 0));                                      //advance taskID 0 to column 3 - Error
            // Console.WriteLine("++" + gradingService.AdvanceTask(email, "one", 0, 0));                                      // no such task in column 0
            // Console.WriteLine("++" + gradingService.InProgressTasks(email));                                               //error
            //
            // Console.WriteLine(gradingService.AdvanceTask(email, "one", 0, 2));                                      //advance taskID 2 to column 1
            // Console.WriteLine(gradingService.AdvanceTask(email, "one", 0, 3));                                      //advance taskID 2 to column 1
            // Console.WriteLine(gradingService.InProgressTasks(email));                                               //return taskID 2
            // Console.WriteLine(gradingService.LimitColumn(email, board, 1, 5));                                      //limit column 1 to 5
            // Console.WriteLine(gradingService.LimitColumn(email, board, 1, 4));                                      //limit column 1 to 4
            // Console.WriteLine(gradingService.LimitColumn(email, board, 1, 10));                                     //limit column 1 to 10
            // Console.WriteLine(gradingService.GetColumnLimit(email, board, 1));                                      //receive limit - 10
            // Console.WriteLine(gradingService.GetColumnName(email, board, 5));                                       // INVALID NUMBER - Error
            // Console.WriteLine(gradingService.AddTask(email, "three", "new", "HELLOW WORLD", DueDate));         // no such board three
            // Console.WriteLine(gradingService.UpdateTaskDueDate(email, "one", 1, 0, DateTime.Now));                  // not good , changes to task that not in true coloumn number
            // Console.WriteLine(gradingService.UpdateTaskDueDate(email, "one", 9, 2, DueDate));
            // Console.WriteLine("_" + gradingService.AddBoard(email, "   "));                                               //add Board 'two'
            //                                                                                                               // not good , changes to invalid coloumn number
            // Console.WriteLine(gradingService.RemoveBoard(email, "one"));                                            //delete Board one
            // Console.WriteLine(gradingService.AddTask(email, "one", "new", "HELLOW WORLD", DueDate));           //Error - there is no Board with this name
            //
            // Console.WriteLine("_" + gradingService.AddBoard(email, "one"));                                               //add Board 'two'
            // Console.WriteLine(gradingService.AddTask(email, "two", "new", "HELLOW WORLD", DueDate));           //add taskID 0 new
            // Console.WriteLine(gradingService.UpdateTaskDueDate(email, "two", 0, 0, DueDate));                  //update dueDate
            // Console.WriteLine(gradingService.UpdateTaskTitle(email, "two", 0, 0, "new title"));                     //update taskID 0 title to 'new title'
            // Console.WriteLine(gradingService.UpdateTaskTitle(email, "two", 0, 1, "new title"));                     //Error - no such task
            // Console.WriteLine(gradingService.AdvanceTask(email, "two", 0, 0));                                      //advance taskID 0 to column 1
            // Console.WriteLine(gradingService.UpdateTaskTitle(email, "two", 1, 0, "new title"));                     //update taskID 0 title to 'new title'
            // Console.WriteLine(gradingService.UpdateTaskTitle(email, "two", 1, 0, invalid));                         //Error - invalid title
            // Console.WriteLine(gradingService.UpdateTaskDescription(email, "two", 1, 0, "new descp"));               //update taskID 0 description
            // Console.WriteLine(gradingService.UpdateTaskDescription(email, "two", 1, 0, invalid));                   //Error - invalid description
            // Console.WriteLine(gradingService.LimitColumn(email, "two", 1, 1));                                      //limit column 1 to 1
            // Console.WriteLine(gradingService.AddTask(email, "two", "new task", "HELLOW WORLD", DateTime.Now));      //add taskID 2 to Board 'two' with title 'new task'
            // Console.WriteLine(gradingService.AdvanceTask(email, "two", 0, 1));

















        

            // Console.WriteLine(JsonController.toJson(task));
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
            Console.WriteLine(gradingService.LimitColumn("amir@gmail.com", "board1", 1, 4));
            
            Console.WriteLine("\n");
            
            Console.WriteLine(
                "if user managed to get the limit number of tasks in his column this should return: int value");
            Console.WriteLine(gradingService.GetColumnLimit("amir@gmail.com", "board1", 0));
            
            Console.WriteLine("\n");
            
            Console.WriteLine(
                "(this should return an error)if user managed to get the column name this should return: column name");
            Console.WriteLine(gradingService.GetColumnName("amir@gmail.com", "board1", 0));
            
            Console.WriteLine("\n");
            
            Console.WriteLine("if the user added a task, his email should be the returned value:");
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title1", "bla bla 1",
                new DateTime(2026, 5, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board2", "title2", "bla bla 2 ",
                new DateTime(2026, 6, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title3", "bla bla 3",
                new DateTime(2026, 7, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title4", "bla bla 4",
                new DateTime(2026, 8, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board1", "title5", "bla bla 5",
                new DateTime(2026, 9, 5)));
            Console.WriteLine(gradingService.AddTask("amir@gmail.com", "board2", "title6", "bla bla 6",
                new DateTime(2026, 10, 5)));
            
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
            Console.WriteLine(gradingService.GetColumn("amir@gmail.com","board2",0));
            
            
            Console.WriteLine("if the column has any lists in it, this will return: a Response" +
                              " with the list of the columns tasks");
            Console.WriteLine(gradingService.InProgressTasks("amir@gmail.com"));

        }
    }
}