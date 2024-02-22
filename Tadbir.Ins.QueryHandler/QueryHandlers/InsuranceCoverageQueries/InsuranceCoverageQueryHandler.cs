using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Ins.Domain.Models;
using Tadbir.Ins.Shared.Emums;
using Vita.IDomainService.IService;
using Vita.Query.Handler;
using Vita.Shared.Result;

namespace Tadbir.Ins.QueryHandler.QueryHandlers
{
    public class InsuranceCoverageQueryDto : IRequest<VitaResult<List<InsuranceCoverageQueryDto>>>
    {
        public int Id { get; set; }
        public string CoverageTitle { get; set; }
        public bool IsActive { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public DateTime RecordDate { get; set; }
        public CoverageType CoverageTypeId { get; set; }
        public decimal CoverageConstValue { get; set; }

    }

    public sealed class InsuranceCoverageQueryHandler : VitaCoreQueryHandler<InsuranceCoverage, InsuranceCoverageQueryDto, Guid>, IRequestHandler<InsuranceCoverageQueryDto, VitaResult<List<InsuranceCoverageQueryDto>>>
    {
        public InsuranceCoverageQueryHandler(VitaResult<InsuranceCoverageQueryDto> vitaResult, IVitaDomainService<InsuranceCoverage, Guid> vitaCurrentDomainService) : base(vitaResult, vitaCurrentDomainService)
        {
        }

        public Task<VitaResult<List<InsuranceCoverageQueryDto>>> Handle(InsuranceCoverageQueryDto request, CancellationToken cancellationToken)
        {

            // GetList of InsuranceCoverage
            var result = base.SearchFor(null);

            // by condition
            //Expression<Func<InsuranceCoverageQueryDto, bool>> wherePredicate = c => true;
            //wherePredicate = p => p.CoverageTitle.Contains(request.CoverageTitle) && p.IsActive == request.IsActive;
            //var result = base.SearchFor(wherePredicate);

            return Task.FromResult(result);
        }
    }
}
