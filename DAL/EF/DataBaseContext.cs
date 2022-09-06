using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            Database.Migrate();
        }
        public DbSet<OfficeEntity> OfficeEntity { get; set; }
        public DbSet<EmployeeEntity> EmployeeEntity { get; set; }
    }
}
