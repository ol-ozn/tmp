using System;

public interface userService
{

    /// <summary>
    ///  This method logs in an existing user.
    /// </summary>
    /// <param name="email">The email address of the user to login</param>
    /// <param name="password">The password of the user to login</param>
    /// <returns>Response with user email, unless an error occurs</returns>
    public String login(string email, string password);
    
    /// <summary>
    /// This method creates a new account. 
    /// </summary>
    /// <param name="email">The email of the new user</param>
    /// <param name="password">The password of the new user</param>
    /// <returns>The string "{}", unless an error occurs</returns>
	public String createUser(string email, string password);

    /// <summary>
    /// This method logs out a logged in user. 
    /// </summary>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String logout();

    /// <summary>
    /// This method deletes the current account. 
    /// </summary>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String deleteAccount();

}
