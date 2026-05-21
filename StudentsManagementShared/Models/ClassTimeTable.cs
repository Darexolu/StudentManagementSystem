using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
		public class ClassTimeTable
		{
			public Guid Id { get; set; }

			[Required]
			public Guid SchoolClassId { get; set; }
			public SchoolClass? SchoolClass { get; set; }

			[Required]
			public Guid SubjectId { get; set; }
			public Subject? Subject { get; set; }

			[Required]
			public Guid TeacherId { get; set; }
			public Teacher? Teacher { get; set; }

			public DayOfWeek? Day { get; set; }

			[Required]
			public TimeSpan StartTime { get; set; }

			[Required]
			public TimeSpan EndTime { get; set; }

			public string? Room { get; set; }
		}
}
