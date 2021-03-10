using AdelMobileBackEnd.models.absFactoryOfBook.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook
{
    public abstract class absFactoryOfBook
    {
        public abstract absBook GetBook(string title, int comments, int likes);
    }
}
