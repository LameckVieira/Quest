using Microsoft.EntityFrameworkCore;
using Quest_WebApi.DbModels;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class UsuarioPartidaRepository : IUsuarioPartidaRepository
    {

        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, UsuarioPartida UsuarioPartidaAtualizada)
        {
            UsuarioPartida UsuarioParidaBuscado = ctx.UsuarioPartida.Find(id);

            if (UsuarioParidaBuscado.IdUsuariioPartida != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioParidaBuscado.IdUsuariioPartida = UsuarioPartidaAtualizada.IdUsuariioPartida;
            }

            if (UsuarioParidaBuscado.Resultado != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioParidaBuscado.Resultado = UsuarioPartidaAtualizada.Resultado;
            }

            if (UsuarioPartidaAtualizada.IdUpUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioParidaBuscado.IdUpUsuario = UsuarioPartidaAtualizada.IdUpUsuario;
            }

            if (UsuarioPartidaAtualizada.IdUpPartida != null)
            {
                // Atribui os novos valores aos campos existentes
                UsuarioParidaBuscado.IdUpPartida = UsuarioPartidaAtualizada.IdUpPartida;
            }

            // Atualiza o Usuariol que foi buscado
            ctx.UsuarioPartida.Update(UsuarioParidaBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Usuario BuscarPeloNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioPartida BuscarPorId(int id)
        {
            return ctx.UsuarioPartida.FirstOrDefault(u => u.IdUsuariioPartida == id);
        }

        public void Cadastrar(UsuarioPartida novaUsuarioPartida)
        {
            // Adiciona este novoUsuariol
            ctx.UsuarioPartida.Add(novaUsuarioPartida);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            UsuarioPartida UsuarioBuscados = ctx.UsuarioPartida.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.UsuarioPartida.Remove(UsuarioBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<UsuarioPartida> Listar()
        {
            return ctx.UsuarioPartida.ToList();
        }
    }
}
