using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class BulkResultEntry
	{
		public Guid StudentId { get; set; }

		public string StudentName { get; set; }

		public decimal Test1 { get; set; }

		public decimal Test2 { get; set; }

		public decimal Assignment { get; set; }

		public decimal Exam { get; set; }
	}
}
