using IntoOOP.FileManager.UI;

namespace IntoOOP.FileManager.Commands;

public class ChangeDirectoryCommand : ICommand
{
    public string KeyWord { get; }

    public TextArea Output { get; }

    public ChangeDirectoryCommand(string keyWord, TextArea output)
    {
        KeyWord = keyWord;
        Output = output;
    }

    public void Execute(string args, string currentDir)
    {

    }
}