using VM.Application;
using VM.Infrastructure;
using VM.Presistence;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddPresistenceService(builder.Configuration);
builder.Services.AddInfrastructureService();
builder.Services.AddApplicationService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
