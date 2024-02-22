
namespace Tadbir.Ins.Persistence.DataBaseContext
{
    public class TadbirInsuranceContext : DbContext
    {
        public DbSet<InsuranceCoverage> InsuranceCoverages { get; set; }
        public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
        public DbSet<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; }
        public TadbirInsuranceContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InsuranceCoverageConfig());
            modelBuilder.ApplyConfiguration(new InsuranceRequestConfig());
            modelBuilder.ApplyConfiguration(new InsuranceRequestCoverageConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
