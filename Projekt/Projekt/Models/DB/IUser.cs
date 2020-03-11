using System;
using System.Collections.Generic;
using Projekt.Models.UserScripts;

namespace Projekt.Models.DB
{
    public interface IUser
    {
        void Open();
        void Close();
        bool Insert(User u);
        User Login(User u);
        bool Delete(int UserId);

        List<User> GetAllUser();
        bool UpdateUserData(int UserId, User newUserData);
        User GetUser(int UserId);
    }
}
