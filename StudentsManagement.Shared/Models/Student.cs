using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsManagement.Shared.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RegistrationNo { get; set; }

        [Required]
        [StringLength(100)]  // Giới hạn độ dài tối đa cho tên
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        [Required]
        [EmailAddress]  // Đảm bảo đây là một địa chỉ email hợp lệ
        public string EmailAddress { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]  // Kiểm tra định dạng số điện thoại
        public string PhoneNumber { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public int GenderId { get; set; }

        public SystemCodeDetail Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }  // Ngày sinh
    }
}
