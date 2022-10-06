using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quest_WebApi.Domains;
using Quest_WebApi.Interfaces;
using Quest_WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Quest_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPartidaController : ControllerBase
    {

        private IUsuarioPartidaRepository _usuariopartidaRepository { get; set; }

        public UsuarioPartidaController()
        {
            _usuariopartidaRepository = new UsuarioPartidaRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - ok </returns>
        //[Authorize(Roles = "3")]
        [HttpGet]
        public IActionResult Get()
        {
            //retorna a resposta da  requisição fazendo uma chamada para o método
            return Ok(_usuariopartidaRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">objeto NovoUsuario que será cadastrado</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(UsuarioPartida NovoUsuario)

        {
            //faza a chamada para o método 
            _usuariopartidaRepository.Cadastrar(NovoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pfisica existente
        /// </summary>
        /// <param name="id">ID do pfisica que será atualizado</param>
        /// <param name="PfisicaAtualizada">Objeto pfisicaAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, UsuarioPartida usuariopartidaAtualizada)
        {
            // Faz a chamada para o método
            _usuariopartidaRepository.Atualizar(id, usuariopartidaAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _usuariopartidaRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

        [Authorize]
        [HttpGet("meusDados/{id}")]
        public IActionResult MeusDados(int id)
        {
            try
            {


                return Ok(_usuariopartidaRepository.MeusDados(id));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }

        [Authorize]
        [HttpPut("atualizarMeuDados")]
        public IActionResult atualizarMeuDados()
        {
            try
            {

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(u => u.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_usuariopartidaRepository.MeusDados(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }

    }
}
