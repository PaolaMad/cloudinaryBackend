using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudinaryForo.Entities
{

    [Table("images", Schema = "upload")]

    public class ImageEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("url")]
        [Required]
        public string Url { get; set; }

    }
}
