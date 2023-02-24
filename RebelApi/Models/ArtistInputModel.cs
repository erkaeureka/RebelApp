using Microsoft.OpenApi.Writers;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ArtistInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Streams { get; set; }
        [Required]
        public double Rate { get; set; }
    }
}
