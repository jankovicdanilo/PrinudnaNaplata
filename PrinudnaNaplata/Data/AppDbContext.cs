using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrinudnaNaplata.Domain;

namespace PrinudnaNaplata.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Sud> Sudovi { get; set; }
    public DbSet<Preduzece> Preduzeca { get; set; }
    public DbSet<Duznik> Duznici { get; set; }
    public DbSet<Klijent> Klijenti { get; set; }
    public DbSet<KontniPlan> KontniPlan { get; set; }
    public DbSet<PodrazumijevanaAdvokatskaTarifa> PodrazumijevaneAdvokatskeTarife { get; set; }
    public DbSet<PravaPristupaKlijent> PravaPristupaKlijent { get; set; }
    public DbSet<Partija> Partije { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ── Sud ───────────────────────────────────────────────────────────────
        builder.Entity<Sud>(e =>
        {
            e.HasKey(x => x.SudID);
            e.Property(x => x.Naziv).HasMaxLength(255);
            e.Property(x => x.Mjesto).HasMaxLength(255);
            e.Property(x => x.KratakNaziv).HasMaxLength(255);
            e.Property(x => x.KratakPuniNaziv).HasMaxLength(255);
        });

        // ── Preduzece ─────────────────────────────────────────────────────────
        builder.Entity<Preduzece>(e =>
        {
            e.HasKey(x => x.PreduzeceID);
            e.Property(x => x.PreduzeceID).ValueGeneratedNever();
            e.Property(x => x.Naziv).HasMaxLength(255);
            e.Property(x => x.Mjesto).HasMaxLength(255);
            e.Property(x => x.Adresa).HasMaxLength(255);
            e.Property(x => x.PIB).HasMaxLength(255);
        });

        // ── Duznik ────────────────────────────────────────────────────────────
        builder.Entity<Duznik>(e =>
        {
            e.HasKey(x => x.DuznikID);
            e.Property(x => x.ZavedenKodPov).HasMaxLength(50);
            e.Property(x => x.Ime).HasMaxLength(1023);
            e.Property(x => x.Mjesto).HasMaxLength(1023);
            e.Property(x => x.Adresa).HasMaxLength(1023);
            e.Property(x => x.JMBG).HasMaxLength(30);
            e.Property(x => x.RegBr).HasMaxLength(30);
            e.Property(x => x.LicniBroj).HasMaxLength(50);
            e.Property(x => x.Reon).HasMaxLength(255);
            e.Property(x => x.Nekretnina).HasMaxLength(511);
            e.Property(x => x.Vozila).HasMaxLength(1023);
            e.Property(x => x.BrojeviRacuna).HasMaxLength(511);
            e.Property(x => x.Prebivaliste).HasMaxLength(1023);

            // Duznik -> Preduzece (optional)
            e.HasOne<Preduzece>()
             .WithMany()
             .HasForeignKey(d => d.PreduzeceID)
             .OnDelete(DeleteBehavior.SetNull);
        });

        // ── Klijent ───────────────────────────────────────────────────────────
        builder.Entity<Klijent>(e =>
        {
            e.HasKey(x => x.KlijentID);
            e.Property(x => x.KlijentID).ValueGeneratedNever();
            e.Property(x => x.Naziv).HasMaxLength(255);
            e.Property(x => x.Valuta).HasMaxLength(10);
            e.Property(x => x.Adresa).HasMaxLength(255);
            e.Property(x => x.Adresa2).HasMaxLength(255);
            e.Property(x => x.Grad).HasMaxLength(255);
            e.Property(x => x.PostanskiBroj).HasMaxLength(255);
            e.Property(x => x.Zemlja).HasMaxLength(255);
            e.Property(x => x.Racun).HasMaxLength(50);
            e.Property(x => x.PIB).HasMaxLength(50);
            e.Property(x => x.PDV).HasMaxLength(50);
            e.Property(x => x.PDVStopa).HasColumnType("decimal(15,3)");
        });

        // ── KontniPlan ────────────────────────────────────────────────────────
        builder.Entity<KontniPlan>(e =>
        {
            e.HasKey(x => x.KontoBroj);
            e.Property(x => x.KontoBroj).HasMaxLength(15);
            e.Property(x => x.Naziv).HasMaxLength(255);
        });

        // ── PodrazumijevanaAdvokatskaTarifa ───────────────────────────────────
        builder.Entity<PodrazumijevanaAdvokatskaTarifa>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd();
            e.Property(x => x.Tarifa).HasColumnType("decimal(15,2)");
            e.Property(x => x.TarifaProcenat).HasColumnType("decimal(15,2)");

            // -> Klijent (optional)
            e.HasOne<Klijent>()
             .WithMany()
             .HasForeignKey(d => d.KlijentID)
             .OnDelete(DeleteBehavior.SetNull);
        });

        // ── PravaPristupaKlijent ──────────────────────────────────────────────
        builder.Entity<PravaPristupaKlijent>(e =>
        {
            e.HasKey(x => new { x.UserName, x.KlijentID });
            e.Property(x => x.UserName).HasMaxLength(256);

            // -> Klijent
            e.HasOne<Klijent>()
             .WithMany()
             .HasForeignKey(u => u.KlijentID)
             .OnDelete(DeleteBehavior.Cascade);

            // -> AspNetUsers
            e.HasOne<IdentityUser>()
             .WithMany()
             .HasForeignKey(u => u.UserName)
             .HasPrincipalKey(u => u.UserName)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // ── Partija ───────────────────────────────────────────────────────────
        builder.Entity<Partija>(e =>
        {
            e.HasKey(x => x.PartijaID);
            e.Property(x => x.BrojPartije).HasMaxLength(30);
            e.Property(x => x.ResenjeBroj).HasMaxLength(30);
            e.Property(x => x.IVb).HasMaxLength(30);
            e.Property(x => x.Pb).HasMaxLength(30);
            e.Property(x => x.MalBroj).HasMaxLength(30);
            e.Property(x => x.IpvBroj).HasMaxLength(30);
            e.Property(x => x.RBroj).HasMaxLength(30);
            e.Property(x => x.SpojenUIBroj).HasMaxLength(30);
            e.Property(x => x.Napomena).HasMaxLength(255);
            e.Property(x => x.IznosDuga).HasColumnType("decimal(15,2)");
            e.Property(x => x.AdvTarifa).HasColumnType("decimal(15,2)");
            e.Property(x => x.SudskeTakse).HasColumnType("decimal(15,2)");
            e.Property(x => x.TrenutniDug).HasColumnType("decimal(15,2)");
            e.Property(x => x.PlatioIznos).HasColumnType("decimal(15,2)");
            e.Property(x => x.IznosPoPrigovoru).HasColumnType("decimal(15,2)");
            e.Property(x => x.ATPoPrigovoru).HasColumnType("decimal(15,2)");
            e.Property(x => x.TaksaPoPrigovoru).HasColumnType("decimal(15,2)");
            e.Property(x => x.DodatniAT).HasColumnType("decimal(15,2)");
            e.Property(x => x.ProcenatUspjeha).HasColumnType("decimal(15,2)");
            e.Property(x => x.FakturisanoProcenat).HasColumnType("decimal(15,2)");

            // Partija -> Duznik
            e.HasOne<Duznik>()
             .WithMany()
             .HasForeignKey(p => p.DuznikID)
             .OnDelete(DeleteBehavior.Restrict);

            // Partija -> Klijent
            e.HasOne<Klijent>()
             .WithMany()
             .HasForeignKey(p => p.KlijentID)
             .OnDelete(DeleteBehavior.Restrict);

            // Partija -> Sud (primary)
            e.HasOne<Sud>()
             .WithMany()
             .HasForeignKey(p => p.SudID)
             .OnDelete(DeleteBehavior.SetNull);

            // Partija -> Sud (secondary)
            e.HasOne<Sud>()
             .WithMany()
             .HasForeignKey(p => p.Sud1ID)
             .OnDelete(DeleteBehavior.NoAction);
        });
    }
}