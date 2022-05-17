using System;

using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;

public class UserTest
{
    private readonly UserService us;

    public UserTest(UserService us)
    {
        this.us = us;
    }

    public void runUserTests()
    {
        createUser1();
        createUser2();
        createUser3();
        createUser4();
        createUser5();
        createUser6();
        createUser7();
        createUser8();
        login1();
        login2();
        login3();
        login4();
        logout1();
        logout2();
        logout3();
        delete1();
        delete2();
    }

    public void createUser1() //should be correct
    {
        Response res = us.createUser("olga1@gmail.com", "Abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
        us.logout("olga1@gmail.com"); //logging out in order to test later login
    }

    public void createUser2() //account should already exist
    {
        Response res = us.createUser("olga1@gmail.com", "Abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void createUser3() //email should be invalid
    {
        Response res = us.createUser("olga1gmail.com", "Abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void createUser4() //password should be invalid - no capital
    {
        Response res = us.createUser("olga2@gmail.com", "abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga2@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void createUser5() //password should be invalid - too short
    {
        Response res = us.createUser("olga2@gmail.com", "abc45");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga2@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void createUser6() //password should be invalid - no number
    {
        Response res = us.createUser("olga2@gmail.com", "abcdefGH");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga2@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void createUser7() //password should be invalid - no lower case
    {
        Response res = us.createUser("olga2@gmail.com", "ABCDEF34");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga2@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void createUser8() //password should be invalid - too long
    {
        Response res = us.createUser("olga2@gmail.com", "THIS1iswayTOOlongofApasswordWHOWILLrememberit");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga2@gmail.com was created successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void login1() //should log in well
    {
        Response res = us.login("olga1@gmail.com", "Abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was logged in successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void login2() //should return already logged in
    {
        Response res = us.login("olga1@gmail.com", "Abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was logged in successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void login3() //should return the account doesn't exist
    {
        Response res = us.login("olga3@gmail.com", "Abc12345");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga3@gmail.com was logged in successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void login4() //should return wrong password
    {
        Response res = us.login("olga1@gmail.com", "WRongPa55word");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was logged in successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void logout1() //should work well 
    {
        Response res = us.logout("olga1@gmail.com");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was logged out successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void logout2() //should return already logged out
    {
        Response res = us.logout("olga1@gmail.com");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was logged out successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void logout3() //should return user with such email doesn't exist
    {
        Response res = us.logout("olga4@gmail.com");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga4@gmail.com was logged out successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void delete1() //should work well
    {
        Response res = us.deleteAccount("olga1@gmail.com");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was deleted successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }

    public void delete2() //should return user doesn't exist
    {
        Response res = us.deleteAccount("olga1@gmail.com");
        if (res.ErrorMessage.Equals(""))
            Console.WriteLine("Account with email: olga1@gmail.com was deleted successfully");
        else
            Console.WriteLine(res.ErrorMessage);
    }
}