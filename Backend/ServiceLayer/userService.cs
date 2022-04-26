using System;

public interface userService
{

    /// <summary>
    ///  This method logs in an existing user.
    /// </summary>
    /// <param name="email">The email address of the user to login</param>
    /// <param name="password">The password of the user to login</param>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public String login(String email, String password);

    /// <summary>
    /// This method creates a new account. 
    /// </summary>
    /// <param name="email">The email of the new user</param>
    /// <param name="password">The password of the new user</param>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public String createUser(String email, String password);

    /// <summary>
    /// This method logs out a logged in user. 
    /// </summary>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public String logout();

    /// <summary>
    /// This method deletes the current account. 
    /// </summary>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public String deleteAccount();

}
