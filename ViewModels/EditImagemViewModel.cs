using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.ViewModels
{
    public class EditImagemViewModel : UploadImagemViewModel
    {
        public int Id { get; set; }
        public string ImagemExistente { get; set; }
    }
}
