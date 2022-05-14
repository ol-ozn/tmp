using System;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;

public class UserService
{
    private UserController uc; 
    public UserService()
    {
        uc = new UserController();
    }

    /// <summary>
    ///  This method logs in an existing user.
    /// </summary>
    /// <param name="email">The email address of the user to login</param>
    /// <param name="password">The password of the user to login</param>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response login(String email, String password)
    {
        try
        {
            User user = uc.login(email, password);
            return new Response("", user);
        }
        catch (Exception e)
        {
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method creates a new account. 
    /// </summary>
    /// <param name="email">The email of the new user</param>
    /// <param name="password">The password of the new user</param>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response createUser(String email, String password)
    {
        try
        {
            User user = uc.createUser(email, password);
            return new Response("", user);
        }
        catch (Exception e)
        {
            return new Response(e.Message, null);

        }
    }

    /// <summary>
    /// This method logs out a logged in user. 
    /// </summary>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response logout(User u)
    {
        try
        {
            uc.logout(u);
            return new Response("", null);
        }
        catch (Exception e)
        {
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method deletes the current account. 
    /// </summary>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response deleteAccount(string email)
    {
        try
        {
            uc.deleteUser(email);
            return new Response("", null);
        }
        catch (Exception e)
        {
            return new Response(e.Message, null);
        }
    }

}
