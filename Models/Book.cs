using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibManagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        public int PublishedYear { get; set; }

        [Range(0, 5)]
        public decimal Rating { get; set; }

        // Navigation property for borrowed books
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }

}


