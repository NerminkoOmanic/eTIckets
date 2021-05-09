using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class IB3012Context : DbContext
    {
        public IB3012Context()
        {
        }

        public IB3012Context(DbContextOptions<IB3012Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Grad> Grads { get; set; }
        public virtual DbSet<Kategorija> Kategorijas { get; set; }
        public virtual DbSet<Komentar> Komentars { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<PodKategorija> PodKategorijas { get; set; }
        public virtual DbSet<Slika> Slikas { get; set; }
        public virtual DbSet<Spol> Spols { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Transakcija> Transakcijas { get; set; }
        public virtual DbSet<Uloga> Ulogas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1434;Initial Catalog=IB3012; User=sa; Password=qweASD123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.ToTable("Drzava");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grad_Drzava");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.ToTable("Kategorija");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Komentar>(entity =>
            {
                entity.ToTable("Komentar");

                entity.Property(e => e.KomentarId).HasColumnName("KomentarID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Komentar1)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Komentar");

                entity.Property(e => e.KomentatorId).HasColumnName("KomentatorID");

                entity.Property(e => e.KomentiraniId).HasColumnName("KomentiraniID");

                entity.Property(e => e.TransakcijaId).HasColumnName("TransakcijaID");

                entity.HasOne(d => d.Komentator)
                    .WithMany(p => p.KomentarKomentators)
                    .HasForeignKey(d => d.KomentatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_Komentator");

                entity.HasOne(d => d.Komentirani)
                    .WithMany(p => p.KomentarKomentiranis)
                    .HasForeignKey(d => d.KomentiraniId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_KomentantiraniKorisnik");

                entity.HasOne(d => d.Transakcija)
                    .WithMany(p => p.Komentars)
                    .HasForeignKey(d => d.TransakcijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_Transakcija");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.HasIndex(e => e.Email, "CK_Email")
                    .IsUnique();

                entity.HasIndex(e => e.KorisnickoIme, "CK_KorisnickoIme")
                    .IsUnique();

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpolId).HasColumnName("SpolID");

                entity.Property(e => e.Telefon).HasMaxLength(20);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_Grad");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.SpolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_Spol");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_Uloga");
            });

            modelBuilder.Entity<PodKategorija>(entity =>
            {
                entity.ToTable("PodKategorija");

                entity.Property(e => e.PodKategorijaId).HasColumnName("PodKategorijaID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.PodKategorijas)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PodKategorija_Kategorija");
            });

            modelBuilder.Entity<Slika>(entity =>
            {
                entity.ToTable("Slika");

                entity.Property(e => e.SlikaId).HasColumnName("SlikaID");

                entity.Property(e => e.Slika1)
                    .IsRequired()
                    .HasColumnName("Slika");
            });

            modelBuilder.Entity<Spol>(entity =>
            {
                entity.ToTable("Spol");

                entity.Property(e => e.SpolId).HasColumnName("SpolID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.NazivDogadjaja)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PodKategorijaId).HasColumnName("PodKategorijaID");

                entity.Property(e => e.ProdavacId).HasColumnName("ProdavacID");

                entity.Property(e => e.Sektor).HasMaxLength(15);

                entity.Property(e => e.Sjedalo).HasMaxLength(30);

                entity.Property(e => e.SlikaId).HasColumnName("SlikaID");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.TicketAdmins)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Ulaznica_Admin");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_Grad");

                entity.HasOne(d => d.PodKategorija)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PodKategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_PodKategorija");

                entity.HasOne(d => d.Prodavac)
                    .WithMany(p => p.TicketProdavacs)
                    .HasForeignKey(d => d.ProdavacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_Prodavac");

                entity.HasOne(d => d.Slika)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SlikaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_Slika");
            });

            modelBuilder.Entity<Transakcija>(entity =>
            {
                entity.ToTable("Transakcija");

                entity.Property(e => e.TransakcijaId).HasColumnName("TransakcijaID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Transakcijas)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transakcija_Kupac");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Transakcijas)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transakcija_Ulaznica");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.ToTable("Uloga");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
