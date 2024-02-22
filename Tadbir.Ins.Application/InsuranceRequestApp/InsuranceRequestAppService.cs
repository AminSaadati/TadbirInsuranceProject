


namespace Tadbir.Ins.Application.InsuranceRequestApp
{
    public class InsuranceRequestAppService : VitaCoreAppService<InsuranceRequest, InsuranceRequestDto, Guid>, IInsuranceRequestAppService
    {
        public InsuranceRequestAppService(IUnitOfWork unitOfWork, IInsuranceRequestService vitaCurrentDomainService, IValidator<InsuranceRequestDto> vitaValidator, VitaResult<InsuranceRequestDto> vitaResult, VitaMapper<InsuranceRequestDto, InsuranceRequest> vitaMapper, IHttpContextAccessor httpContextAccessor, IVitaEmailService vitaEmailService) : base(unitOfWork, vitaCurrentDomainService, vitaValidator, vitaResult, vitaMapper, httpContextAccessor, vitaEmailService)
        {
        }

        public async override Task<VitaResult<InsuranceRequestDto>> AddAsync(InsuranceRequestDto entityToAdd)
        {
            _vitaValidator.ValidateAndThrow(entityToAdd);
            var map = entityToAdd.Adapt<InsuranceRequest>();
            map.SetBaseProperties(map.Id, UserName);
            await _vitaCurrentDomainService.AddAsync(map);
            await _unitOfWork.SaveAsync(CancellationToken.None); 
            return _vitaResult.SuccessResult(map.Adapt<InsuranceRequestDto>()); 
        }

        public VitaResult<List<InsuranceRequestDto>> GetAllPeople(InsuranceRequestDto model)
        {
            
          //  var result = base.SearchFor(s => s.Title == model.Title);
            var result = base.SearchFor(null);
            return result;
        }
    }
}
