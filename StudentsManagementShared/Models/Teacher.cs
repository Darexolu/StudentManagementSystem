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
       public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public int GenderId { get; set; }

        public SystemCodeDetail Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

       public int MaritalStatusId { get; set; }
        public SystemCodeDetail MaritalStatus { get; set; }
        public DateTime DOB {  get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
        public int DesignationId { get; set; }
        public SystemCodeDetail Designation { get; set; }
        
    }

}
