using Tadbir.Ins.Domain.Models;
using Vita.IDomainService.IService;

namespace Tadbir.Ins.IDomainService.IServices
{
    public interface IInsuranceRequestService : IVitaDomainService<InsuranceRequest, Guid>
    {
    }
}
