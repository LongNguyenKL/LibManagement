
using LibManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibManagement.Data

{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

            //    // Define many-to-many relationships if needed
            //    modelBuilder.Entity<BorrowedBook>()
            //        .HasKey(bb => new { bb.BorrowId });

            //    modelBuilder.Entity<BorrowedBook>()
            //        .HasOne(bb => bb.Book)
            //        .WithMany(b => b.BorrowedBooks)
            //        .HasForeignKey(bb => bb.BookId);

            //    modelBuilder.Entity<BorrowedBook>()
            //        .HasOne(bb => bb.Member)
            //        .WithMany(m => m.BorrowedBooks)
            //        .HasForeignKey(bb => bb.MemberId);
            //}
        }
    }
