using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Quest_WebApi.Domains;

#nullable disable

namespace Quest_WebApi.Contexts
{
    public partial class QuestContext : DbContext
    {
        public QuestContext()
        {
        }

        public QuestContext(DbContextOptions<QuestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Partida> Partida { get; set; }
        public virtual DbSet<Pergunta> Perguntas { get; set; }
        public virtual DbSet<PerguntasUsuario> PerguntasUsuarios { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPartida> UsuarioPartida { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseSqlServer("Data Source=DESKTOP-QP4FDS5; initial catalog=Quest; Integrated Security=True;");
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategorias)
                    .HasName("PK__Categori__0185FF072F838A9B");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partida>(entity =>
            {
                entity.HasKey(e => e.IdPartida)
                    .HasName("PK__Partida__6ED660C74033EBF9");
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.HasKey(e => e.IdPergunta)
                    .HasName("PK__Pergunta__6DC6D9A72829ECB4");

                entity.Property(e => e.Alternativa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Perguntas)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Resposta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__Perguntas__IdTem__3D5E1FD2");
            });

            modelBuilder.Entity<PerguntasUsuario>(entity =>
            {
                entity.HasKey(e => e.IdPerguntasUsuario)
                    .HasName("PK__Pergunta__F19B088F0F2E0861");

                entity.ToTable("PerguntasUsuario");

                entity.HasOne(d => d.IdPartidaNavigation)
                    .WithMany(p => p.PerguntasUsuarios)
                    .HasForeignKey(d => d.IdPartida)
                    .HasConstraintName("FK__Perguntas__IdPar__2C3393D0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PerguntasUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Perguntas__IdUsu__2D27B809");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__Temas__9F3A411709101DE5");

                entity.Property(e => e.NomeTema)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriasNavigation)
                    .WithMany(p => p.Temas)
                    .HasForeignKey(d => d.IdCategorias)
                    .HasConstraintName("FK__Temas__IdCategor__34C8D9D1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97AC411398");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioPartida>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioPartida)
                    .HasName("PK__UsuarioP__5A168A527F99C43C");

                entity.HasOne(d => d.IdPartidaNavigation)
                    .WithMany(p => p.UsuarioPartida)
                    .HasForeignKey(d => d.IdPartida)
                    .HasConstraintName("FK__UsuarioPa__IdPar__29572725");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioPartida)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__UsuarioPa__IdUsu__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
