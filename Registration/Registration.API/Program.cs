using Microsoft.EntityFrameworkCore;
using Registration.Application.UseCases;
using Registration.Domain.Interfaces.IRepositories;
using Registration.Domain.Interfaces.IServices;
using Registration.Infrastructure.ExternalService;
using Registration.Infrastructure.Persistence;
using Registration.Infrastructure.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();

builder.Services.AddScoped<CreateOwnerUseCase>();
builder.Services.AddScoped<GetAllOwnerUseCase>();
builder.Services.AddScoped<GetOwnerUseCase>();
builder.Services.AddScoped<UpdateOwnerUseCase>();
builder.Services.AddScoped<DeleteOwnerUseCase>();
builder.Services.AddScoped<LoginOwnerUseCase>();

builder.Services.AddScoped<CreatePetUseCase>();
builder.Services.AddScoped<GetAllPetsUseCase>();
builder.Services.AddScoped<GetPetUseCase>();

builder.Services.AddScoped<UpdatePetUseCase>();
builder.Services.AddScoped<DeletePetUseCase>();

builder.Services.AddHttpClient<IAppointmentService, AppointmentService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:AppointmentApi"] ?? "http://localhost:5289");
});

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();
app.Run();