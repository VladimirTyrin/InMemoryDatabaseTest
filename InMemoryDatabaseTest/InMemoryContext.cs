using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InMemoryDatabaseTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace InMemoryDatabaseTest
{
    public class InMemoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase();
            }
        }

        public DbSet<BaseEntity> BaseEntities { get; set; }
    }
}
