using ElevenLabsExample.ApiService.Application;
using ElevenLabsExample.ApiService.Infrastructure;
using ElevenLabsExample.ApiService.Presentation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(optionsAction =>
{
    optionsAction.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHttpClient<IElevenLabsService, ElevenLabsService>(client =>
{
    client.BaseAddress = new Uri("https://api.eu.residency.elevenlabs.io/v1/convai/twilio/outbound-call");
});
builder.Services.AddScoped<ICreatePhoneCallHandler, CreatePhoneCallHandler>();
builder.Services.AddScoped<IPhoneCallRepository, PhoneCallRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapPhoneCallEndpoints();

app.MapDefaultEndpoints();

await app.RunAsync();
