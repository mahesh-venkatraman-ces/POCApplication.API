using POCApplication.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);
var configValue = builder.Configuration;

builder.Services.AddControllers();

DependencyInjection.RegisterBLLDependencies(builder.Services, configValue);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
