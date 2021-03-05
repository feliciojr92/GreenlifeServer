using GreenlifeServer.Models;
using GreenlifeServer.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int id);
        Usuario Buscar(int id);
        IList<Usuario> Listar();
        IList<Usuario> BuscarPor(Expression<Func<Usuario, bool>> filtro);
        void Salvar();
        Usuario Validar(string email, string senha);
    }
}
