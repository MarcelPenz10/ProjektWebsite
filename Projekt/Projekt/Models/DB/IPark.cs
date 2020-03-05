﻿using System;
using System.Collections.Generic;
using Projekt.Models;

namespace Projekt.Models.DB
{
    public interface IPark
    {
        void Open();
        void Close();
        List<Park> GetAllSnowparks();
        Park GetOneSnowpark(int id);
        bool AddComment(Comments comment);
    }
}
