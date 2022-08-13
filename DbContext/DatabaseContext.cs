using Microsoft.EntityFrameworkCore;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnType("char(36)");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
                
                entity.Property(e => e.Email)
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}