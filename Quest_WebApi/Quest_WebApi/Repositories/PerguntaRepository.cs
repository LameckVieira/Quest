using Quest_WebApi.DbModels;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, Perguntas PerguntaAtualizada)
        {
            Perguntas perguntaBuscados = ctx.Pergunta.Find(id);

            if (perguntaBuscados.IdPergunta != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.IdPergunta = PerguntaAtualizada.IdPergunta;
            }

            if (perguntaBuscados.IdPTema != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.IdPTema = PerguntaAtualizada.IdPTema;
            }

            if (perguntaBuscados.Pergunta != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.Pergunta = PerguntaAtualizada.Pergunta;
            }
            if (perguntaBuscados.Alternativas != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.Alternativas = PerguntaAtualizada.Alternativas;
            }
            if (perguntaBuscados.Reposta != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntaBuscados.Reposta = PerguntaAtualizada.Reposta;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.Pergunta.Update(perguntaBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Perguntas BuscarPeloNome(string nome)
        {
            return ctx.Pergunta.FirstOrDefault(u => u.Pergunta == nome);
        }

        public Perguntas BuscarPorId(int id)
        {
            return ctx.Pergunta.FirstOrDefault(u => u.IdPergunta == id);
        }

        public void Cadastrar(Perguntas novaPergunta)
        {
            // Adiciona este novoUsuariol
            ctx.Pergunta.Add(novaPergunta);

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

        public List<Perguntas> Listar()
        {
            return ctx.Pergunta.ToList();
        }
    }
}
