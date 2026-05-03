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

    public DbSet<Court> Courts { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Debtor> Debtors { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<AccountChart> AccountCharts { get; set; }
    public DbSet<DefaultAttorneyTariff> DefaultAttorneyTariffs { get; set; }
    public DbSet<UserClientAccess> UserClientAccesses { get; set; }
    public DbSet<EnforcementCase> EnforcementCases { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Court
        builder.Entity<Court>(e =>
        {
            e.HasKey(x => x.CourtId);
            e.Property(x => x.Name).HasMaxLength(255);
            e.Property(x => x.City).HasMaxLength(255);
            e.Property(x => x.ShortName).HasMaxLength(255);
            e.Property(x => x.ShortFullName).HasMaxLength(255);
        });

        // Company
        builder.Entity<Company>(e =>
        {
            e.HasKey(x => x.CompanyId);
            e.Property(x => x.CompanyId).ValueGeneratedNever();
            e.Property(x => x.Name).HasMaxLength(255);
            e.Property(x => x.City).HasMaxLength(255);
            e.Property(x => x.Address).HasMaxLength(255);
            e.Property(x => x.TaxId).HasMaxLength(255);
        });

        // Debtor
        builder.Entity<Debtor>(e =>
        {
            e.HasKey(x => x.DebtorId);
            e.Property(x => x.CreditorReference).HasMaxLength(50);
            e.Property(x => x.FullName).HasMaxLength(1023);
            e.Property(x => x.City).HasMaxLength(1023);
            e.Property(x => x.Address).HasMaxLength(1023);
            e.Property(x => x.PersonalId).HasMaxLength(30);
            e.Property(x => x.RegistrationNumber).HasMaxLength(30);
            e.Property(x => x.IdCardNumber).HasMaxLength(50);
            e.Property(x => x.District).HasMaxLength(255);
            e.Property(x => x.RealEstate).HasMaxLength(511);
            e.Property(x => x.Vehicles).HasMaxLength(1023);
            e.Property(x => x.BankAccountNumbers).HasMaxLength(511);
            e.Property(x => x.Residence).HasMaxLength(1023);
        });

        // Client
        builder.Entity<Client>(e =>
        {
            e.HasKey(x => x.ClientId);
            e.Property(x => x.ClientId).ValueGeneratedNever();
            e.Property(x => x.Name).HasMaxLength(255);
            e.Property(x => x.Currency).HasMaxLength(10);
            e.Property(x => x.Address).HasMaxLength(255);
            e.Property(x => x.Address2).HasMaxLength(255);
            e.Property(x => x.City).HasMaxLength(255);
            e.Property(x => x.PostalCode).HasMaxLength(255);
            e.Property(x => x.Country).HasMaxLength(255);
            e.Property(x => x.BankAccount).HasMaxLength(50);
            e.Property(x => x.TaxId).HasMaxLength(50);
            e.Property(x => x.VatNumber).HasMaxLength(50);
            e.Property(x => x.VatRate).HasColumnType("decimal(15,3)");
        });

        // AccountChart
        builder.Entity<AccountChart>(e =>
        {
            e.HasKey(x => x.AccountNumber);
            e.Property(x => x.AccountNumber).HasMaxLength(15);
            e.Property(x => x.Name).HasMaxLength(255);
        });

        // DefaultAttorneyTariff
        builder.Entity<DefaultAttorneyTariff>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.TariffAmount).HasColumnType("decimal(15,2)");
            e.Property(x => x.TariffPercentage).HasColumnType("decimal(15,2)");
        });

        // UserClientAccess
        builder.Entity<UserClientAccess>(e =>
        {
            e.HasKey(x => new { x.UserName, x.ClientId });
            e.Property(x => x.UserName).HasMaxLength(256);
        });

        // EnforcementCase
        builder.Entity<EnforcementCase>(e =>
        {
            e.HasKey(x => x.CaseId);
            e.Property(x => x.CaseNumber).HasMaxLength(30);
            e.Property(x => x.DecisionNumber).HasMaxLength(30);
            e.Property(x => x.EnforcementNumber).HasMaxLength(30);
            e.Property(x => x.CourtOrderNumber).HasMaxLength(30);
            e.Property(x => x.MinorOffenseNumber).HasMaxLength(30);
            e.Property(x => x.ExecutionNumber).HasMaxLength(30);
            e.Property(x => x.RequestNumber).HasMaxLength(30);
            e.Property(x => x.JoinedUnderNumber).HasMaxLength(30);
            e.Property(x => x.Note).HasMaxLength(255);
            e.Property(x => x.DebtAmount).HasColumnType("decimal(15,2)");
            e.Property(x => x.AttorneyFee).HasColumnType("decimal(15,2)");
            e.Property(x => x.CourtFees).HasColumnType("decimal(15,2)");
            e.Property(x => x.CurrentDebt).HasColumnType("decimal(15,2)");
            e.Property(x => x.PaidAmount).HasColumnType("decimal(15,2)");
            e.Property(x => x.DebtAmountAfterObjection).HasColumnType("decimal(15,2)");
            e.Property(x => x.AttorneyFeeAfterObjection).HasColumnType("decimal(15,2)");
            e.Property(x => x.CourtFeesAfterObjection).HasColumnType("decimal(15,2)");
            e.Property(x => x.AdditionalAttorneyFee).HasColumnType("decimal(15,2)");
            e.Property(x => x.SuccessPercentage).HasColumnType("decimal(15,2)");
            e.Property(x => x.BillingPercentage).HasColumnType("decimal(15,2)");
        });
    }
}