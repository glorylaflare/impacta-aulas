using AulaEntity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulaEntity.Controllers
{
    public class TurmasController : Controller
    {
        public readonly AulaEntityContext _context;

        public TurmasController(AulaEntityContext context)
        {
            _context = context;
        }

        public IActionResult AlunosPorTurma(int id)
        {
            var turma = _context.Grade.Include(g => g.Students).FirstOrDefault(g => g.GradeId == id);
            if (turma == null)
            {
                return NotFound();
            }
            return View(turma);
        }
    }
}
