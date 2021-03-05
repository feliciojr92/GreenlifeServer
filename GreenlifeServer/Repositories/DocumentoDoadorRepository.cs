using GreenlifeServer.Models;
using GreenlifeServer.Persistencia;
using GreenLifeServer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GreenlifeServer
{
    public class DocumentoDoadorRepository : IDocumentoDoadorRepository
    {
        private Context _context;

        public DocumentoDoadorRepository(Context context)
        {
            _context = context;
        }

        public void Atualizar(DocumentoDoador documentoDoador)
        {
            var local = _context.DocumentosDoador
                .Local.FirstOrDefault(d => d.DocumentoDoadorId == documentoDoador.DocumentoDoadorId);

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.DocumentosDoador.Update(documentoDoador);
        }

        public DocumentoDoador Buscar(int id)
        {
            return _context.DocumentosDoador.Find(id);
        }

        public IList<DocumentoDoador> BuscarPor(Expression<Func<DocumentoDoador, bool>> filtro)
        {
            return _context.DocumentosDoador.Where(filtro).ToList();
        }

        public void Cadastrar(DocumentoDoador documentoDoador)
        {
            _context.DocumentosDoador.Add(documentoDoador);
        }

        public IList<DocumentoDoador> Listar()
        {
            return (IList<DocumentoDoador>)_context.DocumentosDoador.ToList();
        }

        public void Remover(int id)
        {
            _context.DocumentosDoador.Remove(_context.DocumentosDoador.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
