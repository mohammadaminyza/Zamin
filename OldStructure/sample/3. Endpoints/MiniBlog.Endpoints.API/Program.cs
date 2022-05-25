using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniBlog.Infra.Data.Sql.Commands.Common;
using MiniBlog.Infra.Data.Sql.Queries.Common;
using Zamin.EndPoints.Web;
using Zamin.EndPoints.Web.Services;
using Zamin.EndPoints.Web.StartupExtentions;
using Zamin.Utilities.Configurations;
using Zamin.Utilities.Services.Users;

var builder = new ZaminProgram().Main(args, "appsettings.json", "appsettings.zamin.json", "appsettings.serilog.json");

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserInfoService, WebUserInfoService>();

//Configuration
ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddZaminApiServices(Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:9119";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };

        HttpClientHandler handler = new HttpClientHandler();//Must Remove In Production!!!!
        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;//Must Remove In Production!!!!
        options.BackchannelHttpHandler = handler; //Must Remove In Production!!!!
    });

builder.Services.AddDbContext<MiniblogCommandDbContext>(c =>
{
    c.UseSqlServer(Configuration.GetConnectionString("MiniBlogCommand_ConnectionString"));
});
builder.Services.AddDbContext<MiniblogQueryDbContext>(c =>
{
    c.UseSqlServer(Configuration.GetConnectionString("MiniBlogQuery_ConnectionString"));
});

//Middlewares
var app = builder.Build();
var zaminOptions = app.Services.GetRequiredService<ZaminConfigurationOptions>();

app.UseAuthentication();

app.UseZaminApiConfigure(zaminOptions, app.Environment);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
    .RequireAuthorization();
});

app.Run();