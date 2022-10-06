﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quest_WebApi.Domains;
using Quest_WebApi.Interfaces;
using Quest_WebApi.Repositories;

namespace Quest_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _perfilRepository que irá receber todos os métodos definidos na interface IPerfilRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _perfilRepository para que haja a referência nos métodos implementadas no repositório PerfilRepository
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os perfis
        /// </summary>
        /// <returns>Uma lista de perfis e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.Listar());
        }



        /// <summary>
        /// Atualiza um perfil existente
        /// </summary>
        /// <param name="id">ID do perfil que será atualizado</param>
        /// <param name="perfilAtualizado">Objeto perfilAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario perfilAtualizado)
        {
            // Faz a chamada para o método
            _usuarioRepository.Atualizar(id, perfilAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um perfil através do seu ID
        /// </summary>
        /// <param name="id">ID do perfil que será buscado</param>
        /// <returns>Um perfil encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/Usuarios/1

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Busca um perfil através do seu nome
        /// </summary>
        /// <param name="nome">Nome do perfil que será buscado</param>
        /// <returns>Um perfil encontrado em um status code 200 - OK</returns>
        /// http://localhost:5000/api/Usuarios/joao

        [HttpGet("byname/{nome}")]
        public IActionResult GetByName(string nome)
        {
            return Ok(_usuarioRepository.BuscarPeloNome(nome));
        }

        /// <summary>
        /// Cadastra um novo perfil
        /// </summary>
        /// <param name="novoPerfil">Objeto novoPerfil que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        /// 

        [HttpPost]
        public IActionResult Post(Usuario novoPerfil)
        {
            // Faz a chamada para o método
            _usuarioRepository.Cadastrar(novoPerfil);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um perfil existente
        /// </summary>
        /// <param name="id">ID do perfil que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _usuarioRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }
    }
}
