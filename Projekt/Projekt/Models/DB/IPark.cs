using System;
using System.Collections.Generic;
using Projekt.Models.UserScripts;

namespace Projekt.Models.DB
{
    public interface IPark
    {
        void Open();
        void Close();
        List<Park> GetAllSnowparks();
        Park GetOneSnowpark(int id);
        bool AddComment(Comments comment);
        bool DeleteComment(Comments comment);
    }
}