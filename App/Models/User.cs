using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required] public required string Username { get; set; }
		[Required] public required string PasswordHash { get; set; }
		[Required] public required bool IsLoggedIn { get; set; } = false;
		[Required] public required bool IsActive { get; set; } = true;
		[Required] public required DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
