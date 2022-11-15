using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quest_WebApi.DbModels;
using Quest_WebApi.Interfaces;
using Quest_WebApi.Repositories;

namespace Quest_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {

        private IPartidaRepository _partidaRepository { get; set; }

        public PartidaController()
        {
            _partidaRepository = new PartidaRepository();
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
            return Ok(_partidaRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">objeto NovoUsuario que será cadastrado</param>
        /// <returns>um statud code 201- Created</returns>
        [HttpPost]
        public IActionResult Post(Partida NovoTema)

        {
            //faza a chamada para o método 
            _partidaRepository.Cadastrar(NovoTema);

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
        public IActionResult Put(int id, Partida temaAtualizada)
        {
            // Faz a chamada para o método
            _partidaRepository.Atualizar(id, temaAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpGet("byname/{nome}")]
        public IActionResult GetByName(int pontuacao)
        {
            return Ok(_partidaRepository.BuscarPelaPontucao(pontuacao));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //faz a chamada para o método
            _partidaRepository.Deletar(id);

            //retorna um status code
            return StatusCode(204);
        }

    }
}
