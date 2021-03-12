using AdelMobileBackEnd.models.absFactoryOfBook.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook.factories
{
    public class PrayerFactory : FactoryOfBook
    {
        public  async override Task<absBook> GetBook()
        {
            return new Prayer("qwe", 5, 43);
        }
    }
}
