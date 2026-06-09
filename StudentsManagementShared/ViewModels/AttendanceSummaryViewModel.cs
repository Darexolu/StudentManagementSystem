using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.ViewModels
{
	public class AttendanceSummaryViewModel
	{
		public Guid StudentId { get; set; }

		public string StudentName { get; set; }

		public int PresentDays { get; set; }

		public int AbsentDays { get; set; }

		public int TotalDays { get; set; }

		public double AttendancePercentage { get; set; }
	}
}
