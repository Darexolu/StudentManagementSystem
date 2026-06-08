using StudentManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class StudentAttendance
	{
		public Guid Id { get; set; }

		public Guid StudentId { get; set; }
		public Student? Student { get; set; }

		public Guid SchoolClassId { get; set; }
		public SchoolClass? SchoolClass { get; set; }

		public DateTime AttendanceDate { get; set; }

		public AttendanceStatus Status { get; set; }

		public string? Remarks { get; set; }
	}
}
