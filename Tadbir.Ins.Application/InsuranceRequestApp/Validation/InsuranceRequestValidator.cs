

namespace Tadbir.Ins.Application.InsuranceRequestApp.Validation
{
    public class InsuranceRequestValidator : VitaFluentValidator<InsuranceRequestDto>
    {
        public InsuranceRequestValidator()
        {
            //RuleFor(model => model.Price).GreaterThan(5).WithMessage("Price Must be Greater than 5 : Manual Message");
            RuleFor(model => model.Title).NotEmpty().NotNull().WithMessage(" عنوان را پرکنید");
             


        }
    }
}
