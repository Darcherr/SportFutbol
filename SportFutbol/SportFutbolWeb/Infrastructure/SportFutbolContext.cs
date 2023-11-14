using Microsoft.EntityFrameworkCore;
using SportFutbolWeb.Domain.Entities;

namespace SportFutbolWeb.Infrastructure
{
    public partial class SportFutbolContext : DbContext
    {
        public SportFutbolContext()
        {
        }

        public SportFutbolContext(DbContextOptions<SportFutbolContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Cancha> Canchas { get; set; }
        public virtual DbSet<TipoCancha> TipoCanchas { get; set; }
        public virtual DbSet<Tarifa> Tarifas { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }

    }
}
