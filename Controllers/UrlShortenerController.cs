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
        public IActionResult Create(string url)
        {
            if (!url.IsValidUrl())
                return BadRequest("Url is Invalid");
            var urlManagement = new UrlManagement { Url = url };
            urlManagement.ShortUrl = UrlShortenerHelper.Encode(urlManagement.Id);
            _unitOfWork.UrlShortenerRepository.Add(urlManagement);
            return Ok(urlManagement.ShortUrl);
        }
    }
}
