

namespace Tadbir.Ins.Persistence.FluentConfig
{
    internal class InsuranceCoverageConfig : IEntityTypeConfiguration<InsuranceCoverage>
    {
        public void Configure(EntityTypeBuilder<InsuranceCoverage> builder)
        {
            #region SystemConfig
            builder.ToTable("InsuranceCoverages", nameof(DbSchema.InsBaseInfo));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.CoverageTitle).IsRequired();
            builder.Property(o => o.RecordDate).IsRequired();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.CoverageConstValue).HasPrecision(10, 4).IsRequired();
            #endregion

        }
    }
}

