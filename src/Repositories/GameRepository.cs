using System.Text.Json;
using game_data_parser.Interfaces;
using game_data_parser.Types;

namespace game_data_parser.Repositories;

public class GameRepository : IGameRepository
{
	public bool IsFileExist(string filePath)
	{
		bool isExist = File.Exists(filePath);

		if (!isExist)
		{
			throw new FileNotFoundException();
		}

		return true;
	}

	public List<Game> ReadAllGames(string filePath)
	{
		string fileData = File.ReadAllText(filePath);
		List<Game> allGames = new List<Game>();

		try
		{
			allGames = JsonSerializer.Deserialize<List<Game>>(fileData);
		}
		catch (JsonException ex)
		{
			ConsoleColor originalColor = Console.ForegroundColor;
			Console.WriteLine($"JSON in the {filePath} was not in a valid format. JSON body:");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(fileData);
			Console.ForegroundColor = originalColor;
			Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");

			throw;
		}

		return allGames;
	}

	public void PrintGameInfo(List<Game> games)
	{
		if (games.Count == 0)
		{
			Console.WriteLine("No games are present in the input file.");
			return;
		}

		Console.WriteLine("Loaded games are:");

		foreach (Game game in games)
		{
			Console.WriteLine($"{game.Title}, released in {game.ReleaseYear}, rating: {game.Rating}");
		}
	}
}