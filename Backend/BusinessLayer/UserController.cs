using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class UserController
    {
        private Dictionary<string, User> users;

        private int usersIdCount;
        // private int boardIdCOunter;

        public UserController()
        {
            users = new Dictionary<string, User>();
            usersIdCount = 0;
            // boardIdCOunter = 0;
            //get data into users
            //users = (convert the list of users <userDTO> to be list of users <User>)
        }


        /// <summary>
        ///  This method creates a new user.
        /// </summary>
        /// <param name="email">The email address of the new user</param>
        /// <param name="password">The password of the new user</param>
        /// <returns>User object of the new user, unless an error occurs</returns>
        public User createUser(string email, string password)
        {
            if (!emailValidity(email))
            {
                throw new Exception(email + " is invalid");
            }
            // email = email.ToLower(); //todo: inspect this
            //check if user with given email already exist
            if (userExists(email))
                throw new Exception("User with email: " + email + " already exists.");

            //check password validity
            if (!passwordValidity(password))
                throw new Exception(
                    "Invalid password. Length should be between 6 to 20 characters, and should contain at least one Uppercase letter, one Lowercase letter and one number.");

            //if all the criteria above met- create new User object
            User newUser = new User(email, password, usersIdCount);
            usersIdCount++;
            users.Add(email, newUser);
            newUser.IsLoggedIn = true; //setting automatically the user is logged in

            return newUser;
        }

        /// <summary>
        ///  This method checks validity of a password.
        /// </summary>
        /// <param name="password">The password to check its' validity</param>
        /// <returns>True if the password is valid, false otherwise</returns>
        private bool passwordValidity(string password)
        {
            bool upperCap = false;
            bool lowerCap = false;
            bool num = false;

            if (password == null || (password.Length < 6 | password.Length > 20))
                return false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    upperCap = true;
                if (char.IsLower(c))
                    lowerCap = true;
                if (char.IsNumber(c))
                    num = true;
            }

            return upperCap && lowerCap && num;
        }

        /// <summary>
        ///  This method checks validity of an email.
        /// </summary>
        /// <param name="email">The email to check its' validity</param>
        /// <returns>True if the email is valid, false otherwise</returns>
        private bool emailValidity(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            //regex for valid email
            bool regexValid = Regex.IsMatch(email, @"^\w+([.-]?\w+)@\w+([.-]?\w+)(.\w{2,3})+$");

            return regexValid;
        }

        /// <summary>
        ///  This method logs in an existing user.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>User object of logged in user, unless an error occurs</returns>
        public User login(string email, string password)
        {
            if (!emailValidity(email))
            {
                throw new Exception(email + " is invalid");
            }
            // email = email.ToLower();
            if (!userExists(email))
                throw new Exception("Attempt to log in to account with email: " + email + " that doesn't exist!");

            User user = users[email];

            if (!user.isPassword(password))
                throw new Exception("Attempt to log in to " + email + " with wrong password!");

            if (user.IsLoggedIn)
                throw new Exception("User already logged in"); //TODO: check with the guys about this one

            user.IsLoggedIn = true;

            return user;
        }

        /// <summary>
        ///  This method checks existence of a user.
        /// </summary>
        /// <param name="email">The email to check existence of a user with</param>
        /// <returns>True if user exists, false otherwise</returns>
        private bool userExists(string email)
        {
            return users.ContainsKey(email);
        }

        /// <summary>
        ///  This method deletes an existing user.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>User object of logged in user, unless an error occurs</returns>
        public void deleteUser(string email)
        {
            if (!userExists(email))
                throw new Exception("Attempt to delete an account with an email that doesn't exist.");

            users.Remove(email);
        }

        /// <summary>
        ///  This method checks if an account is logged in.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>True if the user is logged in, false otherwise</returns>
        public void isLoggedIn(string email) //function in order to have access from the outside
        {
            if (!userExists(email))
                throw new Exception("An account with " + email + " doesn't even exist!");
            if (!users[email].IsLoggedIn)
            {
                throw new Exception(email + " isn't Logged in");
            }
        }

        /// <summary>
        ///  This method logs out of a logged in user.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns></returns>
        public void logout(string email)
        {
            if (!emailValidity(email))
            {
                throw new Exception(email + " is invalid");
            }
            // email = email.ToLower();
            isLoggedIn(email);
            users[email].IsLoggedIn = false;
        }


        /// <summary>
        ///  This method returns the column limit of a given column in a given board.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnId">The id of the column</param>
        /// <returns>Limit of the given column</returns>
        public int getColumnLimit(string email, string boardName, int columnId)
        {
            User user = getUserAndLogeddin(email); //check if exists and if logged in is in getUser

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }

            Board board = user.hasBoardByName(boardName);
            return board.getColumnLimit(columnId);
        }


        /// <summary>
        ///  This method returns the column name of a given column in a given board.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnId">The id of the column</param>
        /// <returns>Name of the given column</returns>
        public string getColumnName(string email, string boardName, int columnId)
        {
            User user = getUserAndLogeddin(email); //check if exists and if logged in is in getUser

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }

            Board bord = user.hasBoardByName(boardName);
            return bord.getColumnName(columnId);
        }


        /// <summary>
        ///  This method sets the column limit of a given column in a given board.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnId">The id of the column</param>
        /// <param name="limit">The wanted limit for the column</param>
        /// <returns></returns>
        public void setColumnLimit(string email, string boardName, int columnId, int limit)
        {
            User user = getUserAndLogeddin(email); //check if exists and if logged in is in getUser

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }

            if (limit < -1)
            {
                throw new Exception("invalid column limit");
            }

            Board bord = user.hasBoardByName(boardName);
            bord.setColumnLimit(columnId, limit);
        }


        /// <summary>
        ///  This method returns a column from a board.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <param name="columnId">The id of the column</param>
        /// <returns>List of tasks representing the column</returns>
        public List<Task> getColumn(string email, string boardName, int columnId)
        {
            User user = getUserAndLogeddin(email); //check if exists and if logged in is in getUser

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }

            Board board = user.hasBoardByName(boardName);
            return board.getColumn(columnId);
        }

        /// <summary>
        ///  This method returns a user.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>User</returns>
        public User getUserAndLogeddin(string email)
        {
            isLoggedIn(email);
            return users[email];
        }

        public User getUser(string email)
        {
            if (!userExists(email))
                throw new Exception("An account with " + email + " doesn't even exist!");
            return users[email];
        }


        // moved to boradController
        // /// <summary>
        // ///  This method adds a board to a user.
        // /// </summary>
        // /// <param name="email">The email of the user</param>
        // /// <param name="boardName">The name of the board</param>
        // /// <returns>The created Board</returns>
        // public Board addBoard(string boardName, string email)
        // {
        //     if (string.IsNullOrWhiteSpace(boardName))
        //     {
        //         throw new Exception("board name is not valid");
        //     }
        //
        //     User user = getUser(email);
        //
        //     if (!user.getIsLoggedIn())
        //     {
        //         throw new Exception("User with email " + email + " isn't logged in");
        //     }
        //
        //     Dictionary<string, Board> userBoardsbyName = user.getBoardListByName();
        //     Dictionary<int, Board> userBoardsbyId = user.getBoardListById();
        //
        //     if (userBoardsbyName.ContainsKey(boardName)) // check if user has baord with given name
        //     {
        //         throw new Exception("A board named " + boardName + " already exist");
        //     }
        //
        //     int futureID = boardIdCOunter; //TODO: add counter for id 
        //     Board toAdd = new Board(boardName, futureID);
        //     userBoardsbyName.Add(boardName, toAdd); // add nre board to user board list
        //     userBoardsbyId.Add(futureID, toAdd);
        //     boardIdCOunter++;
        //     return toAdd;
        // }

        /// <summary>
        ///  This method sets the removes a board from users' boards.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="boardName">The name of the board</param>
        /// <returns></returns>
        ///
        /// 
        // public void remove(string boardName, string email)
        // {
        //     User user = getUser(email);
        //     if (!user.getIsLoggedIn())
        //     {
        //         throw new Exception("User isn't logged in");
        //     }
        //
        //
        //     Dictionary<string, Board> userBoardsbyName = user.getBoardListByName();
        //     Dictionary<int, Board> userBoardsbyId = user.getBoardListById();
        //     if (userBoardsbyName.ContainsKey(boardName))
        //     {
        //         int boardId = userBoardsbyName[boardName].getID();
        //         userBoardsbyName.Remove(boardName); //board has been removed from userBoardByName
        //         userBoardsbyId.Remove(boardId); // board has been removed from the userBoardById
        //     }
        //     else
        //     {
        //         throw new Exception("Try to remove a board with the name " + boardName +
        //                             " which doesn't exist to the email: " + email);
        //     }
        // }


        // /// <summary>
        // ///  This method changes the state of a task.
        // /// </summary>
        // /// <param name="email">The email of the user</param>
        // /// <param name="boardName">The name of the board</param>
        // /// <param name="columnOrdinal">The id of the column</param>
        // /// <param name="taskId">The id of the task to advance</param>
        // /// <returns></returns>
        // public void changeState(string email, string boardName, int columnOrdinal, int taskId)
        // {
        //     User user = getUserAndLogeddin(email); //user is logged in
        //     bool found = false;
        //     
        //     Board board = user.hasBoardByName(boardName);
        //     List<Task> tasksList = board.getColumn(columnOrdinal);
        //     Dictionary<string, Board> userBoards = user.getBoardListByName();
        //     if (tasksList.Count == 0)
        //     {
        //         throw new Exception("Tried to find a task in an empty list");
        //     }
        //
        //     foreach (Task task in tasksList)
        //     {
        //         if (task.Id == taskId)
        //         {
        //             if (columnOrdinal < 2) //advance task to in progress
        //             {
        //                 if (board.isColumnFull(columnOrdinal + 1)) //check column limit
        //                 {
        //                     throw new Exception("column overflow");
        //                 }
        //
        //                 if (task.Assignie !=
        //                     email) // in case the user who's trying to progress the task isn't the asignee 
        //                 {
        //                     throw new Exception("user: " + email + " tried to progress task:" + taskId +
        //                                         "which he is not assigned to");
        //                 }
        //
        //                 board.getColumn(columnOrdinal).Remove(task); //remove task from given column ordinal
        //                 board.getColumn(columnOrdinal + 1).Add(task); //advances task to the next column ordinal
        //                 found = true;
        //                 break;
        //             }
        //
        //             else
        //             {
        //                 throw new Exception("Try do advance from done \n");
        //             }
        //         }
        //     }
        //
        //     if (!found)
        //     {
        //         throw new Exception("task wasn't found in this column");
        //     }
        // }
    }
}