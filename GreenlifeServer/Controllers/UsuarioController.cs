using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using GreenlifeServer.Models;
using GreenlifeServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GreenlifeServer.Controllers
{
    [Route("GreenLife/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public static IWebHostEnvironment _environment;
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioRepository usuarioRepository,
            IWebHostEnvironment environment,
            IOptions<JwtSettings> jwtSettings,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _environment = environment;
            _jwtSettings = jwtSettings.Value;
            _configuration = configuration;
        }

        [HttpGet("login")]
        public ActionResult<UserToken> Login([FromBody] Credenciais credenciais)
        {

            var user = _usuarioRepository.Validar(credenciais.Email, credenciais.Senha);

            if (user == null)
                return NotFound("Email ou senha inválidos!");
            return BuildToken(credenciais);
        }

        private UserToken BuildToken(Credenciais credenciais)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, credenciais.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpPost("upload")]
        [Authorize]
        public string EnviaArquivo([FromForm] IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                var aName = DateTime.UtcNow.ToLongDateString() + "_" + arquivo.FileName;
                var path = _environment.WebRootPath + "/imagens/";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (FileStream filestream = System.IO.File.Create(path + aName))
                {
                    arquivo.CopyTo(filestream);
                    filestream.Flush();
                    return "/imagens/" + aName;
                }
            }
            else
                return "Upload inválido!";
        }

        [HttpGet]
        public IList<Usuario> Get()
        {
            return _usuarioRepository.Listar();
        }

        // /api/usuario/1 (GET) -> Pesquisa por id
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            if (_usuarioRepository.Buscar(id) == null)
                return NotFound("Usuário não encontrado..."); //404

            return _usuarioRepository.Buscar(id);
        }

        // /api/usuario (POST) -> Cadastrar
        [HttpPost]
        public ActionResult<Usuario> Post(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            _usuarioRepository.Salvar();
            //Response 201 Created, os dados do usuário salvo
            //E o link para acessar o usuário cadastrado
            return CreatedAtAction("Get", new { id = usuario.UsuarioId }, usuario);
        }

        // /api/usuario/1 (PUT) -> Atualizar 
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Usuario> Put(int id, Usuario usuario)
        {
            if (_usuarioRepository.Buscar(id) == null)
                return NotFound("Usuário não encontrado..."); //404

            usuario.UsuarioId = id; //passa o id para o objeto para ele atualizar
            _usuarioRepository.Atualizar(usuario);
            _usuarioRepository.Salvar();
            return Ok(usuario);
        }

        // /api/usuario/1 (DELETE) -> Remover
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            if(_usuarioRepository.Buscar(id) == null)
                return NotFound("Usuário não encontrado...");

            _usuarioRepository.Remover(id);
            _usuarioRepository.Salvar();
            return NoContent(); //204 No Content 
        }
    }
}
