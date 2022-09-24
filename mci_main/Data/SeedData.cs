using mci_main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mci_main.Data
{
    // Sneed's
    public static class SeedData //Formerly Chuck's
    {
        public static void Initialise(IServiceProvider provider)
        {
            using (var ctx = new MciContext(
               provider.GetRequiredService<DbContextOptions<MciContext>>()))
            {
                if (!ctx.Specialty.Any())
                {
                    ctx.AddRange(
                        new Specialty
                        {
                            Title = "Orthopaedics",
                            LongDescription = "these go to eleven",
                            ShortDesc = "spinal crap"
                        },
                        new Specialty
                        {
                            Title = "Pharmacy",
                            LongDescription = "drugs in mugs",
                            ShortDesc = "drugs"
                        },
                        new Specialty
                        {
                            Title = "Psychiatry",
                            LongDescription = "mind to unwind",
                            ShortDesc = "mentalist"
                        },
                        new Specialty
                        {
                            Title = "Cardiology",
                            LongDescription = "time is the rhythm of the heart",
                            ShortDesc = "heart doctor"
                        }
                    );
                }
                if (!ctx.Practitioner.Any())
                {
                    ctx.AddRange(
                        new Practitioner
                        {
                            Name = "Emmert Brown",
                            Title = Title.Dr,
                            Bio = "flux capacator",
                            Location = "hill valley",
                            DOB = new DateTime(1932, 07, 08)
                        },
                        new Practitioner
                        {
                            Name = "Dre",
                            Title = Title.Dr,
                            Bio = "not forgotten",
                            Location = "east side",
                            DOB = new DateTime(1972, 06, 19)
                        },
                        new Practitioner
                        {
                            Name = "Foo",
                            Title = Title.Dr,
                            Location = "bar",
                            Bio = "baz",
                            DOB = new DateTime(2030, 12, 12)
                        },
                        new Practitioner
                        {
                            Name = "Bombay",
                            Title = Title.Dr,
                            Location = "calcutta",
                            Bio = "rice and curry in a hurry",
                            DOB = new DateTime(1979, 09, 23)
                        },
                        new Practitioner
                        {
                            Name = "Evil",
                            Title = Title.Dr,
                            Location = "space",
                            Bio = "works for One Million Dollars",
                            DOB = new DateTime(1945, 08, 01),
                        },
                        new Practitioner
                        {
                            Name = "william mccrea",
                            Title = Title.Dr,
                            Location = "magherafelt",
                            Bio = "the true gosepl says buy my albums (kjv only)++",
                            DOB = new DateTime(1901, 01, 07)
                        }
                    );
                }
                // NEED TO ASSOCIATE PRACS TO SPECS MANUALLY
                ctx.SaveChanges();
            }
        }
    }
}

