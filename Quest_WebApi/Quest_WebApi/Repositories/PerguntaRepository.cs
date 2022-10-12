using Quest_WebApi.Contexts;
using Quest_WebApi.Domains;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, Pergunta PerguntaAtualizada)
        {
            Pergunta perguntaBuscados = ctx.Perguntas.Find(id);

            if (perguntaBuscados.IdPergunta != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.IdPergunta = PerguntaAtualizada.IdPergunta;
            }

            if (perguntaBuscados.IdTema != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.IdTema = PerguntaAtualizada.IdTema;
            }

            if (perguntaBuscados.Perguntas != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.Perguntas = PerguntaAtualizada.Perguntas;
            }
            if (perguntaBuscados.Alternativa != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.Alternativa = PerguntaAtualizada.Alternativa;
            }
            if (perguntaBuscados.Resposta != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.Resposta = PerguntaAtualizada.Resposta;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.Perguntas.Update(perguntaBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Pergunta BuscarPeloNome(string nome)
        {
            return ctx.Perguntas.FirstOrDefault(u => u.Perguntas == nome);
        }

        public Pergunta BuscarPorId(int id)
        {
            return ctx.Perguntas.FirstOrDefault(u => u.IdPergunta == id);
        }

        public void Cadastrar(Pergunta novaPergunta)
        {
            // Adiciona este novoUsuariol
            ctx.Perguntas.Add(novaPergunta);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Tema perguntaBuscados = ctx.Temas.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Temas.Remove(perguntaBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Pergunta> Listar()
        {
            return ctx.Perguntas.ToList();
        }
    }
}
