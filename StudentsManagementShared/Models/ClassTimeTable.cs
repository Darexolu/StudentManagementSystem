using StudentManagementSystem.Utility;
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

			public Guid? SubjectId { get; set; }
			public Subject? Subject { get; set; }
		
			public Guid? TeacherId { get; set; }
			public Teacher? Teacher { get; set; }

			public DayOfWeek? Day { get; set; }
		
			public TimeSpan? StartTime { get; set; }

			public TimeSpan? EndTime { get; set; }
			public string? Room { get; set; }
	    	public int PeriodNumber { get; set; }
		    public TimeTableType TimeTableType { get; set; }

	}
}
