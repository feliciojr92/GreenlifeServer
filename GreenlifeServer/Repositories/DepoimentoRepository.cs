using GreenlifeServer.Models;
using GreenlifeServer.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public class DepoimentoRepository : IDepoimentoRepository
    {
        private Context _context;

        public DepoimentoRepository(Context context)
        {
            _context = context;
        }

        public void Atualizar(Depoimento depoimento)
        {
            var local = _context.Depoimentos
                .Local.FirstOrDefault(d => d.DepoimentoId == depoimento.DepoimentoId);

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Depoimentos.Update(depoimento);
        }

        public Depoimento Buscar(int id)
        {
            try
            {
                var depoimento = _context.Depoimentos.Find(id);
                return _context.Depoimentos.Include(u => u.Usuario).FirstOrDefault(u => u.UsuarioId == depoimento.UsuarioId);
            }
            catch
            {
                return null;
            }
        }

        public IList<Depoimento> BuscarPor(Expression<Func<Depoimento, bool>> filtro)
        {
            return _context.Depoimentos.Where(filtro).ToList();
        }

        public IList<Depoimento> BuscarPorUsuario(int userId)
        {
            return _context.Depoimentos.Where(id => id.UsuarioId == userId).ToList();
        }

        public void Cadastrar(Depoimento depoimento)
        {
            _context.Depoimentos.Add(depoimento);
        }

        public IList<Depoimento> Listar()
        {
            return _context.Depoimentos.ToList();
        }

        public void Remover(int id)
        {
            _context.Depoimentos.Remove(_context.Depoimentos.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
