

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
