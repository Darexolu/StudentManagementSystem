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
			_context = context;
		}
		public async Task<SystemSetting> GetAsync()
		{

			 var  settings = await _context.SystemSettings
		.AsNoTracking()
		.FirstOrDefaultAsync();
			return settings;
		}

		public async Task<SystemSetting> SaveAsync(SystemSetting model)
		{
			try
			{
				if (model == null)
					throw new ArgumentNullException(nameof(model));

				var existing = await _context.SystemSettings
					.FirstOrDefaultAsync();

				if (existing == null)
				{
					model.Id = Guid.NewGuid();

					var settings = _context.SystemSettings
						.Add(model)
						.Entity;

					await _context.SaveChangesAsync();

					return settings;
				}

				existing.SchoolName = model.SchoolName;
				existing.SchoolAddress = model.SchoolAddress;
				existing.SchoolPhone = model.SchoolPhone;
				existing.SchoolEmail = model.SchoolEmail;
				existing.SchoolWebsite = model.SchoolWebsite;
				existing.PrincipalName = model.PrincipalName;
				existing.SchoolMotto = model.SchoolMotto;
				existing.CurrentSession = model.CurrentSession;
				existing.CurrentTerm = model.CurrentTerm;
				existing.LogoUrl = model.LogoUrl;
				existing.ReportCardFooter = model.ReportCardFooter;
				existing.ResultSignatureName = model.ResultSignatureName;
				existing.ResultSignatureTitle = model.ResultSignatureTitle;
				existing.ResultPublishingEnabled = model.ResultPublishingEnabled;
				

				await _context.SaveChangesAsync();

				return existing;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"SystemSetting Save Error: {ex}");

				throw;
			}
		}
	}
}