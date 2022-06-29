namespace IntoOOP;

public class ListCommand : ICommand
{
    public string KeyWord { get; }

    public TextArea Output { get; }

    public ListCommand(string keyWord, TextArea output)
    {
        KeyWord = keyWord;
        Output = output;
    }

    public void Execute(string args, string currentDir)
    {

    }

    private string GetTree(DirectoryInfo dir, string indent = "", bool isLast = true)
    {
        return string.Empty;
    }
}