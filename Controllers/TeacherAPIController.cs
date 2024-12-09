using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TeacherAPIController : ControllerBase
{
	private readonly SchoolDbContext _context;

	public TeacherAPIController(SchoolDbContext context)
	{
		_context = context;
	}

	[HttpPost("AddTeacher")]
	public IActionResult AddTeacher([FromBody] Teacher teacher)
	{
		if (string.IsNullOrWhiteSpace(teacher.Name) || teacher.HireDate > DateTime.Now ||
			!teacher.EmployeeNumber.StartsWith("T") || _context.Teachers.Any(t => t.EmployeeNumber == teacher.EmployeeNumber))
		{
			return BadRequest("Invalid teacher data.");
		}

		_context.Teachers.Add(teacher);
		_context.SaveChanges();
		return Ok("Teacher added successfully.");
	}

	[HttpDelete("DeleteTeacher/{id}")]
	public IActionResult DeleteTeacher(int id)
	{
		var teacher = _context.Teachers.Find(id);
		if (teacher == null)
		{
			return NotFound("Teacher not found.");
		}

		_context.Teachers.Remove(teacher);
		_context.SaveChanges();
		return Ok("Teacher deleted successfully.");
	}
}

