namespace url_shortener_backend.Helpers;

public static class Base62
{
	private const string AllowedChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	public static string Encode(int number)
	{
		string encoded = string.Empty;
		while (number > 0)
		{
			encoded = AllowedChars[number % 62] + encoded;
			number /= 62;
		}
		return encoded;
	}

	public static int Decode(string encoded)
	{
		int number = 0;
		for (int i = 0; i < encoded.Length; i++)
		{
			number *= 62;
			number += AllowedChars.IndexOf(encoded[i]);
		}
		return number;
	}
}