using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Context : DbContext
    {
        //private readonly string connectionString;
        //public Context() : base("Server=A-104-13;Database=MyBank;Trusted_Connection=True;")
        //{
        //}
        //public DbSet<Client> Clients { get; set; }
        
            public Context()
                : base("DbConnection")
            { }

            public DbSet<Client> Clients { get; set; }
        
    }
}
