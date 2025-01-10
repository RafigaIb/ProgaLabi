using Lab2.CommandsInterface;  // Использование интерфейсов команд
using Lab2.CommandsOperation;  // Операции с командами
using Lab2.ScreenNotificator;  // Уведомления на экран
using Lab2.Storage;  // Работа с хранилищем данных
using System.Linq;  // Использование LINQ для работы с коллекциями
using Lab2;  // Основное пространство имен
using Lab2.DataBase;  // Работа с базой данных

internal class Program
{
    // Константа для выхода из игры
    private const string Exit = "exit";

    private static async Task Main(string[] args)
    {
        // Инициализация объектов для игры
        var turtle = new Turtle();  // Черепашка (основной объект)
        var invoker = new CommandInvoker(turtle);  // Инвокер для выполнения команд
        
        var dbReader = new DataBaseReader();  // Чтение из базы данных
        var dbWriter = new DataBaseWriter();  // Запись в базу данных
        var dbManager = new CommandManager(dbReader);  // Менеджер команд для определения команд
        var dbNotificator = new Notificator(dbReader);  // Отправка уведомлений
        var dbChecker = new NewFigureChecker(turtle, dbWriter, dbReader);  // Проверка на новые фигуры
        
        // Пересоздание базы данных
        await using (var context = new TurtleContext())
        {
            context.Database.EnsureDeleted();  // Удаление базы данных, если она существует
            context.Database.EnsureCreated();  // Создание новой базы данных
            context.InitializeDatabase();  // Инициализация базы данных
        }
        
        // Список команд без аргументов
        var commWithoutArgsList = new List<string>() { "penup", "pendown", "history", "listfigures" };

        // Текст, введенный пользователем
        string userCommand;

        Console.WriteLine("-------Welcome to the TURTLEGAME-------");
        Console.WriteLine();
        Console.WriteLine("Command list: \n" +
                          "- move [number]\n" +  // Команда для движения
                          "- angle [number]\n" +  // Команда для изменения угла
                          "- penup\n" +  // Команда для поднятия пера
                          "- pendown\n" +  // Команда для опускания пера
                          "- history\n" +  // Команда для просмотра истории команд
                          "- listfigures\n" +  // Команда для просмотра списка фигур
                          "- color [string]\n" +  // Команда для изменения цвета
                          "- width [number]");  // Команда для изменения ширины линии
        Console.WriteLine();
        Console.WriteLine("Choose the command from list to START the game");
        Console.WriteLine("To leave the game, enter - exit");

        // Цикл, который работает до выхода из игры
        while (true)
        {
            try
            {
                userCommand = Console.ReadLine();  // Считываем команду пользователя

                // Проверка на команду выхода из игры
                if (userCommand == Exit)
                {
                    break;  // Прерываем цикл, если введена команда выхода
                }

                // Если команда без аргументов
                if (commWithoutArgsList.Contains(userCommand))
                {
                    // Определяем команду и выполняем её
                    ICommandsWithoutArgs command = (ICommandsWithoutArgs)dbManager.DefineCommand(userCommand);
                    invoker.Invoke(command);  // Выполнение команды
                    await dbWriter.SaveCommand(userCommand);  // Сохранение команды в базе данных
                }
                else
                {
                    // Если команда с аргументами
                    ICommandsWithArgs command = (ICommandsWithArgs)dbManager.DefineCommand(userCommand.Split(' ')[0]);
                    invoker.Invoke(command, userCommand.Split(' ')[1]);  // Выполнение команды с аргументом
                    await dbWriter.SaveCommand(userCommand);  // Сохранение команды в базе данных
                }

                await dbWriter.SaveTurtleStatus(turtle);  // Сохранение текущего состояния черепашки
                // Отправка уведомления после выполнения команды
                await dbNotificator.SendNotification(userCommand);

                // Проверка на создание новой фигуры
                await dbChecker.Check();
            }

            // Обработка возможных ошибок
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Invalid argument");  // Некорректный аргумент
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Invalid argument, or argument doesnt exist");  // Аргумент не существует
            }

            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("Invalid command, or command doesnt exist");  // Команда не найдена
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Invalid argument, please try again or check command list");  // Некорректный формат аргумента
            }
            
            catch (NullReferenceException ex)
            {
                Console.WriteLine("empty...");  // Пустое значение (null)
            }
        }

        Console.WriteLine("GAME END");  // Конец игры
    }
}
