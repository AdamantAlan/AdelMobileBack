using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models.absFactoryOfBook.products
{
    abstract public class absBook
    {
        internal string Title { get; set; }
        internal int Comments { get; set; }
        internal int Likes { get; set; }

        public absBook(string title, int comments, int likes)
        {
            Title = title;
            Comments = comments;
            Likes = likes;
        }
    }
}
