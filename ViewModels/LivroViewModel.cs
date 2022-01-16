using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.ViewModels
{
    public class LivroViewModel : EditImagemViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Titulo do Livro")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Editora")]
        public string Editora { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Ano de Publicação")]
        public string AnoPublicacao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Emprestimo")]
        public DateTime DataEmprestimo { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Emprestimo")]
        public DateTime HoraEmprestimo { get; set; }
    }
}
