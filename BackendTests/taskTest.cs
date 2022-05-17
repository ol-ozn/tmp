// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using IntroSE.Kanban.Backend.ServiceLayer;
// using System.Text.Json;
// using System.Transactions;
// using IntroSE.Kanban.Backend.BusinessLayer;
// using Task = IntroSE.Kanban.Backend.BusinessLayer.Task;
//
// namespace BackendTests
// {
//     public class TaskTest
//     {
//         private readonly TaskService taskService;
//         private readonly User currentUser;
//
//         public TaskTest(TaskService taskService, UserService userService, string userEmail, string password)
//         {
//             Response loginResponse = userService.login(userEmail, password);
//             if (loginResponse.ErrorMessage.Equals(""))
//             {
//                 currentUser = (User)loginResponse.ReturnValue;
//             }
//             else
//             {
//                 Console.WriteLine("user is not logged in");
//             }
//
//             this.taskService = taskService;
//         }
//
//
//         public void addTaskValidEntry()
//         {
//             DateTime dateTime = DateTime.UtcNow;
//             Response response = taskService.add(currentUser, "task1", "new task description", dateTime, 0);
//             if (response.ErrorMessage.Equals(""))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void addTaskTitleIsNull()
//         {
//             DateTime dateTime = DateTime.UtcNow;
//             Response response = taskService.add(currentUser, "", "new task description", dateTime, 0);
//             if (response.ErrorMessage.Equals(""))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void addTaskTitleTooLong()
//         {
//             DateTime dateTime = DateTime.UtcNow;
//             Response response = taskService.add(currentUser,
//                 "kfjdnsjfndsjkfnjkdnfjdnfjdnfjdnfjdnjsndfjnjfdnjfndjfnsjndfjfnsjnfjdsnfjdnfjsnjfndsjfndjsfnjksdnfjksdnfjdnfjdnfdj",
//                 "new task description", dateTime, 0);
//             if (response.ErrorMessage.Equals(""))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void addTaskTitleAlreadyExists() //:TODO needs to be smarter than hardcoded
//         {
//             DateTime dateTime = DateTime.UtcNow;
//             Dictionary<string, Board> userBoards = currentUser.getBoardListByName();
//             Response response = taskService.add(currentUser, "task1", "new task description", dateTime, 0);
//             if (response.ErrorMessage.Equals(""))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void addTaskDescriptionTooLong()
//         {
//             DateTime dateTime = DateTime.UtcNow;
//             Response response = taskService.add(currentUser, "",
//                 "new task description sdmkadksandjsanjkdnasjkdnsajsdnjskanfjksafkjssjfhbhdhhdsbdebdbfdbfhsdbdhbhsbhfbshbdsbhfhdbfhsbhdbhsdhfbsdhbsdfhfhjdhsdbfhdbfhdsbfhjshjbyhebfhbdshfbdhsfbdhsbfhsdbfhdsbfhjdbhjdhjdjsbfsfhdhdsbfbsdhdsdjfbshfdhsbfjsfdsdsdd" +
//                 "", dateTime, 0);
//             if (response.ErrorMessage.Equals(""))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void editValidTitle(Task task)
//         {
//             Response response = taskService.editTaskTitle("a new title", task, currentUser, 0);
//             if (response.Equals(""))
//             {
//                 Console.WriteLine("the task title was edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//
//         public void editInValidTitle(Task task)
//         {
//             Response response = taskService.editTaskTitle(
//                 "jnsadjsnjdnjdsjdndsjnjdsnjdnjdsnjsdndjsndsjndsjndsjndsjndjsndsjnjsdndjssnjdnjdsnjsdnjndjndjs", task,
//                 currentUser, 0);
//             if (response.Equals(""))
//             {
//                 Console.WriteLine("the task title was edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void editValidDescription(Task task)
//         {
//             Response response = taskService.editTaskDescription("a new description", task, currentUser);
//             if (response.Equals(""))
//             {
//                 Console.WriteLine("the task title was edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//
//         public void editInValidDescription(Task task)
//         {
//             Response response = taskService.editTaskDescription(
//                 "sdmkadksandjsanjkdnasjkdnsajsdnjskanfjksafkjssjfhbhdhhdsbdebdbfdbfhsdbdhbhsbhfbshbdsbhfhdbfhsbhdbhsdhfbsdhbsdfhfhjdhsdbfhdbfhdsbfhjshjbyhebfhbdshfbdhsfbdhsbfhsdbfhdsbfhjdbhjdhjdjsbfsfhdhdsbfbsdhdsdjfbshfdhsbfjsfdsdsdd",
//                 task, currentUser);
//             if (response.Equals(""))
//             {
//                 Console.WriteLine("the task title was edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(response.ErrorMessage);
//             }
//         }
//     }
// }