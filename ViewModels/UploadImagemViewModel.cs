using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.ViewModels
{
    public class UploadImagemViewModel
    {
        [Required]
        [Display(Name = "Foto")]
        public IFormFile PalestranteFoto { get; set; }
    }
}
