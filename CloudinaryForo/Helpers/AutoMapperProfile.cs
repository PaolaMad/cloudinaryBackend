using AutoMapper;
using CloudinaryForo.Dtos;
using CloudinaryForo.Entities;

namespace CloudinaryForo.Helpers
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() { 
        
            CreateMap<ImageEntity, ImageDto>();
            CreateMap<UploadImageDto, ImageEntity>();

        }

    }
}
