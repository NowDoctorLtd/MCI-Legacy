using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mci_main.Models;

public class MciContext : DbContext
{
    public MciContext (DbContextOptions<MciContext> options)
        : base(options)
    {
    }

    public DbSet<mci_main.Models.Practitioner> Practitioner { get; set; } = default!;
    public DbSet<mci_main.Models.Specialty> Specialisation { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Practitioner>()
            .HasMany(p => p.Specialties)
            .WithMany(p => p.Practitioners)
            .UsingEntity(j => j.ToTable("PractitionerSpecialty"));

        // SQLITE ONLY!!! use getdate() on sqls
        modelBuilder.Entity<Practitioner>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("date('now')");

    }
}
