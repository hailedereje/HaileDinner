
using HaileDinner.Api.Middleware;
using HaileDinner.Application;
using HaileDinner.infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
