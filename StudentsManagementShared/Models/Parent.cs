using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagementSystemShared.Models
{
    public class Parent
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

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int ParentTypeId { get; set; }

        public SystemCodeDetail ParentType { get; set; }

        public DateTime DOB { get; set; }
    }
}
