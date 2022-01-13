using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Editora")]
        public int Editora { get; set; }

        [Required]
        [StringLength(10)]
        public string AnoPublicacao { get; set; }

        [Required]
        [StringLength(300)]
        public string Foto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DataEmprestimo")]
        public DateTime DataEmprestimo { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "HoraEmprestimo")]
        public DateTime HoraEmprestimo { get; set; }

        
    }
}
