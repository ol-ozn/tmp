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

        public UserController()
        {
            users = new Dictionary<string, User>();
            usersIdCount = 0;
        }

        /// <summary>
        ///  This method creates a new user.
        /// </summary>
        /// <param name="email">The email address of the new user</param>
        /// <param name="password">The password of the new user</param>
        /// <returns>User object of the new user, unless an error occurs</returns>
        public User createUser(string email, string password)
        {
            //check if user with given email already exist
            if (userExists(email))
                throw new Exception("User with email: " + email + " already exists.");
            

            //check email validity
            if (!emailValidity(email))
                throw new Exception("Invalid email: " + email);
            

            //check password validity
            if (!passwordValidity(password))
                throw new Exception("Invalid password. Length should be between 6 to 20 characters, and should contain at least one Uppercase letter, one Lowercase letter and one number.");
            

            //if all the criteria above met- create new User object
            User newUser = new User(email, password, usersIdCount);
            usersIdCount++;
            users.Add(email, newUser);
            newUser.setIsLoggedIn(true); //setting automatically the user is logged in

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
            bool regexValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

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
            if (!userExists(email))
                throw new Exception("Attempt to log in to account with email: " + email + " that doesn't exist!");

            if (!users[email].isPassword(password))
                throw new Exception("Attempt to log in to " + email + " with wrong password!");

            if (isLoggedIn(email))
                throw new Exception("User already logged in"); //TODO: check with the guys about this one

            users[email].setIsLoggedIn(true);

            return users[email];
        }

        /// <summary>
        ///  This method checks existence of a user.
        /// </summary>
        /// <param name="email">The email to check existence of a user with</param>
        /// <returns>True if user exists, false otherwise</returns>
        private bool userExists(string email) { return users.ContainsKey(email); }

        /// <summary>
        ///  This method deletes an existing user.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>User object of logged in user, unless an error occurs</returns>
        public void deleteUser(string email)
        {
            if (!userExists(email))
                throw new Exception("Attempt to delete an account with an email that doesn't exist.");
            
            users.Remove(email); //TODO: check, should we delete all of the boards and tasks??
        }

        /// <summary>
        ///  This method checks if an account is logged in.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>True if the user is logged in, false otherwise</returns>
        public bool isLoggedIn(string email) //function in order to have access from the outside
        {
            if (!userExists(email))
                throw new Exception("An account with that email doesn't even exist!");
            return users[email].getIsLoggedIn();
        }

        /// <summary>
        ///  This method logs out of a logged in user.
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns></returns>
        public void logout(string email)
        {
            if(!userExists(email))
                throw new Exception("An account with that email doesn't even exist!");
            if (isLoggedIn(email))
                users[email].setIsLoggedIn(false);
            else
            {
                throw new Exception("already logged out.");
            }
        }

        public int getColumnLimit(string email, string boardName, int columnId)
        {
            if (!(users[email]).getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }

            User user = users[email];
            Board bord = user.hasBoardByName(boardName);
            return bord.getcolumLimit(columnId);
            
        }

        public string getColumnName(string email, string boardName, int columnId)
        {
            if (!(users[email]).getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }
            User user = users[email];
            Board bord = user.hasBoardByName(boardName);
            return bord.getcolumname(columnId);

        }
        public void setColumnLimit(string email, string boardName, int columnId, int limit)
        {
            if (!(users[email]).getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }

            if (limit < -1)
            {
                throw new Exception("invalid column limit");
            }

            User user = users[email];
            Board bord = user.hasBoardByName(boardName);
            bord.setcolumLimit(columnId, limit);
        }

        public List<Task> getColumn(string email, string boardName, int columnId)
        {
            if (!(users[email]).getIsLoggedIn())
            {
                throw new Exception("User isn't logged in");
            }

            if (columnId < 0 || columnId > 2)
            {
                throw new Exception("invalid columnId");
            }
            User user = users[email];
            Board bord = user.hasBoardByName(boardName);
            return bord.getColumn(columnId);
        }
    }
}