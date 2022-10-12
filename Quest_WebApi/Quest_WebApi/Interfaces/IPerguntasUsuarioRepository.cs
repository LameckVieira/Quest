using Quest_WebApi.Domains;
using System.Collections.Generic;

namespace Quest_WebApi.Interfaces
{
    public interface IPerguntasUsuarioRepository
    {

        /// <summary>
        /// Lista todos os Pergunta
        /// </summary>
        /// <returns>Uma lista de Pergunta</returns>
        List<PerguntasUsuario> Listar();

        /// <summary>
        /// Busca um Pergunta através do ID
        /// </summary>
        /// <param name="id">ID do Pergunta que será buscado</param>
        /// <returns>Um Pergunta buscado</returns>
        PerguntasUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Pergunta
        /// </summary>
        /// <param name="novaPergunta">Objeto novoPergunta que será cadastrado</param>
        void Cadastrar(PerguntasUsuario novaPerguntasUsuario);

        /// <summary>
        /// Deleta um Pergunta existente
        /// </summary>
        /// <param name="id">ID do Partida que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um Pergunta existente
        /// </summary>
        /// <param name="id">ID do Tema que será atualizado</param>
        /// <param name="Pergunta">Objeto PerguntaAtualizado com as novas informações</param>
        void Atualizar(int id, PerguntasUsuario PerguntasUsuarioAtualizada);

        /// <summary>
        /// Busca um usuario pelo nome
        /// </summary>
        /// <param name="nome">Nome do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        PerguntasUsuario BuscarPeloResultado(int nome);

    }
}
