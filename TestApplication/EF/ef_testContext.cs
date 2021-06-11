using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestApplication
{
    public partial class ef_testContext : DbContext
    {
        public ef_testContext()
        {
        }

        public ef_testContext(DbContextOptions<ef_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ATable> ATables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=ef_test;uid=root;password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ATable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("a_table");

                entity.Property(e => e.SomeNumber)
                    .HasColumnType("smallint unsigned")
                    .HasColumnName("some_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
