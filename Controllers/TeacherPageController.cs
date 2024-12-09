using Microsoft.AspNetCore.Mvc;

public class TeacherPageController : Controller
{
	private readonly SchoolDbContext _context;

	public TeacherPageController(SchoolDbContext context)
	{
		_context = context;
	}

	public IActionResult New()
	{
		return View();
	}

	public IActionResult DeleteConfirm(int id)
	{
		var teacher = _context.Teachers.Find(id);
		if (teacher == null)
		{
			return NotFound("Teacher not found.");
		}
		return View(teacher);
	}
}

