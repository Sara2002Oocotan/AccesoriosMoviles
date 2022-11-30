using AccesoriosMoviles.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoriosMoviles.AccesoADatos
{
    public class DBContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=ALVARO123;Initial Catalog = AccesoriosMoviles;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=AccesoriosMoviles.mssql.somee.com; Initial Catalog = AccesoriosMoviles; user id=sara_SQLLogin_1; pwd=te49asvr9m");
        }
    }
}

