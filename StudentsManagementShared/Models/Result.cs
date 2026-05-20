using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class Result
	{
		public Guid Id { get; set; }

		public Guid StudentId { get; set; }
		public Student Student { get; set; }

		public Guid SubjectId { get; set; }
		public Subject Subject { get; set; }

		public Guid SchoolClassId { get; set; }
		public SchoolClass SchoolClass { get; set; }

		public decimal Test1 { get; set; }
		public decimal Test2 { get; set; }
		public decimal Assignment { get; set; }
		public decimal Exam { get; set; }

		public decimal Total { get; set; }

		public string Grade { get; set; }

		public string? Remark { get; set; }

		public int? Position { get; set; }

		public decimal? ClassAverage { get; set; }

		public decimal? HighestScore { get; set; }

		public decimal? LowestScore { get; set; }

		public string? TeacherRemark { get; set; }

		public string? PrincipalComment { get; set; }

		public string? Term { get; set; }

		public string? Session { get; set; }
	}
}
