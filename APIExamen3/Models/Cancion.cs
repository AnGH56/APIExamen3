using System.ComponentModel.DataAnnotations;

namespace APIExamen3.Models
{
    public class Cancion
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Artista { get; set; }
        public string? Genero { get; set; }
        public TimeSpan? Duracion { get; set; }
    }
}
