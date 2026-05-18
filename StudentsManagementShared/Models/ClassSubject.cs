using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class ClassSubject
	{
		public Guid Id { get; set; }

		public Guid? SchoolClassId { get; set; }

		public SchoolClass SchoolClass { get; set; }

		public Guid? SubjectId { get; set; }

		public Subject Subject { get; set; }

		public Guid? TeacherId { get; set; }

		public Teacher Teacher { get; set; }

		public bool Deleted { get; set; }
	}
}
