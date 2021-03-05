using GreenlifeServer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public interface IMidiaRepository
    {
        void Cadastrar(Midia midia);
        void Atualizar(Midia midia);
        void Remover(int id);
        Midia Buscar(int id);
        IList<Midia> Listar();
        IList<Midia> BuscarPor(Expression<Func<Midia, bool>> filtro);
        void Salvar();
    }
}
