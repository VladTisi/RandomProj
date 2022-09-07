using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RandomProj.Models
{
    public partial class PrisonBreakContext : DbContext
    {
        public PrisonBreakContext()
        {
        }

        public PrisonBreakContext(DbContextOptions<PrisonBreakContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Angajat> Angajats { get; set; } = null!;
        public virtual DbSet<Concediu> Concedius { get; set; } = null!;
        public virtual DbSet<Echipa> Echipas { get; set; } = null!;
        public virtual DbSet<Functie> Functies { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<StareConcediu> StareConcedius { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<TipConcediu> TipConcedius { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =ts2112\\SQLEXPRESS; Database =PrisonBreak; User Id =internship2022; Password =int; MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angajat>(entity =>
            {
                entity.ToTable("Angajat");

                entity.Property(e => e.Cnp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNP");

                entity.Property(e => e.DataAngajarii)
                    .HasColumnType("date")
                    .HasColumnName("Data_angajarii");

                entity.Property(e => e.DataNasterii)
                    .HasColumnType("date")
                    .HasColumnName("Data_nasterii");

                entity.Property(e => e.EsteAdmin)
                    .HasColumnName("esteAdmin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NrBuletin)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Nr_buletin");

                entity.Property(e => e.NumarTelefon)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Numar_telefon");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Poza)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('/9j/4AAQSkZJRgABAQACWAJYAAD/2wCEAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDIBCQkJDAsMGA0NGDIhHCEyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMv/CABEIAMgAyAMBIgACEQEDEQH/xAAtAAEAAwEBAQAAAAAAAAAAAAAAAwQFAgEHAQEBAAAAAAAAAAAAAAAAAAAAAf/aAAwDAQACEAMQAAAA+vCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZpcpVRJJXF65i9G2ilAAAAAAAAKNCSMCgALGrhbkegAAAAAAc9cGKKAAAbeJsxIAAAAAABBPRKAoAABrZN+LwAAAAAAFW1yYiaGgAAGnS1Y6AAAAAAABWy93JIBQAnLtkgAAAAAAABSs5xXFANDPsRqo5AAAAAAA4ql2PMhJoSgAAJtPGRusi0XXHYAABHncwgUAAAAAAAsVxsyZGvADkMQUAAAAAAAAA2yOgf/8QAMRAAAQIDBAgGAQUAAAAAAAAAAQIDBBEhABIwUQUTIDEyQEFhIjNScXKBEBRDU3CR/9oACAEBAAE/AP6gdiWmhVQKvSN9nI91VESQO2+36h7+Vf8AtkRr6d6gr5CyNIqn42wRmmzTyHhNBnmOo5IkAEkyAtExhWbjRkjqc9pC1NrCkGRFmHg+3eFCKEZHkdIOkANA76qwIN3VvgT8KqHkYhzWvrV0nIe2BOVbJM0A5jHWZIUcgThIM20nsMd7yHPicJjyG/iMeKdS20Qqc1AgSwoV1DjQCZzSADPH0l+2ffC0ducPtjx6L0Pe9JnhQCLsPe9RnjrQHEKQrcRI2iIcw6wJzBEwZYEPDmIWROQAmTKyEBtCUJ3ASHIRrWsYmN6a/WBBNatiZ3qr9clFMahynCqo2oVjXu14U1Pfk9I+W38jtaO8tz5DknHkNJmtQGQ6m0VEh8gBMkpz67ULE6gqBSSlWXSzbyHUzQoHMdRyDsQ01xLE8hU2iXg+7fAIEpVwIZ4MO3yCRKVLNRDTvCsTyNDiLeba41gdutnNIIFG0FXc0s5FvOb1SGSaYjcW83uVMZKrZvSCDRxBT3FbIebd4Fg9uu288hhF5X0M7OxjrlAbick8k1GOt0JvpyVZl5D6LyfsZbMS6Xn1GdBQe3KQzpafSZ0ND7bCzdbUcgTyyDebScwD+P/EABQRAQAAAAAAAAAAAAAAAAAAAHD/2gAIAQIBAT8AKf/EABQRAQAAAAAAAAAAAAAAAAAAAHD/2gAIAQMBAT8AKf/Z')");

                entity.Property(e => e.Prenume)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SalariuVizibil)
                    .HasColumnName("salariuVizibil")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SerieBuletin)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("Serie_buletin");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SexVizbil)
                    .HasColumnName("sexVizbil")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Echipa)
                    .WithMany(p => p.Angajats)
                    .HasForeignKey(d => d.IdEchipa)
                    .HasConstraintName("FK__Angajat__IdEchip__797309D9");

                entity.HasOne(d => d.Functie)
                    .WithMany(p => p.Angajats)
                    .HasForeignKey(d => d.IdFunctie)
                    .HasConstraintName("FK__Angajat__IdFunct__787EE5A0");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Angajats)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Angajat__LoginId__73BA3083");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Angajat__Manager__75A278F5");
            });

            modelBuilder.Entity<Concediu>(entity =>
            {
                entity.ToTable("Concediu");


                entity.Property(e => e.Comentarii).HasMaxLength(1);

                entity.Property(e => e.DataInceput)
                    .HasColumnType("date")
                    .HasColumnName("Data_inceput");

                entity.Property(e => e.DataSfarsit)
                    .HasColumnType("date")
                    .HasColumnName("Data_sfarsit");

                entity.Property(e => e.StareConcediuId).HasColumnName("stareConcediuId");

                entity.HasOne(d => d.Angajat)
                    .WithMany(p => p.Concedius)
                    .HasForeignKey(d => d.AngajatId)
                    .HasConstraintName("FK__Concediu__angaja__7F2BE32F");


                entity.HasOne(d => d.Inlocuitor)
                    .WithMany(p => p.ConcediuInlocuitors)
                    .HasForeignKey(d => d.InlocuitorId)
                    .HasConstraintName("FK__Concediu__Inlocu__7D439ABD");

                entity.HasOne(d => d.StareConcediu)
                    .WithMany(p => p.Concedius)
                    .HasForeignKey(d => d.StareConcediuId)
                    .HasConstraintName("FK__Concediu__stareC__7E37BEF6");

                entity.HasOne(d => d.TipConcediu)
                    .WithMany(p => p.Concedius)
                    .HasForeignKey(d => d.TipConcediuId)
                    .HasConstraintName("FK__Concediu__TipCon__7C4F7684");
            });

            modelBuilder.Entity<Echipa>(entity =>
            {
                entity.ToTable("Echipa");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Functie>(entity =>
            {
                entity.ToTable("Functie");

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("images");

                entity.Property(e => e.Imagine).HasColumnName("imagine");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Parola)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Angajat)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.AngajatId)
                    .HasConstraintName("FK__Login__AngajatId__03F0984C");
            });

            modelBuilder.Entity<StareConcediu>(entity =>
            {
                entity.ToTable("StareConcediu");

                entity.Property(e => e.Cod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("TEST");

                entity.Property(e => e.Angajatid).HasColumnName("angajatid");

                entity.Property(e => e.DataInceput)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Inceput");

                entity.Property(e => e.DataSfarsit)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Sfarsit");

                entity.Property(e => e.StareConcediuid).HasColumnName("stareConcediuid");
            });

            modelBuilder.Entity<TipConcediu>(entity =>
            {
                entity.ToTable("TipConcediu");

                entity.Property(e => e.Cod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nume)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
