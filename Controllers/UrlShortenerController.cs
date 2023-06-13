using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UrlShortener.Models;
using UrlShortener.Service;
using UrlShortener.Utility;
using UrlShortener.Utility.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlShortenerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string url)
        {
            if (!url.IsValidUrl())
                return BadRequest("Url is Invalid");

            int maxId = await _unitOfWork.UrlShortenerRepository.GetMaxId() + 1;
            var shortUrl = UrlShortenerHelper.Encode(maxId);

            var result = await _unitOfWork.UrlShortenerRepository.AddUrl(new UrlManagement { Url = url, ShortUrl = shortUrl });
            await _unitOfWork.Commit();

            if (!result.isSucceeded)
                return BadRequest("Error has occurred");

            return Ok(result.shortUrl.IsNullOrEmpty() ? shortUrl : result.shortUrl);
        }
        [HttpGet]
        public async Task<IActionResult> RedirectTo(string shortUrl)
        {
            if (shortUrl.IsNullOrEmpty()) return NotFound();
            string longUrl = await _unitOfWork.UrlShortenerRepository.GetLongUrl(shortUrl);
            if (longUrl.IsNullOrEmpty())
                return NotFound("Url Not Found");
            return Redirect(longUrl.Trim());
        }

    }
}
