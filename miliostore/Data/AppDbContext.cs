using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using miliostore.Model;

namespace miliostore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter()
                : base(dateOnly =>
                        dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime))
            { }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");

            // Relacionamento Produto -> Categoria
            _ = modelBuilder.Entity<Produto>()
                .HasOne(_ => _.Categoria)
                .WithMany(t => t.Produto)
                .HasForeignKey("CategoriaId")
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento Postagem -> User
            _ = modelBuilder.Entity<Produto>()
                .HasOne(_ => _.Usuario)
                .WithMany(u => u.Produto)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }

        //Registrar DbSet - Objeto responsavel por manipular a Tabela

        public DbSet<Produto> Produtos { get; set; } = null!;

        public DbSet<Categoria> Categorias { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;
    }
}
