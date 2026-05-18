using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
    public class Teacher
    {
       public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

		public string? Gender { get; set; }
		public string? OtherGender { get; set; }

		public string? MaritalStatus { get; set; }
		public string? OtherMaritalStatus { get; set; }

		public string? Designation { get; set; }
		public string? OtherDesignation { get; set; }

		public string PhoneNumber { get; set; }
        public string Address { get; set; }

       
        public DateTime DOB {  get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        
        
    }

}
