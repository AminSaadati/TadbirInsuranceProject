using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadbir.Ins.Application.InsuranceRequestApp;
using Tadbir.Ins.Application.InsuranceRequestApp.Validation;

namespace Tadbir.Ins.Application
{
    public static class ApplicationDependencyRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IInsuranceRequestAppService, InsuranceRequestAppService>();
            services.AddValidatorsFromAssemblyContaining<InsuranceRequestValidator>(); 
        }
    }
}
