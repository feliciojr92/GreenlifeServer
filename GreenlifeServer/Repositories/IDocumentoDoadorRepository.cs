using GreenlifeServer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GreenLifeServer.Repositories
{
    public interface IDocumentoDoadorRepository
    {
        void Cadastrar(DocumentoDoador documentodoador);
        void Atualizar(DocumentoDoador documentodoador);
        void Remover(int id);
        DocumentoDoador Buscar(int id);
        IList<DocumentoDoador> Listar();
        IList<DocumentoDoador> BuscarPor(Expression<Func<DocumentoDoador, bool>> filtro);
        void Salvar();
    }
}
