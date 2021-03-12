using AdelMobileBackEnd.models.absFactoryOfBook.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook.factories
{
    public class PortraitFactory : FactoryOfBook
    {
        public async override Task<absBook> GetBook()
        {
            return new Portrait("5",2,1);
        }
    }
}
