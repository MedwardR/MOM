using MOM.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class User : AuditableEntity
	{
		public int Id { get; set; }

		[Required] public required string Username { get; set; }
		[Required] public required string PasswordHash { get; set; }
		public bool IsLoggedIn { get; set; }

		public User()
		{
			IsLoggedIn = false;
		}
	}
}
