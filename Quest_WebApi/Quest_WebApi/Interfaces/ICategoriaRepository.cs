using Quest_WebApi.Domains;
using System.Collections.Generic;

namespace Quest_WebApi.Interfaces
{
    public interface ICategoriaRepository
    {

        /// <summary>
        /// Lista todos os Partida
        /// </summary>
        /// <returns>Uma lista de Temas</returns>
        List<Categoria> Listar();

        /// <summary>
        /// Busca um Tema através do ID
        /// </summary>
        /// <param name="id">ID do Partida que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        Categoria BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Tema
        /// </summary>
        /// <param name="novoPartida">Objeto novoPartida que será cadastrado</param>
        void Cadastrar(Categoria novaCategoria);

        /// <summary>
        /// Deleta um Partida existente
        /// </summary>
        /// <param name="id">ID do Partida que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um Partida existente
        /// </summary>
        /// <param name="id">ID do Tema que será atualizado</param>
        /// <param name="Partida">Objeto PartidaAtualizado com as novas informações</param>
        void Atualizar(int id, Categoria CategoriaAtualizada);

        /// <summary>
        /// Busca um usuario pelo nome
        /// </summary>
        /// <param name="nome">Nome do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        Categoria BuscarPeloNome(string nome);

    }
}
