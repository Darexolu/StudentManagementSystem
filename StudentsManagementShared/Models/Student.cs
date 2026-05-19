
using StudentManagementSystem.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystemShared.Models
{
    public class Student
    {
        
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

		public Gender? Gender { get; set; }


		public string EmailAddress { get; set; }
        
        public  string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
       
        public  string Country { get; set; }

        public DateTime DOB { get; set; }


      
    }
    
}
