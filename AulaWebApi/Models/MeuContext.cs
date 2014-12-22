using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AulaWebApi.Models
{
    public class MeuContext : DbContext
    {
        public MeuContext() : base("name=MeuContext")
        {
        }

        public System.Data.Entity.DbSet<AulaWebApi.Models.Usuario> Usuarios { get; set; }


    }
}