using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GreenlifeServer.Models;
using GreenlifeServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenLifeServer.Controllers
{
    [Route("GreenLife/[controller]")]
    [ApiController]
    public class DepoimentoController : ControllerBase
    {
        private IDepoimentoRepository _depoimentoRepository;
        public static IWebHostEnvironment _environment;

        public DepoimentoController(IDepoimentoRepository depoimentoRepository,
            IWebHostEnvironment environment)
        {
            _depoimentoRepository = depoimentoRepository;
            _environment = environment;
        }

        [HttpPost("upload")]
        [Authorize]
        public string EnviaArquivo([FromForm] IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                var aName = DateTime.UtcNow.ToLongDateString() + "_" + arquivo.FileName;
                var path = _environment.WebRootPath + "/depoimentos/";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (FileStream filestream = System.IO.File.Create(path + aName))
                {
                    arquivo.CopyTo(filestream);
                    filestream.Flush();
                    return "/depoimentos/" + aName;
                }
            }
            else
                return "Upload inválido!";
        }

        [HttpGet]
        public IList<Depoimento> Get()
        {
            return _depoimentoRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Depoimento> Get(int id)
        {
            if (_depoimentoRepository.Buscar(id) == null)
                return NotFound("Depoimento não encontrado...");

            return _depoimentoRepository.Buscar(id);
        }

        [HttpGet("buscar/{id}")]
        [Authorize]
        public IList<Depoimento> BuscarPorUsuario(int id)
        {
            return _depoimentoRepository.BuscarPorUsuario(id);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Depoimento> Post(Depoimento depoimento)
        {
            _depoimentoRepository.Cadastrar(depoimento);
            _depoimentoRepository.Salvar();
            return CreatedAtAction("Get", new { id = depoimento.DepoimentoId }, depoimento);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Depoimento> Put(int id, Depoimento depoimento)
        {
            if (_depoimentoRepository.Buscar(id) == null)
                return NotFound("Depoimento não encontrado...");

            depoimento.DepoimentoId = id;
            _depoimentoRepository.Atualizar(depoimento);
            _depoimentoRepository.Salvar();
            return Ok(depoimento);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (_depoimentoRepository.Buscar(id) == null)
                return NotFound("Depoimento não encontrado...");

            _depoimentoRepository.Remover(id);
            _depoimentoRepository.Salvar();
            return NoContent();
        }
    }
}