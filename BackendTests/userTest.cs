using System;

using IntroSE.Kanban.Backend.ServiceLayer;
public class userTest
{
    private readonly GradingService gs;
    public userTest(GradingService gs)
    {
        this.gs = gs;
    }
    public void runTests()
    {
        String res1 = gs.Register("olga@gmail.com", "1234");
        if(res1.Equals("good"))
        {
            Console.WriteLine("register completed successfully");
        } else
        {
            Console.WriteLine(res1);
        }
        String res2 = gs.Register("olga@gmail.com", "1234");
        if (res2.Equals("good"))
        {
            Console.WriteLine("register completed successfully");
        }
        else
        {
            Console.WriteLine(res2);
        }

        String res3 = gs.Login("yonatan@gmail.com", "2345");
        if (res3.Equals("good"))
        {
            Console.WriteLine("login completed successfully");
        }
        else
        {
            Console.WriteLine(res3);
        }
        String res4 = gs.Login("olga@gmail.com", "2345");
        if (res4.Equals("good"))
        {
            Console.WriteLine("login completed successfully");
        }
        else
        {
            Console.WriteLine(res4);
        }
        String res5 = gs.Login("olga@gmail.com", "1234");
        if (res5.Equals("good"))
        {
            Console.WriteLine("login completed successfully");
        }
        else
        {
            Console.WriteLine(res5);
        }

        String res6 = gs.Logout("olga@gmail.com");
        if (res6.Equals("good"))
        {
            Console.WriteLine("logout completed successfully");
        }
        else
        {
            Console.WriteLine(res6);
        }
    }
}
