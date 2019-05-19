using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Docente;

namespace Capitulo01.Data.DAL.Docente
{
    public class CursoProfessorDAL
    {
        private IESContext _context;

        public CursoProfessorDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<CursoProfessor> ObterCursoProfessorClassificadosPorCurso()
        {
            return _context.CursoProfessor.Include(c => c.Curso).Include(p => p.Professor).OrderBy(d => d.Curso);
            //return _context.Departamentos.Include(i => i.Instituicao).OrderBy(b => b.Nome);
        }

        public async Task<CursoProfessor> ObterCursoProfessorPorIdCurso(long id)
        {
            //var cursoProfessor = await _context.CursoProfessor.SingleOrDefaultAsync(m => m.CursoID == id);
            //_context.Professores.Where(i => cursoProfessor.ProfessorID == i.ProfessorID).Load();
            return await _context.CursoProfessor.Include(c => c.Curso).Include(p => p.Professor).SingleOrDefaultAsync(m => m.CursoID == id);
            //return await _context.Instituicoes.Include(d => d.Departamentos).SingleOrDefaultAsync(m => m.InstituicaoID == id);
            /*var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoID == id);
            _context.Instituicoes.Where(i => departamento.InstituicaoID == i.InstituicaoID).Load();
            return departamento;*/
        }

        public async Task<CursoProfessor> EliminarCursoProfessorPorIdCurso(long id)
        {
            CursoProfessor cursoProfessor = await ObterCursoProfessorPorIdCurso(id);
            _context.CursoProfessor.Remove(cursoProfessor);
            await _context.SaveChangesAsync();
            return cursoProfessor;
        }
    }
}
