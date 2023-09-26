using Microsoft.EntityFrameworkCore;
using SIGEDESP.Models;

namespace SIGEDESP.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<tipoDespesaModel> Descricoes { get; set; }
    }
}
