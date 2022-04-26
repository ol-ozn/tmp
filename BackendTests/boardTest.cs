using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace BackendTests
{
    public class boardTest
    {
        private readonly GradingService gs;
        public boardTest(GradingService gs)
        {
            this.gs = gs;
        }

        public void runTests()
        {
            String res1 = gs.LimitColumn("amit@gmail.com", "milstone1", 0, 5);
            if (res1.Equals("good"))
            {
                Console.WriteLine("limited the task amount in the column successfully");

            } else
            {
                Console.WriteLine(res1);
            }
            String res2 = gs.LimitColumn("amit@gmail.com", "milstone1", -2, 3);
            if (res2.Equals("good"))
            {
                Console.WriteLine("limited the task amount in the column successfully");
            }
            else
            {
                Console.WriteLine(res2);
            }

            String res3 = gs.GetColumnLimit("amit@gmail.com", "milstone1", 1);
            if (res3.Equals("good"))
            {
                Console.WriteLine("action completed successfully");
            }
            else
            {
                Console.WriteLine(res3);
            }

            String res4 = gs.GetColumnName("amit@gmail.com", "milstone1", 1);
            if (res4.Equals("good"))
            {
                Console.WriteLine("action completed successfully");
            }
            else
            {
                Console.WriteLine(res4);
            }

            String res5 = gs.AddTask("amit@gmail.com", "milstone1", "do uml", "create uml in drawio", new DateTime(2022,04,27)) ;
            if (res5.Equals("good"))
            {
                Console.WriteLine("the task has been added successfully");
            }
            else
            {
                Console.WriteLine(res5);
            }
            String res6 = gs.AddTask("amit@gmail.com", "milstone1", "do uml", "create uml in drawio", new DateTime(2022, 04, 27)); //should return the task exists already
            if (res6.Equals("good"))
            {
                Console.WriteLine("the task has been added successfully");
            }
            else
            {
                Console.WriteLine(res6);
            }

            String res7 = gs.AdvanceTask("amit@gmail.com", "milstone1", 1, 5);
            if (res7.Equals("good"))
            {
                Console.WriteLine("the task has been advanced successfully");
            }
            else
            {
                Console.WriteLine(res7);
            }
            String res8 = gs.AdvanceTask("amit@gmail.com", "milstone1", 2, 5);
            if (res8.Equals("good"))
            {
                Console.WriteLine("the task has been advanced successfully");
            }
            else
            {
                Console.WriteLine(res8);
            }

            String res9 = gs.GetColumn("amit@gmail.com", "milstone1", 1);
            if (res9.Equals("good"))
            {
                Console.WriteLine("the column has been returned successfully");
            }
            else
            {
                Console.WriteLine(res9);
            }

            String res10 = gs.AddBoard("amit@gmail.com", "ms1");
            if (res10.Equals("good"))
            {
                Console.WriteLine("the board has been added successfully");
            }
            else
            {
                Console.WriteLine(res10);
            }
            String res11 = gs.AddBoard("amit@gmail.com", "ms1"); //should return the board name is taken already
            if (res11.Equals("good"))
            {
                Console.WriteLine("the board has been added successfully");
            }
            else
            {
                Console.WriteLine(res11);
            }

            String res12 = gs.RemoveBoard("amit@gmail.com", "ms1");
            if (res12.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res12);
            }
            String res13 = gs.RemoveBoard("amit@gmail.com", "ms1"); //should return that there's no such board
            if (res13.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res13);
            }
            
            String res14 = gs.InProgressTasks("amit@gmail.com");
            if (res14.Equals("good"))
            {
                Console.WriteLine("the tasks have been returned successfully");
            }
            else
            {
                Console.WriteLine(res14);
            }
        }
    }
}
