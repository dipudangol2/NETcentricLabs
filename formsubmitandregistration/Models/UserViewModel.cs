using System.ComponentModel.DataAnnotations;

namespace formsubmitandregistration.Models
{
	public class UserViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		public string RePassword { get; set; }

		[Required]
		public string Gender { get; set; }

		public List<string> Courses { get; set; }

		[Required]
		public string Country { get; set; }
	}
}
