using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class User
	{
		public User()
		{
			IsLoggedIn = false;
			IsActive = true;
			CreatedAt = DateTime.Now;
		}

		public int Id { get; set; }

		[Required] public required string Username { get; set; }
		[Required] public required string PasswordHash { get; set; }
		public required bool IsLoggedIn { get; set; }
		public required bool IsActive { get; set; }
		public required DateTime CreatedAt { get; set; }
	}
}
