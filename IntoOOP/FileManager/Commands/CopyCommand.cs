using IntoOOP.FileManager.UI;

namespace IntoOOP.FileManager.Commands;

public class CopyCommand : ICommand
{
    public string KeyWord { get; }

    public TextArea Output { get; }

    public CopyCommand(string keyWord, TextArea output)
    {
        KeyWord = keyWord;
        Output = output;
    }

    public void Execute(string args, string currentDir)
    {

    }

    private void RecursiveCopy(string source, string dest)
    {

    }
}