using game_data_parser.Interfaces;

namespace game_data_parser.Logs;

public class Logger : ILogger
{
	private const string FilePath = "../../../src/Logs/log.txt";
	
	public void AddLog(Exception exception)
	{
		DateTime currentDate = DateTime.Now;

		File.AppendAllText(FilePath, $"{currentDate}{Environment.NewLine}");
		File.AppendAllText(FilePath, $"{exception.Message}{Environment.NewLine}");
		File.AppendAllText(FilePath, $"{exception.StackTrace}{Environment.NewLine}");
		File.AppendAllText(FilePath, $"{string.Empty}{Environment.NewLine}");
		File.AppendAllText(FilePath, $"-------------------------------------{Environment.NewLine}");
		File.AppendAllText(FilePath, $"{string.Empty}{Environment.NewLine}");
	}
}