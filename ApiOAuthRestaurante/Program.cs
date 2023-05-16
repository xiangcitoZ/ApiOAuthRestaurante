using ApiOauthRestaurante.Data;
using ApiOauthRestaurante.Repository;
using ApiOAuthRestaurante.Helpers;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});

SecretClient secretClient =
 builder.Services.BuildServiceProvider().GetService<SecretClient>();
KeyVaultSecret keyVaultSecret = await
 secretClient.GetSecretAsync("SqlAzure");


string connectionString = keyVaultSecret.Value;

//string connectionString =
//    builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddTransient<RepositoryMenu>();
builder.Services.AddDbContext<RestauranteContext>
    (options => options.UseSqlServer(connectionString));

//LOGIN
builder.Services.AddSingleton<HelperOAuthToken>();
HelperOAuthToken helper = new HelperOAuthToken(builder.Configuration);
builder.Services.AddAuthentication(helper.GetAuthenticationOptions())
    .AddJwtBearer(helper.GetJwtOptions());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Proyecto Resaurante",
        Description = "Proyecto",
        Version = "v1"
    });

});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json"
        , name: "Api Proyecto Restaurante");
    options.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
