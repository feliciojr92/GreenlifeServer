using GreenlifeServer.Persistencia;
using GreenlifeServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public class MidiaRepository : IMidiaRepository
    {
        private Context _context;

        public MidiaRepository(Context context)
        {
            _context = context;
        }

        public void Atualizar(Midia midia)
        {
            var local = _context.Midias
                .Local.FirstOrDefault(m => m.MidiaId == midia.MidiaId);

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Midias.Update(midia);
        }

        public Midia Buscar(int id)
        {
            try
            {
                var midia = _context.Midias.Find(id);
                return _context.Midias.Include(u => u.Usuario).FirstOrDefault(u => u.UsuarioId == midia.UsuarioId);
            }
            catch
            {
                return null;
            }
        }

        public IList<Midia> BuscarPor(Expression<Func<Midia, bool>> filtro)
        {
            return _context.Midias.Where(filtro).ToList();
        }

        public void Cadastrar(Midia midia)
        {
            _context.Midias.Add(midia);
        }

        public IList<Midia> Listar()
        {
            return _context.Midias.ToList();
        }

        public void Remover(int id)
        {
            _context.Midias.Remove(_context.Midias.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges(); 
        }
    }
}
