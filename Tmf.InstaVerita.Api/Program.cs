using FluentValidation;
using Tmf.InstaVerita.Api.Middleware;
using Tmf.InstaVerita.Api.Validations;
using Tmf.InstaVerita.Core.Options;
using Tmf.InstaVerita.Core.RequestModels;
using Tmf.InstaVerita.Infrastructure.HttpServices;
using Tmf.InstaVerita.Infrastructure.Interfaces;
using Tmf.InstaVerita.Infrastructure.Services;
using Tmf.InstaVerita.Manager.Interfaces;
using Tmf.InstaVerita.Manager.Services;
using Tmf.Logs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.Configure<InstaVeritaOptions>(builder.Configuration.GetSection(InstaVeritaOptions.InstaVerita));
builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHttpServices, HttpServices>();

builder.Services.AddScoped<IInstaVeritaManager, InstaVeritaManager>();

builder.Services.AddScoped<IInstaVeritaRepository, InstaVeritaRepository>();

builder.Services.AddScoped<IValidator<InstaVeritaRequest>, InstaVeritaValidator>();

builder.Services.AddSingleton<ILog, Log>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
