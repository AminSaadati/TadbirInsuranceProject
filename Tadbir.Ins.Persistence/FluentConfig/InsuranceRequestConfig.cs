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
    internal class InsuranceRequestConfig : IEntityTypeConfiguration<InsuranceRequest>
    {
        public void Configure(EntityTypeBuilder<InsuranceRequest> builder)
        {
            #region SystemConfig
            builder.ToTable("InsuranceRequests", nameof(DbSchema.InsReq));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Title).IsRequired();
            builder.Property(o => o.TotalAmount).HasPrecision(18, 8);
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.ModifiedBy).IsRequired();
            builder.Property(o => o.ModifiedDate).IsRequired();
            #endregion

        }
    }
}

