using System;
using System.Reflection;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;
using log4net;

public class BoardService
{
    public BoardController bc;
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public BoardService()
    { bc = new BoardController(); }

/// <summary>
    /// This method creates a new board. 
    /// </summary>
    /// <param name="boardName">The name of the new board</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response createBoard(String boardName, User user)
    {
        try
        {
            Board board =  bc.addBoard(boardName, user);
            log.Debug("Board: " + boardName + "was add by " + user.email);
            return new Response("", board);
        }
        catch(Exception e)
        {
            return new Response(e.Message, null);
        }
    }
    

    /// <summary>
    /// This method removes an existing board. 
    /// </summary>
    /// <param name="id">The id of the board to remove</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response remove(string boardName, User user)
    {
        try
        {
            bc.remove(boardName, user);
            log.Debug("Board: " + boardName + "was removed by " + user.email);
            return new Response("", null);
        }
        catch (Exception e)
        {
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method changes the state of task. 
    /// </summary>
    /// <param name="id">The id of the board in which the task is in</param>
    /// <param name="taskTitle">The title of the task of which to change state</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response changeState(Task task, User user)
    {
        try
        {
            bc.changeState(task,user);
            log.Debug("taks: " + task.getTitle() + "was advanced by " + user.email);
            return new Response("", null);

        }
        catch (Exception e)
        {
            return new Response(e.Message, null);
        }
    }

}
