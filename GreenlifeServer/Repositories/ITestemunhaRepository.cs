using GreenlifeServer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public interface ITestemunhaRepository
    {
        void Cadastrar(Testemunha testemunha);
        void Atualizar(Testemunha testemunha);
        void Remover(int id);
        Testemunha Buscar(int id);
        IList<Testemunha> Listar();
        IList<Testemunha> BuscarPor(Expression<Func<Testemunha, bool>> filtro);
        void Salvar();
    }
}
