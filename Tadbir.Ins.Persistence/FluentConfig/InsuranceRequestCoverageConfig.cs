using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Ins.Domain.Models;
using Tadbir.Ins.Persistence.Schema;

namespace Tadbir.Ins.Persistence.FluentConfig
{
    public class InsuranceRequestCoverageConfig : IEntityTypeConfiguration<InsuranceRequestCoverage>
    {
        public void Configure(EntityTypeBuilder<InsuranceRequestCoverage> builder)
        {
            #region SystemConfig
            builder.ToTable("InsuranceRequestCoverages", nameof(DbSchema.InsReq));
            builder.HasKey(o => o.Id);  

            builder.HasOne(s => s.InsuranceRequest)
               .WithMany(s => s.InsuranceRequestCoverages)
               .HasForeignKey(o => o.InsuranceRequestId)
               .IsRequired();

            builder.HasOne(s => s.InsuranceCoverage)
             .WithMany()
             .HasForeignKey(o => o.InsuranceCoverageId)
             .IsRequired();
            #endregion

        }
    }
}

