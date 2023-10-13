using Mamma.Mia.Pizzeria.Helpers.DIContainer;
using Mamma.Mia.Pizzeria.Helpers.Extensions;
using Mamma.Mia.Pizzeria.Mappers.MappersConfig;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("AppSettings");

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
    .AddPostgreSqlDbContext(appSettings)
    .AddAuthentication()
    .AddJWT(appSettings)
    .AddIdentity()
    .AddCors()
    .AddSwager();

DIHelper.InjectRepositories(builder.Services);
DIHelper.InjectServices(builder.Services);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.Run();