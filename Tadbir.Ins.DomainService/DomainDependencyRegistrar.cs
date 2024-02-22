using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Ins.DomainService.Services;
using Tadbir.Ins.IDomainService.IServices;

namespace Tadbir.Ins.DomainService
{
    public static class DomainDependencyRegistrar
    {
        public static void Register(IServiceCollection services)
        {
          services.AddTransient<IInsuranceRequestService,  InsuranceRequestService>();
        
        }
    }
}
