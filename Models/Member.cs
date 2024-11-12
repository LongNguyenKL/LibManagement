using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibManagement.Models
{

    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int Contact { get; set; }
 
        public int NumberOfBooksBorrowed { get; set; }

        // Navigation property for borrowed books
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }

}