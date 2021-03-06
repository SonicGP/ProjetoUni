﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capitulo01.Data;
using Modelo.Cadastros;
using Capitulo01.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capitulo01.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    [Authorize]
    public class CursoController : Controller
    {
        private readonly IESContext _context;
        private readonly CursoDAL cursoDAL;
        private readonly DepartamentoDAL departamentoDAL;

        public CursoController(IESContext context)
        {
            _context = context;
            cursoDAL = new CursoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
        }

        //GET: Curso
        public async Task<IActionResult> Index()
        {
            return View(await cursoDAL.ObterCursoClassificadosPorNome().ToListAsync());
        }

        //GET: Curso/Detales
        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoCursoPorId(id);
        }

        //GET: Curso/Criar
        public IActionResult Create()
        {
            var departamento = departamentoDAL.ObterDepartamentosClassificadosPorNome().ToList();
            departamento.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o Departamento" });
            ViewBag.Departamento = departamento;
            return View();
        }

        //POST: Curso/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, DepartamentoID")] Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await cursoDAL.GravarCurso(curso);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("","Não foi possivel inserir os dados.");
            }

            return View(curso);
        }

        //GET: Curso/Edite
        public async Task<IActionResult> Edit(long? id)
        {
            ViewResult visaoCurso = (ViewResult)await ObterVisaoCursoPorId(id);
            Curso curso = (Curso)visaoCurso.Model;
            ViewBag.Departamento = new SelectList(departamentoDAL.ObterDepartamentosClassificadosPorNome(), "CursoID", "Nome", curso.DepartamentoID);
            return visaoCurso;
        }

        //POST: Curso/Edite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id,[Bind("CursoID,Nome,DepartamentoID")] Curso curso)
        {
            if(id != curso.CursoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await cursoDAL.GravarCurso(curso);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(! await CursoExists(curso.CursoID))
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
            ViewBag.Departamento = new SelectList(departamentoDAL.ObterDepartamentosClassificadosPorNome(), "DepartamentoID", "Nome", curso.DepartamentoID);
            return View(curso);
        }

        //GET: Curso/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoCursoPorId(id);
        }

        //POST: Curso/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var curso = await cursoDAL.EliminarCursoPorId((long)id);
            TempData["Message"] = "Curso " + curso.Nome.ToUpper() + " foi removido";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CursoExists(long? id)
        {
            return await cursoDAL.ObterCursoPorId((long)id) != null;
        }

        private async Task<IActionResult> ObterVisaoCursoPorId(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var curso = await cursoDAL.ObterCursoPorId((long)id);

            if(curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }
    }
}