using Quest_WebApi.Contexts;
using Quest_WebApi.Domains;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class PartidaRepository : IPartidaRepository
    {

        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, Partida PartidaAtualizada)
        {
            Partida partidaBuscados = ctx.Partida.Find(id);

            if (partidaBuscados.IdPartida != null)
            {
                // Atribui os novos valores aos campos existentes
                partidaBuscados.IdPartida = PartidaAtualizada.IdPartida;
            }

            if (partidaBuscados.Pontuacao != null)
            {
                // Atribui os novos valores aos campos existentes
                partidaBuscados.Pontuacao = PartidaAtualizada.Pontuacao;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.Partida.Update(partidaBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Partida BuscarPelaPontucao(int pontuacao)
        {
            return ctx.Partida.FirstOrDefault(u => u.Pontuacao == pontuacao);
        }

        public Partida BuscarPorId(int id)
        {
            return ctx.Partida.FirstOrDefault(u => u.IdPartida == id);
        }

        public void Cadastrar(Partida novaPartida)
        {
            // Adiciona este novoUsuariol
            ctx.Partida.Add(novaPartida);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Partida partidaBuscados = ctx.Partida.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Partida.Remove(partidaBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Partida> Listar()
        {
            return ctx.Partida.ToList();
        }
    }
}
