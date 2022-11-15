using Quest_WebApi.DbModels;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, Categoria CategoriaAtualizada)
        {
            Categoria categoriaBuscados = ctx.Categoria.Find(id);

            if (categoriaBuscados.IdCategoria != null)
            {
                // Atribui os novos valores aos campos existentes
                categoriaBuscados.IdCategoria = CategoriaAtualizada.IdCategoria;
            }

            if (categoriaBuscados.NomeCategoria != null)
            {
                // Atribui os novos valores aos campos existentes
                categoriaBuscados.NomeCategoria = CategoriaAtualizada.NomeCategoria;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.Categoria.Update(categoriaBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Categoria BuscarPeloNome(string nome)
        {
            return ctx.Categoria.FirstOrDefault(u => u.NomeCategoria == nome);
        }

        public Categoria BuscarPorId(int id)
        {
            return ctx.Categoria.FirstOrDefault(u => u.IdCategoria == id);
        }

        public void Cadastrar(Categoria novaCategoria)
        {
            // Adiciona este novoUsuariol
            ctx.Categoria.Add(novaCategoria);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Categoria categoriaBuscados = ctx.Categoria.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Categoria.Remove(categoriaBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return ctx.Categoria.ToList();
        }
    }
}
