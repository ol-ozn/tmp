using System;

public class BoardService
{
    public BoardService() { }
    /// <summary>
    /// This method creates a new board. 
    /// </summary>
    /// <param name="boardName">The name of the new board</param>
    /// <returns>The string "{}", unless an error occurs</returns>


    public String createBoard(String boardName)
    {
        throw new NotImplementedException();
    }
    

    /// <summary>
    /// This method removes an existing board. 
    /// </summary>
    /// <param name="id">The id of the board to remove</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String remove(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This method changes the state of task. 
    /// </summary>
    /// <param name="id">The id of the board in which the task is in</param>
    /// <param name="taskTitle">The title of the task of which to change state</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public String changeState(int id, String taskTitle)
    {
        throw new NotImplementedException();
    }

}
