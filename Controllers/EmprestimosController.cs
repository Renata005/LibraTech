using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraTech.Data;
using LibraTech.Models;

namespace LibraTech.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly AppDbContext _context;

        public EmprestimosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Emprestimos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario);

            return View(await appDbContext.ToListAsync());
        }

        // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public IActionResult Create()
{
    var livrosDisponiveis = _context.Livros
        .Where(l => !_context.Emprestimos
            .Any(e => e.LivroId == l.Id && !e.Devolvido))
        .OrderBy(l => l.Titulo)
        .ToList();

    ViewData["LivroId"] = new SelectList(
        livrosDisponiveis,
        "Id",
        "Titulo");

    ViewData["UsuarioId"] = new SelectList(
        _context.Usuarios.OrderBy(u => u.Nome),
        "Id",
        "Nome");

    return View();
}

        // POST: Emprestimos/Create
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,LivroId,UsuarioId,DataEmprestimo,DataDevolucao,Devolvido")] Emprestimo emprestimo)
{
    if (ModelState.IsValid)
    {
        bool livroEmprestado = _context.Emprestimos.Any(e =>
            e.LivroId == emprestimo.LivroId &&
            !e.Devolvido);

        if (livroEmprestado)
        {
            ModelState.AddModelError("", "Este livro já está emprestado.");

            var livrosDisponiveis = _context.Livros
                .Where(l => !_context.Emprestimos
                    .Any(e => e.LivroId == l.Id && !e.Devolvido))
                .OrderBy(l => l.Titulo)
                .ToList();

            ViewData["LivroId"] = new SelectList(
                livrosDisponiveis,
                "Id",
                "Titulo",
                emprestimo.LivroId);

            ViewData["UsuarioId"] = new SelectList(
                _context.Usuarios.OrderBy(u => u.Nome),
                "Id",
                "Nome",
                emprestimo.UsuarioId);

            return View(emprestimo);
        }

        _context.Add(emprestimo);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    var livros = _context.Livros
        .Where(l => !_context.Emprestimos
            .Any(e => e.LivroId == l.Id && !e.Devolvido))
        .OrderBy(l => l.Titulo)
        .ToList();

    ViewData["LivroId"] = new SelectList(
        livros,
        "Id",
        "Titulo",
        emprestimo.LivroId);

    ViewData["UsuarioId"] = new SelectList(
        _context.Usuarios.OrderBy(u => u.Nome),
        "Id",
        "Nome",
        emprestimo.UsuarioId);

    return View(emprestimo);
}

        // GET: Emprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos.FindAsync(id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            ViewData["LivroId"] = new SelectList(
                _context.Livros.OrderBy(l => l.Titulo),
                "Id",
                "Titulo",
                emprestimo.LivroId);

            ViewData["UsuarioId"] = new SelectList(
                _context.Usuarios.OrderBy(u => u.Nome),
                "Id",
                "Nome",
                emprestimo.UsuarioId);

            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivroId,UsuarioId,DataEmprestimo,DataDevolucao,Devolvido")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["LivroId"] = new SelectList(
                _context.Livros.OrderBy(l => l.Titulo),
                "Id",
                "Titulo",
                emprestimo.LivroId);

            ViewData["UsuarioId"] = new SelectList(
                _context.Usuarios.OrderBy(u => u.Nome),
                "Id",
                "Nome",
                emprestimo.UsuarioId);

            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);

            if (emprestimo != null)
            {
                _context.Emprestimos.Remove(emprestimo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }
    }
}