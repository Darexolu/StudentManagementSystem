using StudentManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.Models
{
	public class SystemSetting
	{
		public Guid Id { get; set; }

		public string? SchoolName { get; set; }

		public string? SchoolAddress { get; set; }

		public string? SchoolPhone { get; set; }

		public string? SchoolEmail { get; set; }

		public string? SchoolWebsite { get; set; }

		public string? PrincipalName { get; set; }

		public string? SchoolMotto { get; set; }

		public string CurrentSession { get; set; } =  $"{DateTime.Now.Year}/{DateTime.Now.Year + 1}";

		public SchoolTerm CurrentTerm { get; set; }
		= SchoolTerm.FirstTerm;

		public string? ReportCardFooter { get; set; }

		public string? LogoUrl { get; set; }

		public string? ResultSignatureName { get; set; }

		public string? ResultSignatureTitle { get; set; }
		
		public bool? ResultPublishingEnabled { get; set; }

		public DateTime? DateCreated { get; set; }
		

		
	}
}
