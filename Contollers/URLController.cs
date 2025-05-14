using Microsoft.AspNetCore.Mvc;

using url_shortener_backend.Data;
using url_shortener_backend.Helpers;
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
		int id = Base62.Decode(input);

		var url = _db.URLs.Find(id);
		if (url == null)
		{
			return NotFound();
		}
		return Ok(url);
	}

	[HttpPost]
	public IActionResult Encode([FromBody] URL url)
	{
		_db.URLs.Add(url);
		_db.SaveChanges();

		string encoded = Base62.Encode(url.Id);

		return Created(encoded, url);
	}
}