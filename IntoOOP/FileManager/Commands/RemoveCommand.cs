using IntoOOP.FileManager.UI;

namespace IntoOOP.FileManager.Commands;

public class RemoveCommand : ICommand
{
    public string KeyWord { get; }

    public TextArea Output { get; }

    public RemoveCommand(string keyWord, TextArea output)
    {
        KeyWord = keyWord;
        Output = output;
    }

    public void Execute(string args, string currentDir)
    {

    }

    private void RecursiveRemove(string dir)
    {

    }
}