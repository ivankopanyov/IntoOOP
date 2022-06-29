namespace IntoOOP;

public class InfoCommand : ICommand
{
    public string KeyWord { get; }

    public TextArea Output { get; }

    public InfoCommand(string keyWord, TextArea output)
    {
        KeyWord = keyWord;
        Output = output;
    }

    public void Execute(string args, string currentDir)
    {
        
    }

    private int RecursiveSize(string dir)
    { 
        return default(int);
    }
}