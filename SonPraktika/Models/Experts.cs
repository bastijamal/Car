using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonPraktika.Models
{
    public class Experts
    {

        public int Id { get; set; }


        [MinLength(3)]
        [MaxLength(13)]  
        public string Fullname { get; set; }

        [MinLength(3)]
        [MaxLength(13)]
        public string Description { get; set; }

        public string? PhotoUrl { get; set; }

        [NotMapped]
        public IFormFile ImgFile { get; set; }

    }
}
