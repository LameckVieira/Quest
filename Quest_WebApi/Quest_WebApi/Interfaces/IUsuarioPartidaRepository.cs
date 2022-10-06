using Quest_WebApi.Domains;
using System.Collections.Generic;

namespace Quest_WebApi.Interfaces
{
    public interface IUsuarioPartidaRepository
    {

        /// <summary>
        /// Lista todos os Pfisica
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<UsuarioPartida> Listar();

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        UsuarioPartida BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuarioPartida">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(UsuarioPartida novaUsuarioPartida);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);


        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="UsuarioPartida">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, UsuarioPartida UsuarioPartidaAtualizada);

        List<UsuarioPartida> MeusDados(int idUsuario);

    }
}
