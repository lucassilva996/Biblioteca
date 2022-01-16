using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Microsoft.AspNetCore.Hosting;
using Biblioteca.ViewModels;
using System.IO;

namespace Biblioteca.Controllers
{
    public class LivrosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public LivrosController(AppDbContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;
            webHostEnvironment = HostEnvironment;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);

            var livroViewModel = new LivroViewModel()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Descricao = livro.Descricao,
                Editora = livro.Editora,
                AnoPublicacao = livro.AnoPublicacao,
                DataEmprestimo = livro.DataEmprestimo,
                HoraEmprestimo = livro.HoraEmprestimo,
                ImagemExistente = livro.Foto
            };

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }


        // GET: Livros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivroViewModel model)
        {
            if (ModelState.IsValid)
            {
                string nomeDaImagem = ProcessaUploadedFile(model);

                Livro livro = new Livro
                {
                    Id = model.Id,
                    Titulo = model.Titulo,
                    Descricao = model.Descricao,
                    Editora = model.Editora,
                    AnoPublicacao = model.AnoPublicacao,
                    DataEmprestimo = model.DataEmprestimo,
                    HoraEmprestimo = model.HoraEmprestimo,
                    Foto = nomeDaImagem
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        private string ProcessaUploadedFile(LivroViewModel model)
        {
            string nomeDaImagem = null;

            if (model.LivroFoto != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                nomeDaImagem = Guid.NewGuid().ToString() + "_" + model.LivroFoto.FileName;
                string filePath = Path.Combine(uploadsFolder, nomeDaImagem);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.LivroFoto.CopyTo(fileStream);
                }
            }
            return nomeDaImagem;
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);

            var livroViewModel = new LivroViewModel()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Descricao = livro.Descricao,
                Editora = livro.Editora,
                AnoPublicacao = livro.AnoPublicacao,
                DataEmprestimo = livro.DataEmprestimo,
                HoraEmprestimo = livro.HoraEmprestimo,
                ImagemExistente = livro.Foto
            };

            if (livro == null)
            {
                return NotFound();
            }
            return View(livroViewModel);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LivroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var livro = await _context.Livros.FindAsync(model.Id);

                    livro.Id = model.Id;
                    livro.Titulo = model.Titulo;
                    livro.Descricao = model.Descricao;
                    livro.Editora = model.Editora;
                    livro.AnoPublicacao = model.AnoPublicacao;
                    livro.DataEmprestimo = model.DataEmprestimo;
                    livro.HoraEmprestimo = model.HoraEmprestimo;

                    if (model.LivroFoto != null)
                    {
                        if (model.ImagemExistente != null)
                        {
                            string pathFile = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", model.ImagemExistente);
                            System.IO.File.Delete(pathFile);
                        }
                        livro.Foto = ProcessaUploadedFile(model);
                    }

                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .FirstOrDefaultAsync(m => m.Id == id);

            var livroViewModel = new LivroViewModel()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Descricao = livro.Descricao,
                Editora = livro.Editora,
                AnoPublicacao = livro.AnoPublicacao,
                DataEmprestimo = livro.DataEmprestimo,
                HoraEmprestimo = livro.HoraEmprestimo,
                ImagemExistente = livro.Foto
            };

            if (livro == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            var currentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", livro.Foto);

            _context.Livros.Remove(livro);

            if(await _context.SaveChangesAsync() > 0)
            {
                if(System.IO.File.Exists(currentImage))
                {
                    System.IO.File.Delete(currentImage);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
