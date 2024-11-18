using WebAPI.Common.Extensions.FileExtensions;
using WebAPI.Common.Extensions.Register;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.RegisterDbContext();
builder.Services.AddServices();




var app = builder.Build();

app.UseCustomFileServer();
app.UseSwagger(); 
app.UseSwaggerUI();
app.MapControllers();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.Run();

