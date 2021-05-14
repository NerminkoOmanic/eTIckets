using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<PodKategorija> PodKategorija { get; set; }
        public virtual DbSet<Slika> Slika { get; set; }
        public virtual DbSet<Spol> Spol { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Transakcija> Transakcija { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=localhost,1434;Initial Catalog=IB3012; User=sa; Password=qweASD123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grad_Drzava");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Komentar>(entity =>
            {
                entity.Property(e => e.KomentarId).HasColumnName("KomentarID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Komentar1)
                    .IsRequired()
                    .HasColumnName("Komentar")
                    .HasMaxLength(300);

                entity.Property(e => e.KomentatorId).HasColumnName("KomentatorID");

                entity.Property(e => e.KomentiraniId).HasColumnName("KomentiraniID");

                entity.Property(e => e.TransakcijaId).HasColumnName("TransakcijaID");

                entity.HasOne(d => d.Komentator)
                    .WithMany(p => p.KomentarKomentator)
                    .HasForeignKey(d => d.KomentatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_Komentator");

                entity.HasOne(d => d.Komentirani)
                    .WithMany(p => p.KomentarKomentirani)
                    .HasForeignKey(d => d.KomentiraniId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_KomentantiraniKorisnik");

                entity.HasOne(d => d.Transakcija)
                    .WithMany(p => p.Komentar)
                    .HasForeignKey(d => d.TransakcijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_Transakcija");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("CK_Email")
                    .IsUnique();

                entity.HasIndex(e => e.KorisnickoIme)
                    .HasName("CK_KorisnickoIme")
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
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_Grad");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.SpolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_Spol");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_Uloga");
            });

            modelBuilder.Entity<PodKategorija>(entity =>
            {
                entity.Property(e => e.PodKategorijaId).HasColumnName("PodKategorijaID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.PodKategorija)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PodKategorija_Kategorija");
            });

            modelBuilder.Entity<Slika>(entity =>
            {
                entity.Property(e => e.SlikaId).HasColumnName("SlikaID");

                entity.Property(e => e.Slika1)
                    .IsRequired()
                    .HasColumnName("Slika");
            });

            modelBuilder.Entity<Spol>(entity =>
            {
                entity.Property(e => e.SpolId).HasColumnName("SpolID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
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
                    .WithMany(p => p.TicketAdmin)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Ulaznica_Admin");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_Grad");

                entity.HasOne(d => d.PodKategorija)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.PodKategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_PodKategorija");

                entity.HasOne(d => d.Prodavac)
                    .WithMany(p => p.TicketProdavac)
                    .HasForeignKey(d => d.ProdavacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_Prodavac");

                entity.HasOne(d => d.Slika)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.SlikaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulaznica_Slika");
            });

            modelBuilder.Entity<Transakcija>(entity =>
            {
                entity.Property(e => e.TransakcijaId).HasColumnName("TransakcijaID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Transakcija)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transakcija_Kupac");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Transakcija)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transakcija_Ulaznica");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<eTickets.Model.Drzava> Drzava_1 { get; set; }

        public DbSet<eTickets.Model.Grad> Grad_1 { get; set; }
    }
}
