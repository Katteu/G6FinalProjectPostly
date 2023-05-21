using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace G6FinalProjectPostly.Assets
{
    public class Users
    {
        public static List<Users> UserList = new List<Users>();
        private string userName { get; set; }
        private string userPass { get; set; }
        private string userEmail { get; set; }


        public Users(string userName, string userEmail, string userPass)
        {
            this.userName = userName;
            this.userEmail = userEmail;
            this.userPass = userPass;
        }

        public string Name()
        {
            return userName;
        }

        public string Email()
        {
            return userEmail;
        }

        public string Password()
        {
            return userPass;
        }

        public static void AddToUserList(Users usr)
        {
            UserList.Add(usr);
        }
        public static List<Users> Accounts()
        {
            return UserList;
        }
    }
}
