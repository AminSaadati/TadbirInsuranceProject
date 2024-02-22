using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tadbir.Ins.Domain.Models
{
    /// <summary>
    /// جدول درخواست پوشش بیمه ای
    /// </summary>
    public class InsuranceRequest : VitaAggregateRootEntity
    {
        public InsuranceRequest()
        {

        }

        //public InsuranceRequest(Guid id, string byWhom, string title, bool isActive)
        //{
        //    Title = title;
        //    IsActive = isActive;
        //    SetBaseProperties(id, byWhom);
        //}

        public string Title { get; set; }
        public bool IsActive { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; }

    }
}
