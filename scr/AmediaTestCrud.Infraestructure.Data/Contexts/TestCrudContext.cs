using AmediaTestCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmediaTestCrud.Infraestructure.Data.Contexts;

public partial class TestCrudContext : DbContext
{
    public TestCrudContext()
    {
    }

    public TestCrudContext(DbContextOptions<TestCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tRol__F13B12112810ED5C");

            entity.ToTable("tRol");

            entity.Property(e => e.Id).HasColumnName("cod_rol");
            entity.Property(e => e.Active).HasColumnName("sn_activo");
            entity.Property(e => e.Description).HasColumnName("txt_desc");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__tUsers__EA3C9B1AACDCE491");

            entity.ToTable("tUsers");

            entity.Property(e => e.Id).HasColumnName("cod_usuario");
            entity.Property(e => e.RoleId).HasColumnName("cod_rol");
            entity.Property(e => e.Document).HasColumnName("nro_doc");
            entity.Property(e => e.Active).HasColumnName("sn_activo");
            entity.Property(e => e.LastName).HasColumnName("txt_apellido");
            entity.Property(e => e.FirstName).HasColumnName("txt_nombre");
            entity.Property(e => e.Password).HasColumnName("txt_password");
            entity.Property(e => e.UserName).HasColumnName("txt_user");
        });
    }
}