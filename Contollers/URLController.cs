using Microsoft.AspNetCore.Mvc;

using url_shortener_backend.Data;
using url_shortener_backend.Models;

namespace url_shortener_backend.Contollers;

[Route("/")]
public class URLController : Controller
{
	private readonly AppDbContext _db;

	public URLController(AppDbContext db)
	{
		_db = db;
	}

	
	[HttpGet("{input}")]
	public IActionResult Get(string input)
	{
		int id = int.Parse(input);

		var url = _db.URLs.Find(id);
		if (url == null)
		{
			return NotFound();
		}
		return Redirect(url.EncodedURL);
	}

	[HttpPost]
	public IActionResult Encode([FromBody] URL url)
	{
		_db.URLs.Add(url);
		_db.SaveChanges();
		return Ok(url);
	}
}