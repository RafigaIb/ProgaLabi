using Lab3;
using Lab3.CommandsOperation;
using Lab3.DataBase;
using Lab3.ScreenNotificator;
using Lab3.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    private const string Exit = "exit";

    private static async Task Main(string[] args)
    {
        try
        {
            new TurtleContext().InitializeDatabase();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        var builder = WebApplication.CreateBuilder(args);
        builder.Environment.EnvironmentName = Environments.Development;

       
        builder.Services.AddDbContext<TurtleContext>(options =>
            options.UseSqlite("Data Source=my5.db")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));

        builder.Services.AddScoped<IDataBaseWriter, DataBaseWriter>();
        builder.Services.AddScoped<IDataBaseReader, DataBaseReader>();
        builder.Services.AddSingleton<CommandManager>();
        builder.Services.AddSingleton<CommandInvoker>();
        builder.Services.AddSingleton<Notificator>();
        builder.Services.AddSingleton<Turtle>();
        builder.Services.AddSingleton<NewFigureChecker>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}