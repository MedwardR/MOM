using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Security.Authentication;

namespace MOM.Services;

public class AppContextFactory : IDbContextFactory<AppContext>, IDesignTimeDbContextFactory<AppContext>
{
	public User? AuthenticatedUser { get; private set; }
	public UserSettings UserSettings { get; private set; }

	public AppContextFactory()
	{
		UserSettings = UserSettings.Load();
	}

	public AppContextFactory(UserSettings settings)
	{
		UserSettings = settings;
	}

	public AppContext CreateAnonymousContext() => new(UserSettings);

	public AppContext CreateDbContext()
	{
		if (AuthenticatedUser is not null)
		{
			var context = new AppContext(UserSettings);
			context.AssignAuthenticatedUser(AuthenticatedUser);
			return context;
		}
		else throw new AuthenticationException("No authorized user has been provided");
	}

	public AppContext CreateDbContext(string[] args) => CreateAnonymousContext();

	public void AssignAuthenticatedUser(User user)
	{
		if (AuthenticatedUser is null)
		{
			AuthenticatedUser = user;
		}
		else throw new InvalidOperationException("An authenticated user is already assigned");
	}
}
