using static netwinCrudOperation.Models.SchoolModel;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace netwinCrudOperation.Models
{
    public class SchoolDBContext
    {
       public SchoolDBContext(DbContextOptions options) : base (options)
        {
        }


        public DbSet<School> schools { get; set; }

        internal void Remove(School? res)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

