using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class ParentStudentSelection
	{
		public Guid StudentId { get; set; }

		public string StudentName { get; set; } = "";

		public string AdmissionNumber { get; set; } = "";

		public string Relationship { get; set; } = "";
	}
}
