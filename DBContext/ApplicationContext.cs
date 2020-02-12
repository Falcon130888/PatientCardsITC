using PatientCardsITC.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientCardsITC.DBContext
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<History> Histories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                 //optionsBuilder.UseSqlServer("data source=STAS;initial catalog=PatientCards; Integrated Security=True");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PatientCards;Username=postgres;Password=2030");
        }
    }
}
