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
    private const string Exit = "exit"; // Константа для команды выхода

    // Точка входа в приложение
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);  // Создание билдер для веб-приложения
        builder.Environment.EnvironmentName = Environments.Development;  // Установка окружения разработки

        // Регистрация сервисов в DI контейнере
        // Настройка контекста базы данных с использованием SQLite
        builder.Services.AddDbContext<TurtleContext>(options =>
            options.UseSqlite("Data Source=my.db"));

        // Регистрация зависимостей для работы с командным менеджером и историей команд
        builder.Services.AddSingleton<CommandManager>();  // Командный менеджер для управления командами
        builder.Services.AddSingleton<CommandInvoker>();  // Инвокер команд для их выполнения
        builder.Services.AddSingleton<IDataBaseWriter, DataBaseWriter>();  // Реализация для записи данных в базу
        builder.Services.AddSingleton<IDataBaseReader, DataBaseReader>();  // Реализация для чтения данных из базы
        builder.Services.AddSingleton<Notificator>();  // Сервис для отправки уведомлений о состоянии черепахи и историях
        builder.Services.AddSingleton<Turtle>();  // Объект черепахи, который выполняет команды
        builder.Services.AddSingleton<NewFigureChecker>();  // Проверка на создание новых фигур черепахой

        // Добавление сервисов для создания API (Web API)
        builder.Services.AddControllers();  // Добавление поддержки контроллеров
        builder.Services.AddEndpointsApiExplorer();  // Автоматическая генерация документации для API
        builder.Services.AddSwaggerGen();  // Генерация Swagger документации для API

        var app = builder.Build();  // Строим приложение

        // Swagger доступен в разработке для документации API
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();  // Включаем Swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  // Указываем путь к Swagger JSON
                c.RoutePrefix = "";  // Убираем префикс из URL для Swagger UI
            });
        }

        app.UseAuthorization();  // Включаем авторизацию (если необходима в будущем)
        app.MapControllers();  // Маппинг контроллеров (обработка запросов API)
        app.Run();  // Запуск приложения
    }
}
