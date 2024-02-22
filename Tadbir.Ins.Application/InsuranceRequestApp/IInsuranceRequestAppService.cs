using Tadbir.Ins.Application.InsuranceRequestApp.Model;
using Tadbir.Ins.Domain.Models;
using Vita.Application.Application;
using Vita.Shared.Result;

namespace Tadbir.Ins.Application.InsuranceRequestApp
{
    public interface IInsuranceRequestAppService : IVitaCoreAppService<InsuranceRequest, InsuranceRequestDto, Guid>
    {
        VitaResult<List<InsuranceRequestDto>> GetAllPeople(InsuranceRequestDto model);
    }
}
