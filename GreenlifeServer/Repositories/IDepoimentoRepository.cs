using GreenlifeServer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public interface IDepoimentoRepository
    {
        void Cadastrar(Depoimento depoimento);
        void Atualizar(Depoimento depoimento);
        void Remover(int id);
        Depoimento Buscar(int id);
        IList<Depoimento> Listar();
        IList<Depoimento> BuscarPor(Expression<Func<Depoimento, bool>> filtro);
        IList<Depoimento> BuscarPorUsuario(int userId);
        void Salvar();
    }
}