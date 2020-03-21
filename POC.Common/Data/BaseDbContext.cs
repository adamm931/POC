using POC.Common.Connection;
using POC.Common.Domain;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Common.Data
{
    public abstract class BaseDbContext<TDbContext> : DbContext, IUnitOfWork where TDbContext : DbContext
    {
        protected BaseDbContext(
            IConnectionString connectionString,
            IDatabaseInitializer<TDbContext> databaseInitializer)
            : base(connectionString.Value)
        {
            Database.SetInitializer(databaseInitializer);
        }

        public async Task Save()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(TDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
