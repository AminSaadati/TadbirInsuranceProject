

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
