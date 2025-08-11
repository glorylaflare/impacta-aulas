using ClinicaApp.Data;
using ClinicaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Controllers;

public class ClientesController : Controller
{
    // Campo privado para armazenar o contexto do BD
    // Tudo que eu quiser mexer com o BD eu chamo o Context
    private readonly ClinicaContext _context;

    public ClientesController(ClinicaContext context)
    {
        _context = context;
    }

    // Adicionar um retorno de Task transforma o método em assíncrono 
    public async Task<IActionResult> Index()
    {
        return View(await _context.Clientes.ToListAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _context.Clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nome = c.Nome,
                DataNascimento = c.DataNascimento
            }).ToListAsync();

        return Json(clientes);
    }

    // Método: GET
    public IActionResult Create()
    {
        return View();
    }

    // Método : POST
    // Ação que recebe os dados do formulário e os salva no banco
    [HttpPost] // Este atributo especifica que a ação responde apenas a requisições POST
    [ValidateAntiForgeryToken] // Atributo de segurança para previnir ataques de CSRF
    public async Task<IActionResult> Create([Bind("Nome","DataNascimento","Salario")]Cliente cliente)
    {
        _context.Clientes.Add(cliente); // Adiciona o cliente ao contexto do banco de dados
        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        return RedirectToAction(nameof(Index)); // Redireciona para a lista de clientes
    }

    // Método : GET
    public async Task<IActionResult> Edit(int id) 
    {
        if (id == null) return NotFound();
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return NotFound();

        return View(cliente);
    }

    // Método : POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Salario")] Cliente cliente)
    {
        if (id != cliente.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cliente);
    }

    // Método : GET
    public async Task<IActionResult> Delete(int id)
    {
        if (id == null) return NotFound();
        var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        if (cliente == null) return NotFound();

        return View(cliente);
    }

    // Método : DELETE
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null) _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Método auxiliar para verificar se um cliente existe
    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(c => c.Id == id);
    }
}
