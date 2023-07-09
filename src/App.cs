using System.Text.Json;
using game_data_parser.Interfaces;
using game_data_parser.Types;

namespace game_data_parser;

public class App
{
	private readonly IUserInputHandler _userInputHandler;
	private readonly IGameRepository _gameRepository;
	private readonly ILogger _logger;

	public App(IUserInputHandler userInputHandler, IGameRepository gameRepository, ILogger logger)
	{
		_userInputHandler = userInputHandler;
		_gameRepository = gameRepository;
		_logger = logger;
	}

	public void Start()
	{
		string filePath = _userInputHandler.ReadFileName();

		List<Game> allGames = new List<Game>();

		try
		{
			allGames = _gameRepository.ReadAllGames(filePath);
		}
		catch (JsonException ex)
		{
			_logger.AddLog(ex);
			Close();

			return;
		}

		_gameRepository.PrintGameInfo(allGames);

		Close();
	}

	private void Close()
	{
		Console.WriteLine();
		Console.WriteLine("Press any key to close.");
		Console.ReadKey();
	}
}