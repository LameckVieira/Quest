using Quest_WebApi.Contexts;
using Quest_WebApi.Domains;
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
            Categoria categoriaBuscados = ctx.Categorias.Find(id);

            if (categoriaBuscados.IdCategorias != null)
            {
                // Atribui os novos valores aos campos existentes
                categoriaBuscados.IdCategorias = CategoriaAtualizada.IdCategorias;
            }

            if (categoriaBuscados.NomeCategoria != null)
            {
                // Atribui os novos valores aos campos existentes
                categoriaBuscados.NomeCategoria = CategoriaAtualizada.NomeCategoria;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.Categorias.Update(categoriaBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Categoria BuscarPeloNome(string nome)
        {
            return ctx.Categorias.FirstOrDefault(u => u.NomeCategoria == nome);
        }

        public Categoria BuscarPorId(int id)
        {
            return ctx.Categorias.FirstOrDefault(u => u.IdCategorias == id);
        }

        public void Cadastrar(Categoria novaCategoria)
        {
            // Adiciona este novoUsuariol
            ctx.Categorias.Add(novaCategoria);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            Categoria categoriaBuscados = ctx.Categorias.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.Categorias.Remove(categoriaBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Categoria> Listar()
        {
            return ctx.Categorias.ToList();
        }
    }
}
