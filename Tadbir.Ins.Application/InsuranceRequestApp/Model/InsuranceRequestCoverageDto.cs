using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Ins.Application.InsuranceRequestApp.Model
{
    public class InsuranceRequestCoverageDto
    {
        public int Id { get; set; } 
        public int InsuranceCoverageId { get; set; }
        public int Amount { get; set; }
    } 
}
