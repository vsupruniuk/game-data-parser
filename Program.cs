using game_data_parser;
using game_data_parser.Interfaces;
using game_data_parser.IOHandling;
using game_data_parser.Logs;
using game_data_parser.Repositories;

ILogger logger = new Logger();
IGameRepository gameRepository = new GameRepository();

try
{
	App app = new App(
		new UserInputHandler(gameRepository),
		gameRepository,
		logger
	);

	app.Start();
}
catch (Exception ex)
{
	logger.AddLog(ex);

	Console.WriteLine("An unexpected error has occurred, the program will be closed.");
	Console.WriteLine("Press any key to exit.");
	Console.ReadKey();
}