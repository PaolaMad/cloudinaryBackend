using CloudinaryForo.Dtos;
using CloudinaryForo.Entities;
using CloudinaryForo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CloudinaryForo.Database;

namespace CloudinaryForo.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly AppDbContext _context;

        public ImagesController(IImageService imageService, AppDbContext context)
        {
            _imageService = imageService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ImageDto>>> GetImages()
        {

            var imageResponse = await _imageService.GetImagesAsync();

            return StatusCode(imageResponse.StatusCode, imageResponse);

        }

        [HttpPost]
        public async Task<ImageEntity> UploadImage([FromBody] UploadImageDto model)
        {

            var image = new ImageEntity() { Name = model.Name };

            image.Url = await Upload(model.Base64);

            await _context.Images.AddAsync(image);

            await _context.SaveChangesAsync();

            return image;

        }

        private async Task<string> Upload(string base64)
        {

            var cloudinary = new Cloudinary(new Account("dgjufgonw", "525876776395843", "2Sj20ukTLtYV9J8Tkzz_k106rcM"));

            cloudinary.Api.Secure = true;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), new MemoryStream(Convert.FromBase64String(base64)))
            };

            var response = await cloudinary.UploadAsync(uploadParams);

            return response.SecureUrl.AbsoluteUri;

        }

    }
}
