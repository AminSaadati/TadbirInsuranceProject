using Microsoft.EntityFrameworkCore;
using Serilog;
using Tadbir.Ins.Persistence.DataBaseContext;
using Tadbir.Ins.Application;
using Tadbir.Ins.DomainService;
using Tadbir.Ins.Persistence;
using Vita.WebAPI.GlobalExceptionHandler;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vita.Shared.Result;
using Vita.Domain.CommonModel.Interface;
using Vita.Domain.CommonModel;
using Vita.Persistence.UnitOfWork;
using Vita.Application.Application;
using Vita.Query.Handler;
using Vita.IDomainService.IService;
using Vita.Persistence.IRepository;
using Vita.Application.Mapper;
using Vita.Persistence.Repository;
using Vita.DomainService.Service;
using Vita.Application.CommandHandlers;
using Tadbir.Ins.Domain.Models;
using Tadbir.Ins.QueryHandler.QueryHandlers;
using Vita.Infrastructure.EmailProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




#region Tadbir.Ins

#region Start Vita Config ***

builder.Services.AddDbContext<DbContext, TadbirInsuranceContext>(option =>
{

option.UseSqlServer(builder.Configuration.GetConnectionString("appConnectionString"));
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
//builder.Services.AddApiVersioning();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();



builder.Services.AddSwaggerGen(c =>
{
c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
builder.Logging.AddSerilog(logger);


builder.Services.AddControllers(ac =>
{
    #region Control Accept Header
    //https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-8.0
    // only return text/json or application json if the request put acceptHeader to application Json . Controls Accept header.
    ac.RespectBrowserAcceptHeader = true;
    ac.ReturnHttpNotAcceptable = true;
    #endregion
})

// If you want to generate XML format. it wont notice to accept header like text/plain and will have output
//.AddXmlSerializerFormatters();

 .AddJsonOptions(options =>
 {
     //https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-8.0
     //The following highlighted code configures PascalCase formatting instead of the default camelCase formatting:
     options.JsonSerializerOptions.PropertyNamingPolicy = null;
 })
//.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
;



#region jwToken Configuration
//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
         ClockSkew = TimeSpan.Zero
     };

 });
//Jwt configuration ends here 
#endregion

builder.Services.AddHttpContextAccessor();
#endregion

builder.Services.AddScoped(typeof(VitaResult<>));
builder.Services.AddTransient<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient(typeof(IVitaCoreAppService<,,>), typeof(VitaCoreAppService<,,>));
builder.Services.AddTransient(typeof(IVitaCoreQueryHandler<,,>), typeof(VitaCoreQueryHandler<,,>));
builder.Services.AddTransient(typeof(IVitaDomainService<,>), typeof(VitaDomainService<,>));
builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
IServiceCollection serviceCollection = builder.Services.AddTransient(typeof(VitaMapper<,>));


 builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(InsuranceRequestQueryHandler).Assembly));

ApplicationDependencyRegistrar.Register(builder.Services);
DomainDependencyRegistrar.Register(builder.Services);
RepoDependencyRegistrar.Register(builder.Services);



var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfig>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IVitaEmailService, VitaEmailService>();
 

#endregion








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
 