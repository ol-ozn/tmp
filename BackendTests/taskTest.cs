using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace BackendTests
{
    public class taskTest
    {
        private readonly GradingService gs;
        public taskTest(GradingService gs)
        {
            this.gs = gs;
        }
        public void runTests()
        {
            String res1 = gs.UpdateTaskDueDate("yonatan@gmail.com", "milestone1", 2, 3, new DateTime(2022,04,26));
            if(res1.Equals("good"))
            {
                Console.WriteLine("due date has been changed successfully");
            } else
            {
                Console.WriteLine(res1);
            }

            String res2 = gs.UpdateTaskTitle("yonatan@gmail.com", "milestone1", 2, 3, "ms1");
            if (res2.Equals("good"))
            {
                Console.WriteLine("task title has been changed successfully");
            }
            else
            {
                Console.WriteLine(res2);
            }

            String res3 = gs.UpdateTaskDescription("yonatan@gmail.com", "milestone1", 2, 3, "1st milestone out of many many many many...........");
            if (res3.Equals("good"))
            {
                Console.WriteLine("task description has been changed successfully");
            }
            else
            {
                Console.WriteLine(res3);
            }
        }
    }
}
