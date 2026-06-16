using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystemShared.Models;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Repository
{
	public class SettingsRepository : ISystemSettingsRepository
	{
		private readonly ApplicationDbContext _context;
		public SettingsRepository(ApplicationDbContext context)
		{
			this._context = context;
		}
		public async Task<SystemSetting> GetAsync()
		{
			return await _context.SystemSettings
		.AsNoTracking()
		.FirstOrDefaultAsync();
		}

		public async Task<SystemSetting> SaveAsync(SystemSetting model)
		{
			try
			{
				if (model == null)
					throw new ArgumentNullException(nameof(model));

				var existing = await _context.SystemSettings.FirstOrDefaultAsync();

				//if (existing == null)
				//{
				//var newstudent = _context.Students.Add(student).Entity;
				//await _context.SaveChangesAsync();
				//return newstudent;

				//}
				//else
				//{
				//	existing.SchoolName = model.SchoolName;
				//	existing.SchoolAddress = model.SchoolAddress;
				//	existing.SchoolPhone = model.SchoolPhone;
				//	existing.SchoolEmail = model.SchoolEmail;
				//	existing.SchoolWebsite = model.SchoolWebsite;
				//	existing.PrincipalName = model.PrincipalName;
				//	existing.CurrentSession = model.CurrentSession;
				//	existing.CurrentTerm = model.CurrentTerm;
				//	existing.SchoolMotto = model.SchoolMotto;
				//	existing.LogoUrl = model.LogoUrl;
				//	existing.ReportCardFooter = model.ReportCardFooter;
				//	existing.ResultSignatureName = model.ResultSignatureName;
				//	existing.ResultSignatureTitle = model.ResultSignatureTitle;
				//	existing.ResultPublishingEnabled = model.ResultPublishingEnabled;
				//	existing.SchoolLogoUrl = model.SchoolLogoUrl;

				//}
				//model.Id = Guid.NewGuid();
				var settings = _context.SystemSettings.Add(model).Entity;
				await _context.SaveChangesAsync();

				return settings;
			}
			catch (Exception ex)
			{
				// Optional: log here
				Console.WriteLine($"SystemSetting Save Error: {ex.Message}");

				// Re-throw so UI can still handle it properly
				throw;
			}
		}
	}
}