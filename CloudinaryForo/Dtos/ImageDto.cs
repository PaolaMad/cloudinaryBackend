using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CloudinaryForo.Dtos
{
    public class ImageDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

    }
}
