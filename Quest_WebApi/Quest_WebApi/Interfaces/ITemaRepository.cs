using Quest_WebApi.DbModels;
using System.Collections.Generic;

namespace Quest_WebApi.Interfaces
{
    public interface ITemaRepository
    {
        /// <summary>
        /// Lista todos os Tema
        /// </summary>
        /// <returns>Uma lista de Temas</returns>
        List<Tema> Listar();

        /// <summary>
        /// Busca um Tema através do ID
        /// </summary>
        /// <param name="id">ID do Tema que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        Tema BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Tema
        /// </summary>
        /// <param name="novoTema">Objeto novoTema que será cadastrado</param>
        void Cadastrar(Tema novaTema);

        /// <summary>
        /// Deleta um Tema existente
        /// </summary>
        /// <param name="id">ID do Tema que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um Tema existente
        /// </summary>
        /// <param name="id">ID do Tema que será atualizado</param>
        /// <param name="Tema">Objeto TemaAtualizado com as novas informações</param>
        void Atualizar(int id, Tema TemaAtualizado);

        /// <summary>
        /// Busca um usuario pelo nome
        /// </summary>
        /// <param name="nome">Nome do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        Tema BuscarPeloNome(string nome);
    }
}
