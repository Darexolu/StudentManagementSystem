using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class Subject
	{
		public Guid Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = "";

		[Required]
		[StringLength(20)]
		public string Code { get; set; } = "";

		public bool IsCore { get; set; }

		public bool Deleted { get; set; }
	}
}
