using Microsoft.EntityFrameworkCore;
using mci_main.Data;

public class MciContext : DbContext
{
    public MciContext(DbContextOptions<MciContext> options)
        : base(options)
    {
    }

    public DbSet<Practitioner> Practitioner { get; set; } = default!;
    public DbSet<Specialty> Specialty { get; set; } = default!;
    public virtual List<PractitionerSpecialty> PractitionerSpecialties { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PractitionerSpecialty>()
            .HasOne(ps => ps.Practitioner)
            .WithMany(ps => ps.PractitionerSpecialties)
            .HasForeignKey(ps => ps.PracIdx)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PractitionerSpecialty>()
            .HasOne(ps => ps.Specialty)
            .WithMany(ps => ps.PractitionerSpecialties)
            .HasForeignKey(ps => ps.SpecIdx)
            .OnDelete(DeleteBehavior.Cascade);

        // Which models will have the date created ts?
        modelBuilder.Entity<Practitioner>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Specialty>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

    }
}
