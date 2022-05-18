using System;
using System.Collections.Generic;
using System.Reflection;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;
using log4net;

public class BoardService
{
    private UserController userController;
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public BoardService(UserService userService)
    { this.userController = userService.userController; }

/// <summary>
    /// This method creates a new board. 
    /// </summary>
    /// <param name="boardName">The name of the new board</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response createBoard(string boardName, string email)
    {
        try
        {
            Board board =  userController.addBoard(boardName, email);
            log.Info("Board: " + boardName + "was add by " + email);
            return new Response("{}", board);
        }
        catch(Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }
    

    /// <summary>
    /// This method removes an existing board. 
    /// </summary>
    /// <param name="id">The id of the board to remove</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response remove(string boardName, string email)
    {
        try
        {
            userController.remove(boardName, email);
            log.Info("Board: " + boardName + "was removed by " + email);
            return new Response("{}", null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method limits a column in a given board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The name of the board</param>
    /// <param name="columnOrdinal">The id of the requested column</param>
    /// <param name="limit">The new limit of the column</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
    public Response limitColumn(string email, string boardName, int columnOrdinal, int limit)
    {
        try
        {
            userController.setColumnLimit(email, boardName, columnOrdinal,limit);
            log.Info("The limit of column " + userController.getColumnName(email, boardName, columnOrdinal) + " in board " + boardName + " was set to " + limit);
            return new Response("{}", null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method returns the limit of a requested column from a given board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The name of the board</param>
    /// <param name="columnOrdinal">The id of the requested column</param>
    /// <returns>The string "{}" and the limit of the column, unless an error occurs</returns>
    public Response getColumnLimit(string email, string boardName, int columnOrdinal)
    {
        try
        {
            int columnLimit = userController.getColumnLimit(email, boardName, columnOrdinal);
            log.Info("The limit of column " + userController.getColumnName(email, boardName, columnOrdinal) + " in board " + boardName + " has been accessed");
            return new Response("{}", columnLimit);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method returns the name of a requested column from a given board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The name of the board</param>
    /// <param name="columnOrdinal">The id of the requested column</param>
    /// <returns>The string "{}" and the column name, unless an error occurs</returns>
    public Response getColumnName(string email, string boardName, int columnOrdinal)
    {
        try
        {
            string columnName = userController.getColumnName(email, boardName, columnOrdinal);
            log.Info("The name of column " + userController.getColumnName(email, boardName, columnOrdinal) + " in board " + boardName + " has been accessed");
            return new Response("{}", columnName);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method returns a requested column from a given board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The name of the board</param>
    /// <param name="columnOrdinal">The id of the requested column</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
    public Response getColumn(string email, string boardName, int columnOrdinal)
    {
        try
        {
            List<Task> column = userController.getColumn(email, boardName, columnOrdinal);
            log.Info("The name of column " + userController.getColumnName(email, boardName, columnOrdinal) + " in board " + boardName + " has been accessed");
            return new Response("{}", column);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method changes the state of task. 
    /// </summary>
    /// <param name="id">The id of the board in which the task is in</param>
    /// <param name="taskTitle">The title of the task of which to change state</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response changeState(string email, string boardName, int columnOrdinal, int taskId)
    {
        try
        {
            userController.changeState(email, boardName, columnOrdinal, taskId);
            log.Info("taks: " + taskId + " was advanced by " + email);
            return new Response("{}", null);

        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

}
