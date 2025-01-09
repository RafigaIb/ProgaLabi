// TurtleController.cs

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
    private readonly CommandManager dbManager;
    private readonly CommandInvoker invoker;
    private readonly IDataBaseWriter dbWriter;
    private readonly Notificator dbNotificator;
    private readonly Turtle turtle;
    private readonly NewFigureChecker dbChecker;

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

    [HttpPost]
    public async Task<IActionResult> ExecuteCommand([FromBody] TurtleCommandRequest commandRequest)
    {
        try
        {
            if (string.IsNullOrEmpty(commandRequest.Parameter))
            {
                var command = (ICommandsWithoutArgs)dbManager.DefineCommand(commandRequest.Command);
                invoker.Invoke(command);
            }
            else
            {
                var command = (ICommandsWithArgs)dbManager.DefineCommand(commandRequest.Command);
                invoker.Invoke(command, commandRequest.Parameter);
            }

            await dbWriter.SaveCommand($"{commandRequest.Command} {commandRequest.Parameter}");
            await dbWriter.SaveTurtleStatus(turtle);
            await dbChecker.Check();

            return Ok(dbNotificator.GetNotification(commandRequest.Command));
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok("Статус черепашки");
    }
}
