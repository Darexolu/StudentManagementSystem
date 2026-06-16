using StudentManagementSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemShared.StudentRepository
{
	public interface ISystemSettingsRepository
	{
		Task<SystemSetting> GetAsync();

		Task<SystemSetting> SaveAsync(SystemSetting model);
	}
}
