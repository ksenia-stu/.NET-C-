using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11CarOwnersEF
{
    class CarOwnerDbContext : DbContext
    {
        // public CarOwnerDbContext() : base("Day11CarOwnersEF") { }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }
}
