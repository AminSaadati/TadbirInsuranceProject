

namespace Tadbir.Ins.Application.InsuranceRequestApp.Model
{
    public class InsuranceRequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public IList<InsuranceRequestCoverageDto> InsuranceRequestCoverages { get; set; }
    }
}
