using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CloudinaryForo.Dtos
{
    public class UploadImageDto
    {

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "La {0} es requerida")]
        [StringLength(maximumLength: 100,
            MinimumLength = 5,
            ErrorMessage = "La {0} debe tener entre {2} a {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Base64")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Base64 { get; set; }

    }
}
