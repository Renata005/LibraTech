using System.ComponentModel.DataAnnotations;

namespace LibraTech.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;
    }
}