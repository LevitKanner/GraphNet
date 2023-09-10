using GraphNet;
using GraphNet.Extensions;
using GraphNet.Graphql.Queries;
using GraphNet.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureDb(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.ConfigureInjections();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGraphQLServer()
    .RegisterDbContext<ApplicationContext>(DbContextKind.Pooled)
    .RegisterService<CategoryRepository>()
    .AddQueryType<CategoryQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultPolicy");
app.UseAuthorization();
app.MapGraphQL(path: "/graphql");
app.MapControllers();

app.Run();