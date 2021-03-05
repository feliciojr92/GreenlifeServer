using GreenlifeServer.Models;
using GreenlifeServer.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private Context _context;

        public EnderecoRepository(Context context)
        {
            _context = context;
        }

        public void Atualizar(Endereco endereco)
        {
            //Pesquisar o endereço que está gerenciado
            var local = _context.Enderecos
                .Local.FirstOrDefault(e => e.EnderecoId== endereco.EnderecoId);

            //Remover o endereco que está gerenciado
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Enderecos.Update(endereco);
        }

        public Endereco Buscar(int id)
        {
           return _context.Enderecos.Find(id);
        }

        public IList<Endereco> BuscarPor(Expression<Func<Endereco, bool>> filtro)
        {
            return _context.Enderecos.Where(filtro).ToList();
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public IList<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public void Remover(int id)
        {
            _context.Enderecos.Remove(_context.Enderecos.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
