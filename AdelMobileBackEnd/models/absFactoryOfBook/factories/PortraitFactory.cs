using AdelMobileBackEnd.models.absFactoryOfBook.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook.factories
{
    public class PortraitFactory : absFactoryOfBook
    {
        public override absBook GetBook(string title, int comments, int likes)
        {
            return new Portrait(title,comments,likes);
        }
    }
}
