using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Quest_WebApi.DbModels
{
    public partial class QuestContext : DbContext
    {

        protected readonly IConfiguration Configuration;
        public QuestContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public QuestContext()
        {
        }

        public QuestContext(DbContextOptions<QuestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Partida> Partida { get; set; }
        public virtual DbSet<PerguntaUsuario> PerguntaUsuarios { get; set; }
        public virtual DbSet<Perguntas> Pergunta { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPartida> UsuarioPartida { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("pk_categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome_categoria");
            });

            modelBuilder.Entity<Partida>(entity =>
            {
                entity.HasKey(e => e.IdPartida)
                    .HasName("pk_partida");

                entity.Property(e => e.IdPartida).HasColumnName("id_partida");

                entity.Property(e => e.Pontuacao).HasColumnName("pontuacao");
            });

            modelBuilder.Entity<PerguntaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("pk_usuariopartida");

                entity.ToTable("PerguntaUsuario");

                entity.Property(e => e.IdRegistro).HasColumnName("id_registro");

                entity.Property(e => e.IdPuPergunta).HasColumnName("id_pu_pergunta");

                entity.Property(e => e.IdPuUsuarioPartida).HasColumnName("id_pu_usuario_partida");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdPuPerguntaNavigation)
                    .WithMany(p => p.PerguntaUsuarios)
                    .HasForeignKey(d => d.IdPuPergunta)
                    .HasConstraintName("fk_pergunta");

                entity.HasOne(d => d.IdPuUsuarioPartidaNavigation)
                    .WithMany(p => p.PerguntaUsuarios)
                    .HasForeignKey(d => d.IdPuUsuarioPartida)
                    .HasConstraintName("fk_usuario_partida");
            });

            modelBuilder.Entity<Perguntas>(entity =>
            {
                entity.HasKey(e => e.IdPergunta)
                    .HasName("pk_pergunta");

                entity.Property(e => e.IdPergunta).HasColumnName("id_pergunta");

                entity.Property(e => e.Alternativas)
                    .IsRequired()
                    .HasColumnType("character varying[]")
                    .HasColumnName("alternativas");

                entity.Property(e => e.IdPTema).HasColumnName("id_p_tema");

                entity.Property(e => e.Pergunta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("pergunta");

                entity.Property(e => e.Reposta)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("reposta");

                entity.HasOne(d => d.IdPTemaNavigation)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.IdPTema)
                    .HasConstraintName("fk_tema");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("pk_tema");

                entity.ToTable("Tema");

                entity.Property(e => e.IdTema).HasColumnName("id_tema");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.NomeTema)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome_tema");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Temas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_id_categoria");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("pk_usuario");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("senha");
            });

            modelBuilder.Entity<UsuarioPartida>(entity =>
            {
                entity.HasKey(e => e.IdUsuariioPartida)
                    .HasName("pk_usuario_partida");

                entity.Property(e => e.IdUsuariioPartida).HasColumnName("id_usuariio_partida");

                entity.Property(e => e.IdUpPartida).HasColumnName("id_up_partida");

                entity.Property(e => e.IdUpUsuario).HasColumnName("id_up_usuario");

                entity.Property(e => e.Resultado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("resultado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
