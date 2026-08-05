using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Dtos
{
	public class StudentReportCardDto
	{
		public string StudentName { get; set; }
		public string ClassName { get; set; }
		public string Term { get; set; }
		public string Session { get; set; }
		public string? SchoolName { get; set; }
		public string? SchoolAddress { get; set; }
		public string? SchoolPhone { get; set; }

		public string? Department { get; set; }

		public decimal OverallTotal { get; set; }
		public decimal Percentage { get; set; }
		public string? Position { get; set; }
		public int NumberOfStudents { get; set; }

		public string? TeacherRemark { get; set; }
		public string? HeadTeacherRemark { get; set; }
		public List<SubjectResultDto> Subjects { get; set; } = new();
	}

	public class SubjectResultDto
	{
		public string Subject { get; set; }
		public decimal Test1 { get; set; }
		public decimal Test2 { get; set; }
		public decimal Assignment { get; set; }
		public decimal Exam { get; set; }
		public decimal Total { get; set; }
		public string Grade { get; set; }
	}
}
