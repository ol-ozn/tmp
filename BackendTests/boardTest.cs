using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;

namespace BackendTests
{
    public class BoardTest
    {
        private readonly BoardService bs;
        public BoardTest(BoardService bs)
        {
            this.bs = bs;
        }

        public void runTests()
        {
   
           
            String res1 = bs.createBoard("yonatan") ;
            Response res1j = JsonSerializer.Deserialize<Response>(res1);
            if (res1j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been added successfully");
            }
            else
            {
                Console.WriteLine(res1j.ErrorMessage);
            }
            String res2 = bs.createBoard("yonatan");
            Response res2j = JsonSerializer.Deserialize<Response>(res2);
            if (res2j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been added successfully");
            }
            else
            {
                Console.WriteLine(res2j.ErrorMessage);
            }
            String res3 = bs.remove(1);
            Response res3j = JsonSerializer.Deserialize<Response>(res3);
            if (res3j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res3j.ErrorMessage);
            }
            String res4 = bs.remove(-2);
            Response res4j = JsonSerializer.Deserialize<Response>(res4);
            if (res4j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been removed successfully");
            }
            else
            {
                Console.WriteLine(res4j.ErrorMessage);
            }
            String res5 = bs.changeState(0, "Milestone_1");
            Response res5j = JsonSerializer.Deserialize<Response>(res5);
            if (res5j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the task has been advenced successfully");
            }
            else
            {
                Console.WriteLine(res5j.ErrorMessage);
            }
            String res6 = bs.changeState(1, "Milestone_1");
            Response res6j = JsonSerializer.Deserialize<Response>(res6);
            if (res6j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been advenced successfully");
            }
            else
            {
                Console.WriteLine(res6j.ErrorMessage);
            }
            String res7 = bs.changeState(2, "none such a board");
            Response res7j = JsonSerializer.Deserialize<Response>(res7);
            if (res7j.ErrorMessage.Equals("ok"))
            {
                Console.WriteLine("the board has been advenced successfully");
            }
            else
            {
                Console.WriteLine(res7j.ErrorMessage);
            }
            
        }
    }
}
