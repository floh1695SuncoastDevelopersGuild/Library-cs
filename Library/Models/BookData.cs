using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookData
    {
        public int ID { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        public string Title { get; set; }
        public int YearPublished { get; set; }
        public string ISBN { get; set; }
    }
}