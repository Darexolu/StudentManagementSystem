﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystemShared.Models
{
    public class Student
    {
        
        [Key]
        public int StudentId { get; set; }
       
        public string FirstName { get; set; }
       
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public string EmailAddress { get; set; }
        
        public  string Address { get; set; }
       
        public string PhoneNumber { get; set; }
       
        public  string Country { get; set; }

       
        public int GenderId { get; set; }
        public SystemCodeDetail Gender { get; set; }
        public DateTime DOB { get; set; }


      
    }
    
}
