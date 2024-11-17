using AGI.Morn.Application;
using AGI.Morn.Infrastructure;
using Morn_Agi;
using Morn_Agi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dbcontext

builder.Services.AddInfrastrctureServices(builder.Configuration);
builder.Services.AddWebServices();
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomizedSwagger(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseExceptionHandler(options => { });
app.UseCustomizedSwagger(app.Environment);
app.MapEndpoints();
app.UseHttpsRedirection();


app.Run();
public partial class Program { }


