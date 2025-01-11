using Lab3.CommandsInterface;
using Lab3.CommandsOperation;
using Lab3.DataBase;
using Lab3.ScreenNotificator;
using Lab3.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TurtleController : ControllerBase
{
    // Зависимости, передаваемые через конструктор
    private readonly CommandManager dbManager;   // Менеджер команд
    private readonly CommandInvoker invoker;     // Инвокер команд
    private readonly IDataBaseWriter dbWriter;   // Сервис для записи в базу данных
    private readonly Notificator dbNotificator;  // Сервис уведомлений
    private readonly Turtle turtle;              // Объект черепахи, состояние которой мы управляем
    private readonly NewFigureChecker dbChecker; // Проверка на создание новых фигур

    // Конструктор контроллера, где инициализируются все зависимости
    public TurtleController(
        CommandManager dbManager,
        CommandInvoker invoker,
        IDataBaseWriter dbWriter,
        Notificator dbNotificator,
        Turtle turtle,
        NewFigureChecker dbChecker)
    {
        this.dbManager = dbManager;
        this.invoker = invoker;
        this.dbWriter = dbWriter;
        this.dbNotificator = dbNotificator;
        this.turtle = turtle;
        this.dbChecker = dbChecker;
    }

    // HTTP POST метод для выполнения команды, переданной в теле запроса
    [HttpPost]
    public async Task<IActionResult> ExecuteCommand([FromBody] TurtleCommandRequest commandRequest)
    {
        try
        {
            // Если команда не требует параметра (команды без аргументов)
            if (string.IsNullOrEmpty(commandRequest.Parameter))
            {
                var command = (ICommandsWithoutArgs)dbManager.DefineCommand(commandRequest.Command);
                invoker.Invoke(command);  // Выполнение команды без параметров
            }
            // Если команда требует параметра (команды с аргументами)
            else
            {
                var command = (ICommandsWithArgs)dbManager.DefineCommand(commandRequest.Command);
                invoker.Invoke(command, commandRequest.Parameter);  // Выполнение команды с параметром
            }

            // Сохранение команды в базу данных для истории
            await dbWriter.SaveCommand($"{commandRequest.Command} {commandRequest.Parameter}");
            
            // Сохранение текущего состояния черепахи в базу данных
            await dbWriter.SaveTurtleStatus(turtle);
            
            // Проверка, не образовалась ли новая фигура в результате команды
            await dbChecker.Check();

            // Возвращаем уведомления после выполнения команды
            return Ok(dbNotificator.GetNotification(commandRequest.Command));  
        }
        catch (Exception ex)
        {
            // В случае ошибки возвращаем статус 400 с сообщением об ошибке
            return BadRequest(new { Error = ex.Message });
        }
    }

    // HTTP GET метод для получения статуса черепахи
    [HttpGet]
    public IActionResult GetStatus()
    {
        // Возвращаем сообщение о текущем статусе черепахи
        return Ok("Статус черепашки");
    }
}
