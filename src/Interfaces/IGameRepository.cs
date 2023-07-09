using game_data_parser.Types;

namespace game_data_parser.Interfaces;

public interface IGameRepository
{
	bool IsFileExist(string filePath);
	List<Game> ReadAllGames(string filePath);
	void PrintGameInfo(List<Game> games);
}