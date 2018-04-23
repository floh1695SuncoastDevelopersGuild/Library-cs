using Library.Contexts;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Controllers
{
    public class GenreController : ApiController
    {
        public Genre Get(int id)
        {
            Genre genre;
            using (var db = new LibraryContext())
            {
                genre = db.Genres.FirstOrDefault(g => g.ID == id);
            }
            return genre;
        }

        public Genre Post(Genre genre)
        {
            using (var db = new LibraryContext())
            {
                db.Genres.Add(genre);
            }
            return genre;
        }
    }
}
