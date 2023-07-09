using game_data_parser.Interfaces;

namespace game_data_parser.IOHandling;

public class UserInputHandler : IUserInputHandler
{
	private const string FilePath = "../../../src/Data";

	private readonly IGameRepository _gameRepository;

	public UserInputHandler(IGameRepository gameRepository)
	{
		_gameRepository = gameRepository;
	}

	public string ReadFileName()
	{
		Console.WriteLine("Enter the name of the file you want to read:");

		bool isValidNameEntered = false;
		string fileName = string.Empty;

		while (!isValidNameEntered)
		{
			string? userInput = Console.ReadLine();

			try
			{
				isValidNameEntered = IsFileNameValid(userInput) && _gameRepository.IsFileExist($"{FilePath}/{userInput}");
				fileName = userInput;
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine("File name cannot be null.");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("File name cannot be empty.");
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine("File not found.");
			}
		}

		return $"{FilePath}/{fileName}";
	}

	public bool IsFileNameValid(string? fileName)
	{
		if (fileName is null)
		{
			throw new ArgumentNullException();
		}

		if (fileName == string.Empty)
		{
			throw new ArgumentException();
		}

		return true;
	}
}