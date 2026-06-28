using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraTech.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Autor { get; set; } = string.Empty;

        public int AnoPublicacao { get; set; }

        [Required]
        public string ISBN { get; set; } = string.Empty;

        public string Editora { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public string Sinopse { get; set; } = string.Empty;

        public string? CapaUrl { get; set; }

        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }
}