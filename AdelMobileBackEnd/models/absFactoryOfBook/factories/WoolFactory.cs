﻿using AdelMobileBackEnd.models.absFactoryOfBook.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook.factories
{
    public class WoolFactory : absFactoryOfBook
    {
        public override absBook GetBook(string title, int comments, int likes)
        {
            return new Wool(title, comments, likes);
        }
    }
}
