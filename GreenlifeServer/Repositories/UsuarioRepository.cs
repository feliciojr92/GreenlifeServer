using GreenlifeServer.Models;
using GreenlifeServer.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenlifeServer.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private Context _context;
        
        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public void Atualizar(Usuario usuario)
        {
            //Pesquisar o usuário que está gerenciado
            var local = _context.Usuarios
                .Local.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

            //Remover o usuário que está gerenciado
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Usuarios.Update(usuario);
        }

        public Usuario Buscar(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                return _context.Usuarios.Include(e => e.Endereco).FirstOrDefault(e => e.EnderecoId == usuario.EnderecoId);
            }
            catch
            {
                return null;
            }
        }

        public IList<Usuario> BuscarPor(System.Linq.Expressions.Expression<Func<Usuario, bool>> filtro)
        {
            return _context.Usuarios.Where(filtro).ToList();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Remover(int id)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public Usuario Validar(string email, string senha)
        {
            try
            {
                return _context.Usuarios.Where(u => u.Email == email && u.Senha == senha).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
