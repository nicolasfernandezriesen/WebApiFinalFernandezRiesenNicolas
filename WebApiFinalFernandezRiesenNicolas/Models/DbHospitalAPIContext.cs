using Microsoft.EntityFrameworkCore;


namespace WebApiFinalFernandezRiesenNicolas.Models
{
    public class DbHospitalAPIContext : DbContext
    {
        public DbHospitalAPIContext(DbContextOptions<DbHospitalAPIContext> options) : base(options){ }

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
