using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log4net;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class UserController
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private Dictionary<string, User> users;

        public UserController()
        {
            users = new Dictionary<string, User>();
        }
        public User createUser(string email, string password)
        {
            if (userExists(email))
            {
                log.Debug("Attempted to create a user that already exists.");
                throw new Exception("User with this email already exists.");
            }

            //check email
            if (!emailValidity(email))
            {
                log.Debug("Attempt to create a user is with invalid email");
                throw new Exception("Invalid email.");
            }

            //check password
            if (!passwordValidity(password))
            {
                log.Debug("Attempt to create a user is with invalid password");
                throw new Exception(
                    "Invalid password. Length should be between 6 to 20 characters, and should contain at least one Uppercase letter, one Lowercase letter and one number.");
            }

            //if both ok- create new User obj
            User newUser = new User(email, password, 0); //TODO: when implemented id counter, change.
            users.Add(email,newUser);
            log.Debug("User with email " + email + " was created successfully");
            newUser.setIsLoggedIn(true);

            return newUser;
        }

        private bool passwordValidity(string password)
        {
            bool upperCap = false;
            bool lowerCap = false;
            bool num = false;

            if(password == null || (password.Length < 6 | password.Length > 20))
                return false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    upperCap = true;
                if (char.IsLower(c))
                    lowerCap = true;
                if(char.IsNumber(c))
                    num = true;
            }
            
            return upperCap && lowerCap && num;
        }

        private bool emailValidity(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            //regex for valid email
            bool regexValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            return regexValid;
        }

        public User login(string email, string password)
        {
            User u = null;
            //check email exist
            if (userExists(email)) // if user doesn't exist- userExists() throws exception 
                u = users[email];
            //check correct password -> inside user (so no data leak) + flag logged in
            u.login(password); //u is never null at this point
            //log for login happens inside of u.login
            return u;
        }

        private bool userExists(string email)
        {
            if(users.ContainsKey(email))
                return true;

            log.Debug("Attempted log with "+ email + " which doesn't exist");
            throw new Exception("User with given email does not exist");
        }

        public void deleteUser(string email)
        {
            if (userExists(email))
            {
                users.Remove(email);
                log.Debug("Account with email: " + email + " was deleted.");
            }
        }

        public void logout(User u)
        {
            if(u.getIsLoggedIn())
                u.setIsLoggedIn(false);
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

        public void setColumnLinit(string email, string boardName, int columnId, int limit)
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
