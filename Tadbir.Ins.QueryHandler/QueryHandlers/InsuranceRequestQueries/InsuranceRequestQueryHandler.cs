using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Ins.Application.InsuranceRequestApp.Model;
using Tadbir.Ins.Domain.Models;
using Vita.IDomainService.IService;
using Vita.Query.Handler;
using Vita.Shared.Result;

namespace Tadbir.Ins.QueryHandler.QueryHandlers
{


    public class InsuranceRequestQueryDto : VitaBaseDtoModel<Guid>, IRequest<VitaResult<List<InsuranceRequestQueryDto>>>
    {
        public required string Title { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalAmount { get; set; } 
    }

    
    public sealed class InsuranceRequestQueryHandler : VitaCoreQueryHandler<InsuranceRequest, InsuranceRequestQueryDto, Guid>, IRequestHandler<InsuranceRequestQueryDto, VitaResult<List<InsuranceRequestQueryDto>>>
    {
        public InsuranceRequestQueryHandler(VitaResult<InsuranceRequestQueryDto> vitaResult, IVitaDomainService<InsuranceRequest, Guid> vitaCurrentDomainService) : base(vitaResult, vitaCurrentDomainService)
        {
        }

        public Task<VitaResult<List<InsuranceRequestQueryDto>>> Handle(InsuranceRequestQueryDto request, CancellationToken cancellationToken)
        {
            
            var result = base.SearchFor(null); 
            //Expression<Func<InsuranceRequestQueryDto, bool>> wherePredicate = c => true;
            //wherePredicate = p => p.Title.Contains(request.Title) && p.IsActive == request.IsActive;
            //var result = base.SearchFor(wherePredicate); 
            return Task.FromResult(result);
        }
    }
}
