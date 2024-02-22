using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Ins.Domain.Models;

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
