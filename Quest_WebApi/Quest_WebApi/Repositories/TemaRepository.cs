using Quest_WebApi.DbModels;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class TemaRepository : ITemaRepository
    {

        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, Tema TemaAtualizado)
        {
            Tema temaBuscados = ctx.Temas.Find(id);

            if (temaBuscados.IdTema != null)
            {
                // Atribui os novos valores aos campos existentes
                temaBuscados.IdTema = TemaAtualizado.IdTema;
            }

            if (temaBuscados.NomeTema != null)
            {
                // Atribui os novos valores aos campos existentes
                temaBuscados.NomeTema = TemaAtualizado.NomeTema;
            }

            if (TemaAtualizado.IdCategoria != null)
            {
                // Atribui os novos valores aos campos existentes
                temaBuscados.IdCategoria = TemaAtualizado.IdCategoria;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.Temas.Update(temaBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Tema BuscarPeloNome(string nome)
        {
            return ctx.Temas.FirstOrDefault(u => u.NomeTema == nome);
        }

        public Tema BuscarPorId(int id)
        {
            return ctx.Temas.FirstOrDefault(u => u.IdTema == id);
        }

        public void Cadastrar(Tema novaTema)
        {
            // Adiciona este novoUsuariol
            ctx.Temas.Add(novaTema);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Tema temaBuscados = ctx.Temas.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Temas.Remove(temaBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Tema> Listar()
        {
            return ctx.Temas.ToList();
        }
    }
}
