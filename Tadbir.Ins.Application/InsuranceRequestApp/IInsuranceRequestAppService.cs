

namespace Tadbir.Ins.Application.InsuranceRequestApp
{
    public interface IInsuranceRequestAppService : IVitaCoreAppService<InsuranceRequest, InsuranceRequestDto, Guid>
    {
        VitaResult<List<InsuranceRequestDto>> GetAllPeople(InsuranceRequestDto model);
    }
}
