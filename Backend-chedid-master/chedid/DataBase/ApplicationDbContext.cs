using chedid.Models;
using Microsoft.EntityFrameworkCore;

namespace chedid.DataBase
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quotation> Quotation { get; set; }
    }
}
