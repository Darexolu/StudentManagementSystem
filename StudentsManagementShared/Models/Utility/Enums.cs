using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Utility
{
	public enum Gender

	{   
		Male = 1,
		Female = 2,
		[Display(Name = "Non-binary")]
		NonBinary = 3
	}
	public enum MaritalStatus
	{
		Single = 1,

		Married = 2,

		Divorced = 3,

		Separated = 4,

		Widowed = 5,

		Engaged = 6
	}

	public enum TimeTableType
	{
		Class = 1,
		Exam = 2
	}
	public enum AttendanceStatus
	{
		Present = 1,
		Absent = 2,
		Late = 3,
		Excused = 4
	}
	public enum SchoolTerm
	{
		FirstTerm = 1,
		SecondTerm = 2,
		ThirdTerm = 3
	}
}
