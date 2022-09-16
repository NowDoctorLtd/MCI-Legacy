using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mci_main.Models
{
    // Sneed's
    public static class SeedData //Formerly Chuck's
    {
        public static void Initialise(IServiceProvider provider)
        { 
            using (var ctx = new MciContext(
               provider.GetRequiredService<DbContextOptions<MciContext>>()))
            { 
                // Edit to match expected specialisations in sample data
                if (!ctx.Specialisation.Any()) {
                    ctx.AddRange(
                        new Specialty
                        {
                            Title = "orthopaedics",
                            LongDescription = "None§",
                            ShortDesc = "n"
                        },
                        new Specialty
                        {
                            Title = "pharmacy",
                            LongDescription = "drugs in mugs",
                            ShortDesc = "drugs"
                        },
                        new Specialty
                        {
                            Title = "psychiatry",
                            LongDescription = "mind to unwind",
                            ShortDesc = "mentalist"
                        }
                    );
                }
                /*
                if (ctx.Practitioner.Any())
                {
                    Console.WriteLine("Startup: Database already seeded and feeded!");
                    return; 
                }
                */

                if (!ctx.Practitioner.Any())
                {
                    ctx.AddRange(
                        new Practitioner
                        {
                            Name = "Emmert Brown",
                            Title = Title.Dr,
                            Bio = "flux capacator",
                            Location = "hill valley",
                        },
                        new Practitioner
                        {
                            Name = "Dre",
                            Title = Title.Dr,
                            Bio = "not forgotten",
                            Location = "east side",
                            Specialties = new List<Specialty>().Where(x => x.Title.Equals("orthopaedics")).ToList()
                        },
                        new Practitioner
                        {
                            Name = "Foo",
                            Title = Title.Dr,
                            Location = "bar",
                            Bio = "baz",
                        },
                        new Practitioner
                        {
                            Name = "Bombay",
                            Title = Title.Dr,
                            Location = "calcutta",
                            Bio = "rice and curry in a hurry",
                        },
                        new Practitioner
                        {
                            Name = "Evil",
                            Title = Title.Dr,
                            Location = "space",
                            Bio = "works for One Million Dollars",
                        },
                        new Practitioner
                        {
                            Name = "william mccrea",
                            Title = Title.Dr,
                            Location = "magherafelt",
                            Bio = "the true gosepl says buy my albums (kjv only)++",
                        }
                    );
                }

                ctx.SaveChanges();
            }
        }
    }
}

