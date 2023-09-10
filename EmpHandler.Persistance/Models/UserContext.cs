using Microsoft.EntityFrameworkCore;

namespace emp_handler_api_v2.EmpHandler.Persistance.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
    }
}
