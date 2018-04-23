using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=Library")
        { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CheckOutLedgerEntry> CheckOutLedger { get; set; }
        public DbSet<BookData> BookData { get; set; }
        public DbSet<Reader> Readers { get; set; }
    }
}