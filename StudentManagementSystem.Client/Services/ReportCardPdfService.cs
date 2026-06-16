using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using StudentManagementSystemShared.Dtos;

public class ReportCardPdfService
{
	public byte[] Generate(StudentReportCardDto data)
	{
		try
		{
			//if (data.Subjects == null)
			//	throw new Exception("Subjects list is NULL");

			//if (data.Subjects.Any(x => x == null))
			//	throw new Exception("Subjects list contains NULL item");

			var subjects = data.Subjects ?? new List<SubjectResultDto>();

			return Document.Create(container =>
			{
				container.Page(page =>
				{
					page.Size(PageSizes.A4);
					page.Margin(30);

					// ================= HEADER =================
					page.Header().Column(col =>
					{
						col.Item().Text("SCHOOL REPORT CARD")
							.FontSize(18)
							.Bold()
							.AlignCenter();

						col.Item().PaddingTop(5)
							.Text($"Name: {data.StudentName ?? ""}");

						col.Item().Text($"Class: {data.ClassName ?? ""}");
						col.Item().Text($"Term: {data.Term ?? ""}");
						col.Item().Text($"Session: {data.Session ?? ""}");
					});

					// ================= CONTENT =================
					page.Content().PaddingTop(10).Column(col =>
					{
						col.Item().Table(table =>
						{
							table.ColumnsDefinition(columns =>
							{
								columns.RelativeColumn(3);
								columns.RelativeColumn();
								columns.RelativeColumn();
								columns.RelativeColumn();
								columns.RelativeColumn();
								columns.RelativeColumn();
								columns.RelativeColumn();
							});

							// HEADER ROW
							table.Header(header =>
							{
								header.Cell().Element(CellStyle).Text("Subject").Bold();
								header.Cell().Element(CellStyle).Text("Test1").Bold();
								header.Cell().Element(CellStyle).Text("Test2").Bold();
								header.Cell().Element(CellStyle).Text("Assignment").Bold();
								header.Cell().Element(CellStyle).Text("Exam").Bold();
								header.Cell().Element(CellStyle).Text("Total").Bold();
								header.Cell().Element(CellStyle).Text("Grade").Bold();
							});

							// DATA ROWS
							foreach (var s in subjects ?? new List<SubjectResultDto>())
							{
								var subject = s?.Subject ?? "";
								var test1 = s?.Test1 ?? 0;
								var test2 = s?.Test2 ?? 0;
								var assignment = s?.Assignment ?? 0;
								var exam = s?.Exam ?? 0;
								var total = s?.Total ?? 0;
								var grade = s?.Grade ?? "";

								table.Cell().Element(CellStyle).Text(subject ?? "");
								table.Cell().Element(CellStyle).Text(test1.ToString());
								table.Cell().Element(CellStyle).Text(test2.ToString());
								table.Cell().Element(CellStyle).Text(assignment.ToString());
								table.Cell().Element(CellStyle).Text(exam.ToString());
								table.Cell().Element(CellStyle).Text(total.ToString());
								table.Cell().Element(CellStyle).Text(grade ?? "");
							}

							static IContainer CellStyle(IContainer container)
							{
								return container
									.Border(1)
									.Padding(5)
									.AlignMiddle();
							}
						});

						// ================= FOOTER =================
						col.Item().PaddingTop(20).Column(x =>
						{
							x.Item().Text("Teacher's Comment: _______________________");
							x.Item().PaddingTop(5).Text("Principal's Comment: _______________________");
							x.Item().PaddingTop(10).Text("Powered by Student Management System")
								.FontSize(10)
								.Italic();
						});
					});
				});
			}).GeneratePdf();
		}
		catch (Exception ex)
		{
			// 🔥 THIS WILL SHOW YOU EXACT ERROR IN DEBUG
			throw new Exception("PDF Generation Failed: " + ex.Message, ex);
		}
	}
}