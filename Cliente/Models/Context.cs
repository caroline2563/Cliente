using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cliente.Models
{
    public class Context : System.Data.Entity.DbContext

    {
        public DbSet<ClienteDB> Clientes { get; set; }


    }
}