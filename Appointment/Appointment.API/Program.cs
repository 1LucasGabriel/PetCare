using Appointment.Application.UseCases;
using Appointment.Domain.Interfaces;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.ExternalService;
using Appointment.Infrastructure.Persistence;
using Appointment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddHttpClient<IRegistrationService, RegistrationService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:RegistrationApi"] ?? "http://localhost:5290");
});

builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();

builder.Services.AddScoped<CancelAppointmentUseCase>();
builder.Services.AddScoped<CompleteAppointmentUseCase>();
builder.Services.AddScoped<CreateAppointmentUseCase>();
builder.Services.AddScoped<DeleteAppointmentUseCase>();
builder.Services.AddScoped<GetAppointmentUseCase>();
builder.Services.AddScoped<GetAllAppointmentsUseCase>();
builder.Services.AddScoped<GetAppointmentsByVetUseCase>();
builder.Services.AddScoped<GetAppointmentsByOwnerUseCase>();
builder.Services.AddScoped<StartAppointmentUseCase>();
builder.Services.AddScoped<CheckFutureAppointmentsUseCase>();
builder.Services.AddScoped<CreateVeterinarianUseCase>();
builder.Services.AddScoped<GetVeterinarianUseCase>();
builder.Services.AddScoped<GetAllVeterinariansUseCase>();
builder.Services.AddScoped<UpdateVeterinarianUseCase>();
builder.Services.AddScoped<DeleteVeterinarianUseCase>();
builder.Services.AddScoped<LoginVeterinarianUseCase>();

builder.Services.AddScoped<CreateMedicalRecordUseCase>();
builder.Services.AddScoped<GetAllMedicalRecordUseCase>();
builder.Services.AddScoped<GetMedicalRecordUseCase>();
builder.Services.AddScoped<UpdateMedicalRecordUseCase>();
builder.Services.AddScoped<DeleteMedicalRecordUseCase>();

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