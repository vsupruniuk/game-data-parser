namespace game_data_parser.Interfaces;

public interface IUserInputHandler
{
	string ReadFileName();
	bool IsFileNameValid(string fileName);
}