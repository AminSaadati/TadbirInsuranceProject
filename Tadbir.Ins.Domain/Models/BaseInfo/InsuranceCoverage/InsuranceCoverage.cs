
using Tadbir.Ins.Shared.Emums;

namespace Tadbir.Ins.Domain.Models
{
    /// <summary>
    /// اطلاعات پایه نوع پوشش بیمه
    /// </summary>
    public class InsuranceCoverage 
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
}
