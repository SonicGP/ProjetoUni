using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Microsoft.EntityFrameworkCore;

namespace Capitulo01.Data.DAL.Cadastros
{
    public class DisciplinaDAL
    {
        private IESContext _context;

        public DisciplinaDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Disciplina> ObterDiciplinaClassificadoPorNome()
        {
            return _context.Disciplinas.OrderBy(b => b.Nome);
        }

        public async Task<Disciplina> ObterDiciplinaPorId(long id)
        {
            return await _context.Disciplinas.Include(d => d.CursoDisciplinas).SingleOrDefaultAsync(m => m.DisciplinaID == id);
        }

        public async Task<Disciplina> GravarDiciplina(Disciplina disciplina)
        {
            if(disciplina.DisciplinaID == null)
            {
                _context.Disciplinas.Add(disciplina);
            }
            else
            {
                _context.Update(disciplina);
            }
            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<Disciplina> ElilminarDiciplinaPorId(long id)
        {
            Disciplina disciplina = await ObterDiciplinaPorId(id);
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
            return disciplina;
        }
    }
}
