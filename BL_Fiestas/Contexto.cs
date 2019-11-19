using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{
    public class Contexto: DbContext
    {
        public Contexto() : base("Reserva")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }

        public DbSet<ReservaBL.Reserva> Reserva { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
