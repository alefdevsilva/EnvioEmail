using Microsoft.EntityFrameworkCore;

namespace Infra.Entidade
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<SolicitacaoEmail> SolicitacaoEmail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());
        }
        private string GetStringConnectionConfig()
        {
            string strCon = "Server=localhost\\SQLEXPRESS;Database=FilaEmail;Trusted_Connection=True;";
            return strCon;
        }
    }
}
