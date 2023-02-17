using MetaPhoto.Dtos;
using MetaPhoto.Interfaces;
using MetaPhoto.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MetaPhoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IService<Photo> _photoService;
        public PhotosController(IService<Photo> photoService)
        {
            _photoService = photoService;
        }

        // GET: api/<PhotosController>
        [EnableCors("CorsPolicy")]
        [HttpGet()]
        public IActionResult GetAll(string? title = null, string? albumTitle = null, string? email = null, int? limit = null, int? offset = null)
        {
            List<Photo> photos = _photoService.GetAll().Result;

            PhotoServiceFilter photoServiceFilter = new();
            photos = photoServiceFilter
                .FilterByTitleAlbumAndEmail(photos, title, albumTitle, email)
                .ToList();

            int total = photos.Count;

            PhotoServicePagination photoServicePagination = new(limit, offset);
            photos = photoServicePagination
                .Page(photos)
                .ToList();

            Response.Headers.Add("x-total-count",total.ToString());

            return Ok(photos);
        }

        // GET: api/<PhotosController>/{id}
        [EnableCors("CorsPolicy")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Photo photo = _photoService.Get(id);

            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }
    }
}
