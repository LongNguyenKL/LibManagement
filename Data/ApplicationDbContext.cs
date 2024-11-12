
using LibManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibManagement.Data

{
    public class ApplicationDbContext : DbContext

    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowedBook>()
                .HasOne(b => b.Book)
                .WithMany(b => b.BorrowedBooks)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(b => b.Member)
                .WithMany(m => m.BorrowedBooks)
                .HasForeignKey(b => b.MemberId);

            base.OnModelCreating(modelBuilder);
        }
    }
}