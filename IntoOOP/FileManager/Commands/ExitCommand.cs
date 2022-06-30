using IntoOOP.FileManager.UI;

namespace IntoOOP.FileManager.Commands;

public class ExitCommand : ICommand
{
    public string KeyWord { get; }

    public TextArea Output { get; }

    public ExitCommand(string keyWord, TextArea output)
    {
        KeyWord = keyWord;
        Output = output;
    }

    public void Execute(string args, string currentDir)
    {

    }

    private async void KillProcess()
    {

    }
}