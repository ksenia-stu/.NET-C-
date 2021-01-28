using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10FirstEF
{
    class SocietyDbContext : DbContext
    {
       // public SocietyDbContext() : base("Day10FirstEF") { }   //to fix problem

        virtual public DbSet<Person> People { get; set; }
    }
}
