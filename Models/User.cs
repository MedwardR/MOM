using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public required string Username { get; set; }

		[Required]
		public required string PasswordHash { get; set; }

		[Required]
		public bool IsLoggedIn { get; set; } = false;

		[Required]
		public bool IsActive { get; set; } = true;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
