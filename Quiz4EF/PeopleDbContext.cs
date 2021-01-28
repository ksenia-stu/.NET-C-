using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz4EF
{
    class PeopleDbContext : DbContext
    {
        public PeopleDbContext() : base("Quiz4EF") { }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Passport> Passports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passport>()
            .HasRequired(pass => pass.Person)
            .WithOptional(pers => pers.Passport);
        }
    }
}
