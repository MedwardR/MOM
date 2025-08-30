using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace MOM.Helpers
{
	internal class SecurityHelper
	{
		public static async Task<byte[]> HashPasswordAsync(string password, byte[] salt)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			var argon2 = new Argon2id(bytes)
			{
				Salt = salt,
				DegreeOfParallelism = 2,
				MemorySize = 65536,
				Iterations = 4
			};
			return await argon2.GetBytesAsync(32);
		}

		public static async Task<bool> VerifyPasswordAsync(string password, byte[] hash, byte[] salt)
		{
			byte[] attempt = await HashPasswordAsync(password, salt);
			return CryptographicOperations.FixedTimeEquals(attempt, hash);
		}

		public static byte[] GenerateSalt()
		{
			return RandomNumberGenerator.GetBytes(16);
		}

		public static string Encode(byte[] salt, byte[] hash)
		{
			return Convert.ToBase64String([.. salt, .. hash]);
		}

		public static (byte[] Salt, byte[] Hash) Decode(string encoded)
		{
			byte[] bytes = Convert.FromBase64String(encoded);
			byte[] salt = bytes[..16];
			byte[] hash = bytes[16..];
			return (salt, hash);
		}

		public static string Encrypt(string? secret)
		{
			if (secret is not null)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(secret);
				byte[] encrypted = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
				return Convert.ToBase64String(encrypted);
			}
			else return string.Empty;
		}

		public static string Decrypt(string? encrypted)
		{
			if (encrypted is not null)
			{
				byte[] bytes = Convert.FromBase64String(encrypted);
				byte[] decrypted = ProtectedData.Unprotect(bytes, null, DataProtectionScope.CurrentUser);
				return Encoding.UTF8.GetString(decrypted);
			}
			else return string.Empty;
		}
	}
}
