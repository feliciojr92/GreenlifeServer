using GreenlifeServer.Models;
using GreenlifeServer.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public class TestemunhaRepository : ITestemunhaRepository
    {
        private Context _context;

        public TestemunhaRepository(Context context)
        {
            _context = context;
        }

        public void Atualizar(Testemunha testemunha)
        {
            var local = _context.Testemunhas
                .Local.FirstOrDefault(t => t.TestemunhaId == testemunha.TestemunhaId);

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Testemunhas.Update(testemunha);
        }

        public Testemunha Buscar(int id)
        {
            return _context.Testemunhas.Find(id);
        }

        public IList<Testemunha> BuscarPor(Expression<Func<Testemunha, bool>> filtro)
        {
            return _context.Testemunhas.Where(filtro).ToList();
        }

        public void Cadastrar(Testemunha testemunha)
        {
            _context.Testemunhas.Add(testemunha);
        }

        public IList<Testemunha> Listar()
        {
            return _context.Testemunhas.ToList();
        }

        public void Remover(int id)
        {
            _context.Testemunhas.Remove(_context.Testemunhas.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
