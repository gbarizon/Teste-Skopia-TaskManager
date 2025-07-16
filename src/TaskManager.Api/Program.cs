using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using TaskManager.Application.Projects.Handlers;
using TaskManager.Application.Projects.Validators;
using TaskManager.Application.Tasks.Handlers;
using TaskManager.Application.Tasks.Validators;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repositories;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<TaskManagerDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure()
            )
        );


        // Repositories
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
        builder.Services.AddScoped<ITaskCommentRepository, TaskCommentRepository>();
        builder.Services.AddScoped<ITaskHistoryRepository, TaskHistoryRepository>();
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();

        //Registrar o repositório de tarefas no MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProjectHandler>());
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteProjectHandler>());
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddCommentHandler>());
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateTaskHandler>());
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UpdateTaskHandler>());

        //Validators
        builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<AddCommentDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UpdateTaskDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<DeleteProjectCommandValidator>();

        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        var app = builder.Build();
        app.UseCors("AllowAll");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Adicione esta linha para mapear os controllers:
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<TaskManagerDbContext>();
            db.Database.Migrate();
        }

        app.Run();
    }
}



