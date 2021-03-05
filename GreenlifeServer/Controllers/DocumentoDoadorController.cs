using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenlifeServer.Models;
using GreenLifeServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenlifeServer.Controllers
{
    [Route("GreenLife/documento")]
    [ApiController]
    public class DocumentoDoadorController : ControllerBase
    {
        private IDocumentoDoadorRepository _documentodoadorRepository;

        public DocumentoDoadorController(IDocumentoDoadorRepository documentodoadorRepository)
        {
            _documentodoadorRepository = documentodoadorRepository;
        }

        // /api/endereco(GET) -> Listar os enderecos
        public IList<DocumentoDoador> Get()
        {
            return _documentodoadorRepository.Listar();
        }

        // /api/endereco/1 (GET) -> Pesquisa por id
        [HttpGet("{id}")]
        public ActionResult<DocumentoDoador> Get(int id)
        {
            if (_documentodoadorRepository.Buscar(id) == null)
                return NotFound("Documento de doador não encontrado..."); //404

            return _documentodoadorRepository.Buscar(id);
        }

        // /api/endereco (POST) -> Cadastrar
        [HttpPost]
        [Authorize]
        public ActionResult<DocumentoDoador> Post(DocumentoDoador documentodoador)
        {
            _documentodoadorRepository.Cadastrar(documentodoador);
            _documentodoadorRepository.Salvar();
            //Response 201 Created, os dados do endereco salvo
            //E o link para acessar o endereco cadastrado
            return CreatedAtAction("Get", new { id = documentodoador.DocumentoDoadorId }, documentodoador);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<DocumentoDoador> Put(int id, DocumentoDoador documentodoador)
        {
            if (_documentodoadorRepository.Buscar(id) == null)
                return NotFound("Documento de doador não encontrado...");

            documentodoador.DocumentoDoadorId = id;
            _documentodoadorRepository.Atualizar(documentodoador);
            _documentodoadorRepository.Salvar();
            return Ok(documentodoador);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (_documentodoadorRepository.Buscar(id) == null)
                return NotFound("Documento de doador não encontrado...");

            _documentodoadorRepository.Remover(id);
            _documentodoadorRepository.Salvar();
            return NoContent();
        }
    }
}
