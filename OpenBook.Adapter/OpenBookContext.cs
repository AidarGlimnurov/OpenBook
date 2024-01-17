using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter
{
    public class OpenBookContext : DbContext
    {
        public OpenBookContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<BookBasket> BookBaskets{ get; set; }
        public DbSet<BookGenre> BookGenres{ get; set; }
        public DbSet<Chapter> Chapters{ get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<EmailVerif> EmailVerifs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
