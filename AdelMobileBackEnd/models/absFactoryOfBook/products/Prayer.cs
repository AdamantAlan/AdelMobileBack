﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook.products
{
    public class Prayer:absBook
    {
        public Prayer(string title, int comments, int likes) : base(title, comments, likes)
        {
            Title = title;
            Comments = comments;
            Likes = likes;
        }
    }
}
