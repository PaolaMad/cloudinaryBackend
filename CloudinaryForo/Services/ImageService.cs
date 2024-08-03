using AutoMapper;
using CloudinaryForo.Database;
using CloudinaryForo.Dtos;
using CloudinaryForo.Entities;
using CloudinaryForo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloudinaryForo.Services
{
    public class ImageService : IImageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly HttpContext _httpContext;

        public ImageService(AppDbContext context, IHttpContextAccessor httpContextAccesor, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContextAccesor.HttpContext;
        }

        public async Task<ResponseDto<List<ImageDto>>> GetImagesAsync()
        {
            
            var imageEntity = await _context.Images.ToListAsync();

            var imageDto = _mapper.Map<List<ImageDto>>(imageEntity);

            return new ResponseDto<List<ImageDto>>
            {

                Status = true,
                StatusCode = 200,
                Message = "Imagenes Obtenidas con éxito",
                Data = imageDto

            };

        }

        public async Task<ResponseDto<ImageDto>> UploadImageAsync(UploadImageDto model)
        {

            var imageEntity = _mapper.Map<ImageEntity>(model);

            _context.Images.Add(imageEntity);

            await _context.SaveChangesAsync();

            var imageDto = _mapper.Map<ImageDto>(imageEntity);

            return new ResponseDto<ImageDto>
            {
                Status = true,
                StatusCode = 200,
                Message = "Imagen Subida con éxito",
                Data = imageDto
            };

        }

    }
}
