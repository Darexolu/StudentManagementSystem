using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class ParentStudent
	{
		[Key]
		public Guid Id { get; set; }

		public Guid ParentId { get; set; }

		public Parent Parent { get; set; }

		public Guid StudentId { get; set; }

		public Student Student { get; set; }

		public string? Relationship { get; set; }
	}
}
