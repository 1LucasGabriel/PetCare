using Appointment.Application.UseCases;
using Appointment.Domain.Interfaces.IRepositories;
using Appointment.Infrastructure.Persistence;
using Appointment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();

builder.Services.AddScoped<CreateAppointmentUseCase>();
builder.Services.AddScoped<GetAllAppointmentsUseCase>();
builder.Services.AddScoped<GetAppointmentUseCase>();
builder.Services.AddScoped<GetAppointmentByVeterinarianUseCase>();
builder.Services.AddScoped<GetAppointmentByPetUseCase>();
builder.Services.AddScoped<GetAppointmentsByOwnerUseCase>();
builder.Services.AddScoped<StartAppointmentUseCase>();
builder.Services.AddScoped<CompleteAppointmentUseCase>();
builder.Services.AddScoped<CancelAppointmentUseCase>();
builder.Services.AddScoped<DeleteAppointmentUseCase>();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();