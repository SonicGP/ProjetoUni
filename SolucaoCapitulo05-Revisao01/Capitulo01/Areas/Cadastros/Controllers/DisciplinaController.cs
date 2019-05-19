using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capitulo01.Data;
using Modelo.Cadastros;
using Capitulo01.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Authorization;

namespace Capitulo01.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class DisciplinaController : Controller
    {
        private readonly IESContext _context;
        private readonly DisciplinaDAL disciplinaDAL;

        public DisciplinaController(IESContext context)
        {
            _context = context;
            disciplinaDAL = new DisciplinaDAL(context);
        }

        //GET: Disciplina
        public async Task<IActionResult> Index()
        {
            return View(await disciplinaDAL.ObterDiciplinaClassificadoPorNome().ToListAsync());
        }

        //GET: Disciplina/Detales
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoDisciplinaPorId(id);
        }

        //GET: Disciplina/Crear
        public IActionResult Create()
        {
            return View();
        }

        //POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplinaID,Nome")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                await disciplinaDAL.GravarDiciplina(disciplina);
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        //GET: Disciplina/Edite
        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoDisciplinaPorId(id);
        }

        //POST: Disciplina/Edite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id,[Bind("DisciplinaID,Nome")] Disciplina disciplina)
        {
            if(id != disciplina.DisciplinaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await disciplinaDAL.GravarDiciplina(disciplina);
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(! await DisciplinaExists(disciplina.DisciplinaID))
                    {
                        return NotFound();
                    }
                    else { throw; }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(disciplina);
        }

        //GET: Disciplina/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoDisciplinaPorId(id);
        }

        //POST: Disciplina/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var disciplina = await disciplinaDAL.ElilminarDiciplinaPorId((long)id);
            TempData["Message"] = "Disciplina " + disciplina.Nome.ToUpper() + " foi removida";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DisciplinaExists(long? id)
        {
            return await disciplinaDAL.ObterDiciplinaPorId((long)id) != null;
        }

        private async Task<IActionResult> ObterVisaoDisciplinaPorId(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var disciplina = await disciplinaDAL.ObterDiciplinaPorId((long)id);
            if(disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }
    }
}