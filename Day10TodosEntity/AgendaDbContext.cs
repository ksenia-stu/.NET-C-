using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10TodosEntity
{
    class AgendaDbContext : DbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }
    }
}
