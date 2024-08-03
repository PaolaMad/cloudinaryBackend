using CloudinaryForo.Dtos;

namespace CloudinaryForo.Services.Interfaces
{
    public interface IImageService
    {
        Task<ResponseDto<List<ImageDto>>> GetImagesAsync();
        Task<ResponseDto<ImageDto>> UploadImageAsync(UploadImageDto model);
    }
}
