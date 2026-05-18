using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class SchoolClass
	{
		public Guid Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = "";

		[Required]
		[StringLength(50)]
		public string Level { get; set; } = "";

		
		[StringLength(10)]
		public string Arm { get; set; } = "";

		public bool Deleted { get; set; }
	}
}
