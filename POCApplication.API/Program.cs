using POCApplication.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);
var configValue = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();

DependencyInjection.RegisterBLLDependencies(builder.Services, configValue);
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
