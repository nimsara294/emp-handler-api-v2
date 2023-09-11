using Microsoft.EntityFrameworkCore;

namespace emp_handler_api_v2.EmpHandler.Persistance.Models
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {

        }

        public DbSet<Departments> Departments { get; set; }
    }
}
