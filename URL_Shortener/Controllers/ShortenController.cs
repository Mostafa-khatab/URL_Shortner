using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URL_Shortener.Entity;
using URL_Shortener.Models;
using URL_Shortener.Services;

namespace URL_Shortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        private readonly UrlShorteningServices _urlShorteningServices;

        public ShortenController(AppDbContext dbContext, UrlShorteningServices urlShorteningServices)
        {
            _dbContext = dbContext;
            _urlShorteningServices = urlShorteningServices;
        }

        [HttpPost]
        public async Task<IActionResult> Shorten(RequestDto request)
        {
            if(!Uri.TryCreate(request.Url,UriKind.Absolute, out _))
            {
                return BadRequest("This Url is invalid");
            }

            var exist = await _dbContext.ShortenedUrls.FirstOrDefaultAsync(u => u.LongUrl ==  request.Url);

            if (exist != null)
            {
                return Ok(exist.ShortUrl);
            }
          
            var code = await _urlShorteningServices.GenerateShortUrl(request.Url);
            var shorten = new ShortenedUrl {
                Id = Guid.NewGuid(),
                Code = code,
                LongUrl = request.Url,
                CreatedOnUtc = DateTime.UtcNow,
                ShortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/Shorten?code={code}"
            };

            await _dbContext.AddAsync(shorten);
            await _dbContext.SaveChangesAsync();
            return Ok(shorten.ShortUrl);
            
        }

        [HttpGet]
        public async Task<IActionResult> RedirectUrl(string code)
        {
            var shorten = await _dbContext.ShortenedUrls.FirstOrDefaultAsync(c => c.Code == code);

            if(shorten == null)
            {
                return NotFound();
            }

            return Redirect(shorten.LongUrl);
        }
    }
}
