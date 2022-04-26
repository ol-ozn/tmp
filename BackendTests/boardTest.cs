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
        private readonly boardService bs;
        public boardTest(boardService bs)
        {
            this.bs = bs;
        }

        public void runTests()
        {
   
            String res1 = bs.add("amit@gmail.com") ;
            if (res1.Equals("good"))
            {
                Console.WriteLine("the task has been added successfully");
            }
            else
            {
                Console.WriteLine(res1);
            }
            String res2 = bs.add("yonatan");
            if (res2.Equals("good"))
            {
                Console.WriteLine("the task has been added successfully");
            }
            else
            {
                Console.WriteLine(res2);
            }
            String res3 = bs.remove("amit@gmail.com");
            if (res3.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res3);
            }
            String res4 = bs.remove("yone");
            if (res4.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res4);
            }
            String res5 = bs.changeState("amit@gmail.com", "Milestone_1");
            if (res5.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res5);
            }
            String res6 = bs.changeState("yone", "Milestone_1");
            if (res6.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res6);
            }
            String res7 = bs.changeState("yone", "none such a board");
            if (res7.Equals("good"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res7);
            }
            
        }
    }
}
