

namespace Tadbir.Ins.DomainService.Services
{
    public class InsuranceRequestService : VitaDomainService<InsuranceRequest, Guid>, IInsuranceRequestService
    {
        private readonly IGenericRepository<InsuranceCoverage, int> _insuranceCoverageRepository;
        public InsuranceRequestService(IGenericRepository<InsuranceRequest, Guid> repository, VitaResult<InsuranceRequest> vitaResult, IHttpContextAccessor httpContextAccessor, IGenericRepository<InsuranceCoverage, int> insuranceCoverageRepository) : base(repository, vitaResult, httpContextAccessor)
        {
            this._insuranceCoverageRepository = insuranceCoverageRepository;
        }
        public override Task AddAsync(InsuranceRequest entityToAdd)
        {
            if (entityToAdd == null)
                _vitaResult.FailureResult(VitaValidator.ObjectIsNull());
            if (string.IsNullOrEmpty(entityToAdd.Title))
                _vitaResult.FailureResult(VitaValidator.ObjectIsNull("مقدار عنوان خالی است"));
            if (entityToAdd.InsuranceRequestCoverages.IsNullOrEmpty())
            {
                _vitaResult.FailureResult(VitaValidator.ObjectIsNull("حداقل یک یا حداکثر سه پوشش بیمه ای بایستی انتخاب شود"));
            }

            entityToAdd.InsuranceRequestCoverages.ToList().ForEach(item =>
            {

                var coverage = _insuranceCoverageRepository.SearchFor(s => s.Id == item.InsuranceCoverageId).FirstOrDefault();
                if (coverage == null)
                {
                    _vitaResult.FailureResult(VitaValidator.ObjectIsNull("نوع پوشش بیمه ای انتخاب شده معتبر نمی باشد"));
                }
                if (item.Amount < coverage.MinAmount || item.Amount > coverage.MaxAmount)
                {
                    string messageFa = string.Format("سرمایه وارده شده برای بیمه {0} باید بین {1} و {2} باشد", coverage.CoverageTitle, coverage.MinAmount, coverage.MaxAmount);
                    _vitaResult.FailureResult(VitaValidator.Error(messageFa));
                }

                decimal resOfCalcCoverageType = 0;
                switch (coverage.CoverageTypeId)
                {

                    case CoverageType.Surgery:
                        // do anything for Surgery type of coverage 
                        resOfCalcCoverageType = coverage.CoverageConstValue * item.Amount;
                        break;
                    case CoverageType.Dental:
                        // do anything for Surgery type of coverage 
                        resOfCalcCoverageType = coverage.CoverageConstValue * item.Amount;
                        break;
                    case CoverageType.Hospitalized:
                        // do anything for Surgery type of coverage 
                        resOfCalcCoverageType = coverage.CoverageConstValue * item.Amount;
                        break;
                    default:
                        break;
                }
                entityToAdd.TotalAmount += resOfCalcCoverageType;
            });

            return base.AddAsync(entityToAdd);
        }

    }
}
