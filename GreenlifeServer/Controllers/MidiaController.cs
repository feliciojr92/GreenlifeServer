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
    public class MidiaController : ControllerBase
    {
        private IMidiaRepository _midiaRepository;
        public static IWebHostEnvironment _environment;

        public MidiaController(IMidiaRepository midiaRepository,
            IWebHostEnvironment environment)
        {
            _midiaRepository = midiaRepository;
            _environment = environment;
        }

        [HttpPost("upload")]
        [Authorize]
        public string EnviaArquivo([FromForm] IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                var aName = DateTime.UtcNow.ToLongDateString() + "_" + arquivo.FileName;
                var path = _environment.WebRootPath + "/midias/";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (FileStream filestream = System.IO.File.Create(path + aName))
                {
                    arquivo.CopyTo(filestream);
                    filestream.Flush();
                    return "/midias/" + aName;
                }
            }
            else
                return "Upload inválido!";
        }

        [HttpGet]
        public IList<Midia> Get()
        {
            return _midiaRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Midia> Get(int id)
        {
            var midia = _midiaRepository.Buscar(id);

            if (midia == null)
                return NotFound("Mídia não encontrada...");

            return midia;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Midia> Post(Midia midia)
        {
            _midiaRepository.Cadastrar(midia);
            _midiaRepository.Salvar();
            return CreatedAtAction("Get", new { id = midia.MidiaId }, midia);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Midia> Put(int id, Midia midia)
        {
            if (_midiaRepository.Buscar(id) == null)
                NotFound("Mídia não encontrada...");

            midia.MidiaId = id;
            _midiaRepository.Atualizar(midia);
            _midiaRepository.Salvar();
            return Ok(midia);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var m = _midiaRepository.Buscar(id);

            if (m == null)
                return NotFound("Mídia não encontrada...");

            _midiaRepository.Remover(id);
            _midiaRepository.Salvar();
            return NoContent();
        }
    }
}
