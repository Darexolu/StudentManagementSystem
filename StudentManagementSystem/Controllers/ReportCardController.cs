using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Client.Services;
using StudentManagementSystemShared.StudentRepository;

namespace StudentManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportCardController : ControllerBase
	{
		private readonly IResultRepository _repo;
		private readonly ReportCardPdfService _pdfService;
		private readonly AppSettingsService _appSettings;

		public ReportCardController(
			IResultRepository repo,
			ReportCardPdfService pdfService,
			AppSettingsService appSettings)
		{
			_repo = repo;
			_pdfService = pdfService;
			_appSettings = appSettings;
		}

		[HttpGet("report-card/{studentId}")]
		public async Task<IActionResult> Generate(
			Guid studentId,
			string term,
			string session)
		{
			var data = await _repo.GetStudentReportCardAsync(
				studentId,
				term,
				session);

			if (data == null)
				return NotFound("No result found.");

			var pdf = _pdfService.Generate(
				data,
				_appSettings.Settings?.SchoolName,
				_appSettings.Settings?.SchoolAddress);

			return File(
				pdf,
				"application/pdf",
				"ReportCard.pdf");
		}
	}
}