using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using QuizApi.DataModels;

namespace QuizApi.DataContext
{
    public partial class QuizContext : DbContext
    {
        public QuizContext()
        {
        }

        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PlayerDetails> PlayerDetails { get; set; }
        public virtual DbSet<PlayerScore> PlayerScore { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Quiz;User Id=sa;Password=Pwd4db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerDetails>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__PlayerDe__4A4E74A8A359DA30");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("PlayerID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PlayerScore>(entity =>
            {
                entity.HasKey(e => e.ScoreId)
                    .HasName("PK__PlayerSc__7DD229F1644A8588");

                entity.Property(e => e.ScoreId).HasColumnName("ScoreID");

                entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerScore)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerSco__Playe__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
