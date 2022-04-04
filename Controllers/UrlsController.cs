#nullable disable
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.ViewModels;

namespace UrlShortener.Controllers
{
  [Route("v1/[controller]")]
  [ApiController]
  public class UrlsController : ControllerBase
  {
		private readonly AppDbContext _context;
		private readonly IConfiguration _configuration;

		public UrlsController(AppDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		/// <summary>
		///		Search the url to be redirected
		/// </summary>
		///	<param name="code">Website code that has been shortened</param>
		///	<response code="200">Returns the site to be redirected</response>
		/// <response code="204">If there is no code returns without content</response>
		[HttpGet("{code}")]
		public async Task<ActionResult> GetUrls([FromRoute] string code)
		{
			var url = await _context.Urls.FirstOrDefaultAsync(p => p.Code == code);

			if (url == null)
				NoContent();

			return Ok(new
			{
				url = url.Link
			});
		}

		/// <summary>
		///		Add a new site in the shortener
		/// </summary>
		///	<param name="link">data to be saved</param>
		///	<response code="200">Returns if data is saved</response>
		[HttpPost]
		public async Task<ActionResult<Url>> PostUrl([FromBody] GetLinkViewModel link)
		{
			var codeUrl = Guid.NewGuid().ToString().Substring(0, 4);
			var url = new Url
			{
				Link = link.Link,
				Code = codeUrl,
			};

			_context.Urls.Add(url);
			await _context.SaveChangesAsync();

			return Ok(new
			{
				shortened_url = $"{_configuration.GetSection("ApplicationUrl").Value}{codeUrl}"
			});
		}

		/// <summary>
		///		Delete a link
		/// </summary>
		///	<param name="id">Get the id of the page to be deleted</param>
		///	<response code="404">Returns if it doesn't exist</response>
		///	<response code="204">Returns if data is deleted</response>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUrl(int id)
		{
			var url = await _context.Urls.FindAsync(id);
			if (url == null)
				return NotFound();

			_context.Urls.Remove(url);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UrlExists(int id)
		{
			return _context.Urls.Any(e => e.Id == id);
		}
  }
}
