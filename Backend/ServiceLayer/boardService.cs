using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;
using log4net;

public class BoardService
{
    private UserController userController;
    private BoardController boardController;
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    public BoardService(ServiceFactory serviceFactory)
    {
        userController = serviceFactory.UserController;
        boardController = serviceFactory.BoardController;
    }

    /// <summary>
    /// This method creates a new board. 
    /// </summary>
    /// <param name="boardName">The name of the new board</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response createBoard(string boardName, string email)
    {
        try
        {
            Board board = boardController.addBoard(boardName, email);
            log.Info("Board: " + boardName + "was add by " + email);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }


    /// <summary>
    /// This method removes an existing board. 
    /// </summary>
    /// <param name="boardName">The name of the board to remove</param>
    /// <param name="email">The user that owns the board</param>
    /// <returns>The string "{}", unless an error occurs</returns>
    public Response remove(string boardName, string email)
    {
        try
        {
            boardController.removeBoard(boardName, email);
            log.Info("Board: " + boardName + "was removed by " + email);
            return new Response(null, null);
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
            boardController.setColumnLimit(email, boardName, columnOrdinal, limit);
            log.Info("The limit of column " + boardController.getColumnName(email, boardName, columnOrdinal) +
                     " in board " + boardName + " was set to " + limit);
            return new Response(null, null);
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
            int columnLimit = boardController.getColumnLimit(email, boardName, columnOrdinal);
            log.Info("The limit of column " + boardController.getColumnName(email, boardName, columnOrdinal) +
                     " in board " + boardName + " has been accessed");
            return new Response(null, columnLimit);
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
            string columnName = boardController.getColumnName(email, boardName, columnOrdinal);
            log.Info("The name of column " + boardController.getColumnName(email, boardName, columnOrdinal) +
                     " in board " + boardName + " has been accessed");
            return new Response(null, columnName);
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
            List<Task> column = boardController.getColumn(email, boardName, columnOrdinal);
            log.Info("The name of column " + boardController.getColumnName(email, boardName, columnOrdinal) +
                     " in board " + boardName + " has been accessed");
            return new Response(null, column);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }



    public Response joinBoard(string email, int id)
    {
        try
        {
            boardController.joinBoard(email, id);
            log.Info("user: " + email + " joined board: " + id);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    public Response transferOwnerShip(string currentOwnerEmail, string newOwnerEmail, string boardName)
    {
        try
        {
            boardController.transferOwnerShip(currentOwnerEmail, newOwnerEmail, boardName);
            log.Info("user: " + currentOwnerEmail + " transfered: " + boardName + " to user: " + newOwnerEmail);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    public Response leaveBoard(string email, int boardId)
    {
        try
        {
            boardController.leaveBoard(email, boardId);
            log.Info("user: " + email + " left board: " + boardId);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    public Response removeBoard(string email, string name)
    {
        try
        {
            boardController.removeBoard(email, name);
            log.Info("user: " + email + " deleted board: " + name);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }
}