using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Shared.Models
{
    public class BookIssuance : UserCreateActivity
    {
        public int Id { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int ClassId { get; set; }
        public SystemCodeDetail Class {  get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Notes { get; set; }

    }
}
