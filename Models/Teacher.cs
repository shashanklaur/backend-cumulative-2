using System.ComponentModel.DataAnnotations;

public class Teacher
{
	public int TeacherId { get; set; }

	[Required]
	public string Name { get; set; }

	[Required]
	public DateTime HireDate { get; set; }

	[Required]
	public string EmployeeNumber { get; set; }
}

