using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenlifeServer.Models;
using GreenlifeServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenlifeServer.Controllers
{
    [Route("GreenLife/[controller]")]
    [ApiController]
    public class TestemunhaController : ControllerBase
    {
        private ITestemunhaRepository _testemunhaRepository;

        public TestemunhaController(ITestemunhaRepository testemunhaRepository)
        {
            _testemunhaRepository = testemunhaRepository;
        }

        [HttpGet]
        public IList<Testemunha> Get()
        {
            return _testemunhaRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Testemunha> Get(int id)
        {
            if (_testemunhaRepository.Buscar(id) == null)
                return NotFound("Testemunha não encontrada...");

            return _testemunhaRepository.Buscar(id);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Testemunha> Post(Testemunha testemunha)
        {
            _testemunhaRepository.Cadastrar(testemunha);
            _testemunhaRepository.Salvar();
            return CreatedAtAction("Get", new { id = testemunha.TestemunhaId }, testemunha);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Testemunha> Put(int id, Testemunha testemunha)
        {
            if (_testemunhaRepository.Buscar(id) == null)
                return NotFound("Testemunha não encontrada...");

            testemunha.TestemunhaId = id;
            _testemunhaRepository.Atualizar(testemunha);
            _testemunhaRepository.Salvar();
            return Ok(testemunha);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (_testemunhaRepository.Buscar(id) == null)
                return NotFound("Testemunha não encontrada...");

            _testemunhaRepository.Remover(id);
            _testemunhaRepository.Salvar();
            return NoContent();
        }
    }
}
