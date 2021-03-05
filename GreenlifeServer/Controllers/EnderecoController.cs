using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenlifeServer.Models;
using GreenlifeServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenlifeServer.Controllers
{
    [Route("GreenLife/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        // /api/endereco(GET) -> Listar os enderecos
        public IList<Endereco> Get()
        {
            return _enderecoRepository.Listar();
        }

        // /api/endereco/1 (GET) -> Pesquisa por id
        [HttpGet("{id}")]
        public ActionResult<Endereco> Get(int id)
        {
            if (_enderecoRepository.Buscar(id) == null)
                return NotFound("Endereço não encontrado..."); //404

            return _enderecoRepository.Buscar(id);
        }

        // /api/endereco (POST) -> Cadastrar
        [HttpPost]
        public ActionResult<Endereco> Post(Endereco endereco)
        {
            _enderecoRepository.Cadastrar(endereco);
            _enderecoRepository.Salvar();
            //Response 201 Created, os dados do endereco salvo
            //E o link para acessar o endereco cadastrado
            return CreatedAtAction("Get", new { id = endereco.EnderecoId }, endereco);
        }

        // /api/endereco/1 (PUT) -> Atualizar 
        [HttpPut("{id}")]
        public ActionResult<Endereco> Put(int id, Endereco endereco)
        {
            if (_enderecoRepository.Buscar(id) == null)
                return NotFound("Endereço não encontrado..."); //404

            endereco.EnderecoId = id; //passa o id para o objeto para ele atualizar
            _enderecoRepository.Atualizar(endereco);
            _enderecoRepository.Salvar();
            return Ok(endereco);
        }

        // /api/endereco/1 (DELETE) -> Remover
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_enderecoRepository.Buscar(id) == null)
                return NotFound("Endereço não encontrado...");

            _enderecoRepository.Remover(id);
            _enderecoRepository.Salvar();
            return NoContent();  
        }
    }
}
