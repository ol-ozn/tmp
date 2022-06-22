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
    /// <param name="boardName">The boardName of the new board</param>
    /// <param name="email">The email of the user</param>
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
    /// This method limits a column in a given board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The boardName of the board</param>
    /// <param name="columnOrdinal">The boardId of the requested column</param>
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
    /// <param name="boardName">The boardName of the board</param>
    /// <param name="columnOrdinal">The boardId of the requested column</param>
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
    /// This method returns the boardName of a requested column from a given board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The boardName of the board</param>
    /// <param name="columnOrdinal">The boardId of the requested column</param>
    /// <returns>The string "{}" and the column boardName, unless an error occurs</returns>
    public Response getColumnName(string email, string boardName, int columnOrdinal)
    {
        try
        {
            string columnName = boardController.getColumnName(email, boardName, columnOrdinal);
            log.Info("The boardName of column " + boardController.getColumnName(email, boardName, columnOrdinal) +
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
    /// <param name="boardName">The boardName of the board</param>
    /// <param name="columnOrdinal">The boardId of the requested column</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
    public Response getColumn(string email, string boardName, int columnOrdinal)
    {
        try
        {
            List<Task> column = boardController.getColumn(email, boardName, columnOrdinal);
            log.Info("The boardName of column " + boardController.getColumnName(email, boardName, columnOrdinal) +
                     " in board " + boardName + " has been accessed");
            return new Response(null, column);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }


    /// <summary>
    /// This method lets a user join a board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardId">The board's id</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
    public Response joinBoard(string email, int boardId)
    {
        try
        {
            boardController.joinBoard(email, boardId);
            log.Info("user: " + email + " joined board: " + boardId);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method transfers ownership of a given board. 
    /// </summary>
    /// <param name="currentOwnerEmail">The email of the current owner</param>
    /// <param name="newOwnerEmail">The email of the new owner</param>
    /// <param name="boardName">The boardName of the board</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
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

    /// <summary>
    /// This method lets a user leave a board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardId">The id of the board</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
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

    /// <summary>
    /// This method removes a board. 
    /// </summary>
    /// <param name="email">The email of the user</param>
    /// <param name="boardName">The boardName of the board</param>
    /// <returns>The string "{}" and the column, unless an error occurs</returns>
    public Response removeBoard(string email, string boardName)
    {
        try
        {
            boardController.removeBoard(boardName, email);
            log.Info("user: " + email + " deleted board: " + boardName);
            return new Response(null, null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method removes a board. 
    /// </summary>
    /// <param name="boardId">The the id of the board</param>
    /// <returns>The name of the board, unless an error occurs</returns>
    public Response getBoardName(int boardId)
    {
        try
        {
            string boardName = boardController.getBoardName(boardId);
            log.Info("returned board boardName = " + boardName);
            return new Response(null, boardName);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }
}