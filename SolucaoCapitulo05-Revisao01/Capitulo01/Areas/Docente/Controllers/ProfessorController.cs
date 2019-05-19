using Capitulo01.Areas.Docente.Models;
using Capitulo01.Data;
using Capitulo01.Data.DAL.Cadastros;
using Capitulo01.Data.DAL.Docente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelo.Cadastros;
using Modelo.Docente;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Capitulo01.Areas.Docente.Controllers
{
    [Area("Docente")]
    public class ProfessorController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;
        private readonly DepartamentoDAL departamentoDAL;
        private readonly CursoDAL cursoDAL;
        private readonly ProfessorDAL professorDAL;
        private readonly CursoProfessorDAL cursoProfessorDAL;

        public ProfessorController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
            cursoDAL = new CursoDAL(context);
            professorDAL = new ProfessorDAL(context);
            cursoProfessorDAL = new CursoProfessorDAL(context);
        }

        public void PrepararViewBags(List<Instituicao> instituicoes, List<Departamento> departamentos, List<Curso> cursos, List<Professor> professores)
        {
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a instituição" });
            ViewBag.Instituicoes = instituicoes;

            departamentos.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o departamento" });
            ViewBag.Departamentos = departamentos;

            cursos.Insert(0, new Curso() { CursoID = 0, Nome = "Selecione o curso" });
            ViewBag.Cursos = cursos;

            professores.Insert(0, new Professor() { ProfessorID = 0, Nome = "Selecione o professor" });
            ViewBag.Professores = professores;
        }

        [HttpGet]
        public IActionResult AdicionarProfessor()
        {
            PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                        new List<Departamento>().ToList(), new List<Curso>().ToList(), new List<Professor>().ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarProfessor([Bind("InstituicaoID, DepartamentoID, CursoID, ProfessorID")] AdicionarProfessorViewModel model)
        {
            if (model.InstituicaoID == 0 || model.DepartamentoID == 0 || model.CursoID == 0 || model.ProfessorID == 0)
            {
                ModelState.AddModelError("", "É preciso selecionar todos os dados");
            }
            else
            {
                cursoDAL.RegistrarProfessor((long)model.CursoID, (long)model.ProfessorID);

                RegistrarProfessorNaSessao((long)model.CursoID, (long)model.ProfessorID);

                PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                    departamentoDAL.ObterDepartamentosPorInstituicao((long)model.InstituicaoID).ToList(),
                    cursoDAL.ObterCursosPorDepartamento((long)model.DepartamentoID).ToList(),
                    cursoDAL.ObterProfessoresForaDoCurso((long)model.CursoID).ToList());
            }
            return View(model);
        }

        public JsonResult ObterDepartamentosPorInstituicao(long actionID)
        {
            var departamentos = departamentoDAL.ObterDepartamentosPorInstituicao(actionID).ToList();
            return Json(new SelectList(departamentos, "DepartamentoID", "Nome"));
        }

        public JsonResult ObterCursosPorDepartamento(long actionID)
        {
            var cursos = cursoDAL.ObterCursosPorDepartamento(actionID).ToList();
            return Json(new SelectList(cursos, "CursoID", "Nome"));
        }

        public JsonResult ObterProfessoresForaDoCurso(long actionID)
        {
            var professores = cursoDAL.ObterProfessoresForaDoCurso(actionID).ToList();
            return Json(new SelectList(professores, "ProfessorID", "Nome"));
        }

        public void RegistrarProfessorNaSessao(long cursoID, long professorID)
        {
            var cursoProfessor = new CursoProfessor() { ProfessorID = professorID, CursoID = cursoID };
            List<CursoProfessor> cursosProfessor = new List<CursoProfessor>();
            string cursosProfessoresSession = HttpContext.Session.GetString("cursosProfessores");
            if (cursosProfessoresSession != null)
            {
                cursosProfessor = JsonConvert.DeserializeObject<List<CursoProfessor>>(cursosProfessoresSession);
            }
            cursosProfessor.Add(cursoProfessor);
            HttpContext.Session.SetString("cursosProfessores", JsonConvert.SerializeObject(cursosProfessor));
        }

        public IActionResult VerificarUltimosRegistros()
        {
            List<CursoProfessor> cursosProfessor = new List<CursoProfessor>();
            string cursosProfessoresSession = HttpContext.Session.GetString("cursosProfessores");
            if (cursosProfessoresSession != null)
            {
                cursosProfessor = JsonConvert.DeserializeObject<List<CursoProfessor>>(cursosProfessoresSession);
            }
            return View(cursosProfessor);
        }

        /////////////////////////////////////////////
        public async Task<IActionResult> ListaCursoProfessor()
        {
            return View(await cursoProfessorDAL.ObterCursoProfessorClassificadosPorCurso().ToListAsync());
            //return View(await departamentoDAL.ObterDepartamentosClassificadosPorNome().ToListAsync());
        }


        //////////////

        //GET:Professor/Index
        public async Task<IActionResult> Index()
        {
            return View(await professorDAL.ObterProfessorClassificadoPorNome().ToListAsync());
        }

        public async Task<IActionResult> RegistroCursoProfessor()
        {
            return View(await cursoProfessorDAL.ObterCursoProfessorClassificadosPorCurso().ToListAsync());
        }

        //GET: Professor/Detales
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        private async Task<IActionResult> ObterVisaoProfessorPorId(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var professor = await professorDAL.ObterProfessorPorId((long)id);
            if(professor == null) { return NotFound(); }
            return View(professor);
        }

        //GET: Professor/Crear
        public IActionResult Create()
        {
            return View();
        }

        //POST: Professor/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessorID,Nome")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                await professorDAL.GravarProfessor(professor);
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }
        
        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ProfessorID,Nome")] Professor professor)
        {
            if(id != professor.ProfessorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await professorDAL.GravarProfessor(professor);
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(! await ProfessorExists(professor.ProfessorID))
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
            return View(professor);
        }

        private async Task<bool> ProfessorExists(long? id)
        {
            return await professorDAL.ObterProfessorPorId((long)id) != null;
            //return await instituicaoDAL.ObterInstituicaoPorId((long)id) != null;
        }
                
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoProfessorPorId(id);
        }

        public async Task<IActionResult> DetalisCursoProfessor(long? id)
        {
            return await ObterVisaoPorCursoProfessorIdCurso(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var professor = await professorDAL.EliminarProfessorPorId((long)id);
            TempData["Message"] = "Professor " + professor.Nome.ToUpper()+" foi removido";
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> ObterVisaoPorCursoProfessorIdCurso(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var cursoProfessor = await cursoProfessorDAL.ObterCursoProfessorPorIdCurso((long)id);
            if(cursoProfessor == null)
            {
                return NotFound();
            }

            return View(cursoProfessor);
        }

        public async Task<IActionResult> DeleteCursoProfessor(long? id)
        {
            return await ObterVisaoPorCursoProfessorIdCurso(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCursoProfessorConfirmed(long? id)
        {
            var cursoProfessor = await cursoProfessorDAL.EliminarCursoProfessorPorIdCurso((long)id);
            TempData["Message"] = "O Professor " + cursoProfessor.Professor.Nome.ToUpper() + " foi removido do curso "+cursoProfessor.Curso.Nome.ToUpper();
            return RedirectToAction(nameof(ListaCursoProfessor));
        }
    }
}