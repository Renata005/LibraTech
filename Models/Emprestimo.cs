using System.ComponentModel.DataAnnotations;

namespace LibraTech.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Livro")]
        public int LivroId { get; set; }

        public Livro? Livro { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [Required]
        [Display(Name = "Data do Empréstimo")]
        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "Data de Devolução")]
        [DataType(DataType.Date)]
        public DateTime DataDevolucao { get; set; }

        [Display(Name = "Situação")]
        public bool Devolvido { get; set; }
    }
}