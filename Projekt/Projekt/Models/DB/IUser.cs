using System;
using System.Collections.Generic;
using Projekt.Models.UserScripts;

namespace Projekt.Models.DB
{
    public interface IUser
    {
        void Open();
        void Close();
    }
}
