using System;

using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
public class userTest
{
    private readonly userService us;
    public userTest(userService us)
    {
        this.us = us;
    }
    public void runTests()
    {
        //testing creation of an account
        String res1 = us.createUser("olga@gmail.com", "1234");
        Response res1j = JsonSerializer.Deserialize<Response>(res1);
        if (res1j.ErrorMessage.Equals("ok"))
        {
            Console.WriteLine("register completed successfully");
        } else
        {
            Console.WriteLine(res1j.ErrorMessage);
        
        String res2 = us.createUser("olga@gmail.com", "1234");
        Response res2j = JsonSerializer.Deserialize<Response>(res2);
        if (res2j.ErrorMessage.Equals("good"))
        {
            Console.WriteLine("register completed successfully");
        }
        else
        {
            Console.WriteLine(res2j.ErrorMessage);
        }
        
        //testing login of an account
        String res3 = us.login("yonatan@gmail.com", "2345");
        Response res3j = JsonSerializer.Deserialize<Response>(res3);
        if (res3j.ErrorMessage.Equals("good"))
        {
            Console.WriteLine("login completed successfully");
        }
        else
        {
            Console.WriteLine(res3j.ErrorMessage);
        }
        String res4 = us.login("olga@gmail.com", "2345");
        Response res4j = JsonSerializer.Deserialize<Response>(res4);
        if (res4j.ErrorMessage.Equals("good"))
        {
            Console.WriteLine("login completed successfully");
        }
        else
        {
            Console.WriteLine(res4j.ErrorMessage);
        }
        String res5 = us.login("olga@gmail.com", "1234");
        Response res5j = JsonSerializer.Deserialize<Response>(res5);
        if (res5j.ErrorMessage.Equals("good"))
        {
            Console.WriteLine("login completed successfully");
        }
        else
        {
            Console.WriteLine(res5j.ErrorMessage);
        }

        //testing logging out of an account
        String res6 = us.logout();
        Response res6j = JsonSerializer.Deserialize<Response>(res6);
        if (res6j.ErrorMessage.Equals("good"))
        {
            Console.WriteLine("logout completed successfully");
        }
        else
        {
            Console.WriteLine(res6j.ErrorMessage);
        }

        //testing deletion of an account
        String res7 = us.deleteAccount();
        Response res7j = JsonSerializer.Deserialize<Response>(res7);
        if (res7j.ErrorMessage.Equals("good"))
        {
            Console.WriteLine("Account deleted successfully");
        }
        else
        {
            Console.WriteLine(res7j.ErrorMessage);
        }
    }
}
