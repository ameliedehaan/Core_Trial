using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KunstBeach_ClassLibrary
{
    public partial class TussenkunstenbeachContext : DbContext
    {
        public TussenkunstenbeachContext()
        {
        }

        public TussenkunstenbeachContext(DbContextOptions<TussenkunstenbeachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artists");

                entity.Property(e => e.ArtistId).HasColumnName("Artist_ID");

                entity.Property(e => e.ArtistBirth).HasColumnName("Artist_Birth");

                entity.Property(e => e.ArtistDeath).HasColumnName("Artist_Death");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasColumnName("Artist_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("places");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("Place_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtistId).HasColumnName("Artist_ID");

                entity.Property(e => e.PlaceName)
                    .IsRequired()
                    .HasColumnName("Place_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkId).HasColumnName("Work_ID");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_places_artists");

                entity.HasOne(d => d.PlaceNavigation)
                    .WithOne(p => p.Place)
                    .HasForeignKey<Place>(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_places_works");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("works");

                entity.Property(e => e.WorkId).HasColumnName("Work_ID");

                entity.Property(e => e.ArtistId).HasColumnName("Artist_ID");

                entity.Property(e => e.WorkName)
                    .IsRequired()
                    .HasColumnName("Work_Name")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.WorkYear).HasColumnName("Work_Year");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_works_artists");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}