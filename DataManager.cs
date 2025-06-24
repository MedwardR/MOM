using MOM.Models;

namespace MOM
{
	public class DataManager(AppDbContext db, User user)
	{
		public AppDbContext DbContext { get; } = db;
		public User AuthenticatedUser { get; } = user;
	}
}
