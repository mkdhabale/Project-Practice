using BookStore.API.Helpers.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSotre.API.Data
{
    public class BookStoreContext: IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
        {

        }


        public DbSet<Books> Books { get; set; }

        //migrated to startup file options
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=Mukul_DND;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
