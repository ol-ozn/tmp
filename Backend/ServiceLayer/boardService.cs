using System;

public interface boardService
{
    /// <summary>
    /// This method creates a new board. 
    /// </summary>
    /// <param name="boardName">The name of the new board</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String add(string boardName);

    /// <summary>
    /// This method removes an existing board. 
    /// </summary>
    /// <param name="boardName">The name of the board to remove</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String remove(string boardName);

    /// <summary>
    /// This method changes the state of task. 
    /// </summary>
    /// <param name="boardName">The name of the board in which the task is in</param>
    /// <param name="taskTitle">The title of the task of which to change state</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String changeState(string boardName, string taskTitle);

    /// <summary>
    /// This method changes the attributes of a task. 
    /// </summary>
    /// <param name="boardName">The name of the board in which the task is in</param>
    /// <param name="taskTitle">The title of the task to be changed</param>
    /// <param name="text">The new text to be inserted</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String editTask(string boardName, string taskTitle, string text);

}
