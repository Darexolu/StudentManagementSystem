using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class ClassSubjectRow
	{
		public Guid SubjectId { get; set; }
		public string SubjectName { get; set; }

		public Guid? TeacherId { get; set; }
		public Guid? ClassSubjectId { get; set; }

		private bool _isSelected;

		public bool IsSelected
		{
			get => TeacherId != null || _isSelected;
			set
			{
				_isSelected = value;

				if (!value)
				{
					TeacherId = null;
					ClassSubjectId = null;
				}
			}
		}
	}
}
