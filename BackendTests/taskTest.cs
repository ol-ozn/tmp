// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using IntroSE.Kanban.Backend.ServiceLayer;
// using System.Text.Json;
//
// namespace BackendTests
// {
//     public class TaskTest
//     {
//         private readonly TaskService ts;
//         public TaskTest(TaskService ts)
//         {
//             this.ts = ts;
//         }
//         public void runTests()
//         {
//             String res1 = ts.addTask("milstone 1");
//             Response res1j = JsonSerializer.Deserialize<Response>(res1);
//             if (res1j.ErrorMessage.Equals("ok"))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//             else
//             {
//                 Console.WriteLine(res1j.ErrorMessage);
//             }
//
//             String res2 = ts.editTask(1, "Task_1", "im changing the discription");
//             Response res2j = JsonSerializer.Deserialize<Response>(res2);
//             if (res2j.ErrorMessage.Equals("ok"))
//             {
//                 Console.WriteLine("the taks has been edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(res2j.ErrorMessage);
//             }
//             String res3 = ts.editTask(-51, "Task_1", "im changing the discription");
//             Response res3j = JsonSerializer.Deserialize<Response>(res3);
//             if (res3j.ErrorMessage.Equals("ok"))
//             {
//                 Console.WriteLine("the taks has been edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(res3j.ErrorMessage);
//             }
//             String res4 = ts.editTask(0, "not exsit task", "im changing the discription");
//             Response res4j = JsonSerializer.Deserialize<Response>(res4);
//             if (res4j.ErrorMessage.Equals("ok"))
//             {
//                 Console.WriteLine("the taks has been edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(res4j.ErrorMessage);
//             }
//             String res5 = ts.editTask(0, "not exsit task", "");
//             Response res5j = JsonSerializer.Deserialize<Response>(res5);
//             if (res5j.ErrorMessage.Equals("ok"))
//             {
//                 Console.WriteLine("the taks has been edited successfully");
//             }
//             else
//             {
//                 Console.WriteLine(res5j.ErrorMessage);
//             }
//             String res6 = ts.addTask("");
//             Response res6j = JsonSerializer.Deserialize<Response>(res1);
//             if (res6j.ErrorMessage.Equals("ok"))
//             {
//                 Console.WriteLine("the task has been added successfully");
//             }
//             else
//             {
//                 Console.WriteLine(res6j.ErrorMessage);
//             }
//         }
//     }
// }
