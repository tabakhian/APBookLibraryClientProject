using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject
{
	public static class Hashing
	{
		public static string GetMD5(string value)
		{
			if (value == null)
			{
				return (string.Empty);
			}

			value = value.Trim();
			if (value == string.Empty)
			{
				return (string.Empty);
			}

			try
			{
				System.Security.Cryptography.MD5 oHash =
					System.Security.Cryptography.MD5.Create();

				byte[] bytInputs =
					System.Text.Encoding.ASCII.GetBytes(value);

				byte[] bytHashes = oHash.ComputeHash(bytInputs);

				// Convert the byte array to hexadecimal string
				System.Text.StringBuilder oStringBuilder =
					new System.Text.StringBuilder();

				for (int intIndex = 0; intIndex < bytHashes.Length; intIndex++)
				{
					oStringBuilder.Append(bytHashes[intIndex].ToString("X2"));

					// To force the hex string to lower-case letters instead of
					// upper-case, use he following line instead:
					// sb.Append(hashBytes[i].ToString("x2")); 
				}

				return (oStringBuilder.ToString());

				//return (System.Web.Security.FormsAuthentication
				//	.HashPasswordForStoringInConfigFile(value, "MD5"));
			}
			catch
			{
				return (string.Empty);
			}
		}

		public static string GetSha1(string value)
		{
			if (value == null)
			{
				return (string.Empty);
			}

			value = value.Trim();
			if (value == string.Empty)
			{
				return (string.Empty);
			}

			try
			{
				System.Security.Cryptography.SHA1 oHash =
					System.Security.Cryptography.SHA1.Create();

				byte[] bytInputs =
					System.Text.Encoding.ASCII.GetBytes(value);

				byte[] bytHashes = oHash.ComputeHash(bytInputs);

				// Convert the byte array to hexadecimal string
				System.Text.StringBuilder oStringBuilder =
					new System.Text.StringBuilder();

				for (int intIndex = 0; intIndex < bytHashes.Length; intIndex++)
				{
					oStringBuilder.Append(bytHashes[intIndex].ToString("X2"));

					// To force the hex string to lower-case letters instead of
					// upper-case, use he following line instead:
					// sb.Append(hashBytes[i].ToString("x2")); 
				}

				return (oStringBuilder.ToString());

				//return (System.Web.Security.FormsAuthentication
				//	.HashPasswordForStoringInConfigFile(value, "SHA1"));
			}
			catch
			{
				return (string.Empty);
			}
		}

		public static string GetSha256(string value)
		{
			if (value == null)
			{
				return (string.Empty);
			}

			value = value.Trim();
			if (value == string.Empty)
			{
				return (string.Empty);
			}

			try
			{
				System.Security.Cryptography.SHA256 oHash =
					System.Security.Cryptography.SHA256.Create();

				byte[] bytInputs =
					System.Text.Encoding.ASCII.GetBytes(value);

				byte[] bytHashes = oHash.ComputeHash(bytInputs);

				// Convert the byte array to hexadecimal string
				System.Text.StringBuilder oStringBuilder =
					new System.Text.StringBuilder();

				for (int intIndex = 0; intIndex < bytHashes.Length; intIndex++)
				{
					oStringBuilder.Append(bytHashes[intIndex].ToString("X2"));

					// To force the hex string to lower-case letters instead of
					// upper-case, use he following line instead:
					// sb.Append(hashBytes[i].ToString("x2")); 
				}

				return (oStringBuilder.ToString());

				//return (System.Web.Security.FormsAuthentication
				//	.HashPasswordForStoringInConfigFile(value, "SHA1"));
			}
			catch
			{
				return (string.Empty);
			}
		}

		public static string GetSha512(string value)
		{
			if (value == null)
			{
				return (string.Empty);
			}

			value = value.Trim();
			if (value == string.Empty)
			{
				return (string.Empty);
			}

			try
			{
				System.Security.Cryptography.SHA512 oHash =
					System.Security.Cryptography.SHA512.Create();

				byte[] bytInputs =
					System.Text.Encoding.ASCII.GetBytes(value);

				byte[] bytHashes = oHash.ComputeHash(bytInputs);

				// Convert the byte array to hexadecimal string
				System.Text.StringBuilder oStringBuilder =
					new System.Text.StringBuilder();

				for (int intIndex = 0; intIndex < bytHashes.Length; intIndex++)
				{
					oStringBuilder.Append(bytHashes[intIndex].ToString("X2"));

					// To force the hex string to lower-case letters instead of
					// upper-case, use he following line instead:
					// sb.Append(hashBytes[i].ToString("x2")); 
				}

				return (oStringBuilder.ToString());

				//return (System.Web.Security.FormsAuthentication
				//	.HashPasswordForStoringInConfigFile(value, "SHA1"));
			}
			catch
			{
				return (string.Empty);
			}
		}

		private static System.IO.FileStream GetFileStream(string pathName)
		{
			return (new System.IO.FileStream(pathName, System.IO.FileMode.Open,
					  System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
		}

		public static string GetMD5ByPathName(string pathName)
		{
			string strResult = string.Empty;

			System.Security.Cryptography.MD5CryptoServiceProvider oMD5CryptoServiceProvider =
				new System.Security.Cryptography.MD5CryptoServiceProvider();

			System.IO.FileStream oFileStream = null;

			try
			{
				oFileStream = GetFileStream(pathName);

				byte[] bytHashValues =
					oMD5CryptoServiceProvider.ComputeHash(oFileStream);

				strResult =
					System.BitConverter.ToString(bytHashValues)
					.Replace("-", string.Empty);
			}
			catch { }
			finally
			{
				if (oFileStream != null)
				{
					//oFileStream.Close();
					oFileStream.Dispose();
					oFileStream = null;
				}
			}

			return (strResult);
		}

		public static string GetSha1ByPathName(string pathName)
		{
			string strResult = string.Empty;

			System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1CryptoServiceProvider =
				new System.Security.Cryptography.SHA1CryptoServiceProvider();

			System.IO.FileStream oFileStream = null;

			try
			{
				oFileStream = GetFileStream(pathName);

				byte[] bytHashValues =
					oSHA1CryptoServiceProvider.ComputeHash(oFileStream);

				strResult =
					System.BitConverter.ToString(bytHashValues)
					.Replace("-", string.Empty);
			}
			catch { }
			finally
			{
				if (oFileStream != null)
				{
					//oFileStream.Close();
					oFileStream.Dispose();
					oFileStream = null;
				}
			}

			return (strResult);
		}

		public static string GetSha256ByPathName(string file)
		{
			using (FileStream stream = File.OpenRead(file))
			{
				var sha = new SHA256Managed();
				byte[] checksum = sha.ComputeHash(stream);
				return BitConverter.ToString(checksum).Replace("-", String.Empty);
			}
		}

		public static string GetSha256ByStreamBuffered(Stream stream)
		{
			BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 32);
			var sha = new SHA256Managed();
			byte[] checksum = sha.ComputeHash(bufferedStream);
			stream.Seek(0, SeekOrigin.Begin);
			return BitConverter.ToString(checksum).Replace("-", String.Empty);
		}

	}
}
