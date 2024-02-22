using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Ins.Domain.Models
{
    /// <summary>
    /// جدول چوشش های انتخاب شده برای درخواست پوشش بیمه ای
    /// </summary>
    public class InsuranceRequestCoverage
    {
        public int Id { get; set; }

        /// <summary>
        /// جدول اصلی درخوسات پوشش بیمه ای
        /// </summary>
        public InsuranceRequest InsuranceRequest { get; set; }
        public Guid InsuranceRequestId { get; set; }

        /// <summary>
        /// اطلاعات پایه نوع پوشش بیمه ای
        /// </summary>
        public InsuranceCoverage InsuranceCoverage { get; set; }
        public int InsuranceCoverageId { get; set; }

        /// <summary>
        /// سرمایه هر پوشش
        /// </summary>
        public int Amount { get; set; }
    }
}
