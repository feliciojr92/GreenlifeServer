using GreenlifeServer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GreenlifeServer.Repositories
{
    public interface IEnderecoRepository
    {
        void Cadastrar(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Remover(int id);
        Endereco Buscar(int id);
        IList<Endereco> Listar();
        IList<Endereco> BuscarPor(Expression<Func<Endereco, bool>> filtro);
        void Salvar();
    }
}
