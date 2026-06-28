using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraTech.Models;
using LibraTech.Data;
using LibraTech.ViewModels;

namespace LibraTech.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(
        ILogger<HomeController> logger,
        AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        DashboardViewModel dashboard = new DashboardViewModel
        {
            TotalLivros = _context.Livros.Count(),

            TotalUsuarios = _context.Usuarios.Count(),

            EmprestimosAtivos = _context.Emprestimos.Count(e => !e.Devolvido),

            LivrosDisponiveis =
                _context.Livros.Count()
                -
                _context.Emprestimos.Count(e => !e.Devolvido)
        };

        return View(dashboard);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]

    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ??
            HttpContext.TraceIdentifier
        });
    }
}