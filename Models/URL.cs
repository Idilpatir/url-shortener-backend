namespace url_shortener_backend.Models;

public class URL
{
	public int Id { get; set; }
	public required string EncodedURL { get; set; }
}