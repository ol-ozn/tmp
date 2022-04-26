using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;


namespace BackendTests
{
    public class runTests
    {
        static void Main(string[] args)
        {
            //GradingService gs = new GradingService();
            //new userTest(new userService()).runTests();
            // new taskTest(gs).runTests();
            //new boardTest(gs).runTests();
            String jstr = "{\"ErrorMessage\":\"olga\",\"ReturnValue\":\"hello amit and yonatan!\"}";
            Console.WriteLine(jstr);
            Response jr = JsonSerializer.Deserialize<Response>(jstr);
            Console.WriteLine(jr.ErrorMessage);
            Console.WriteLine(jr.ReturnValue);

        }
    }
}
