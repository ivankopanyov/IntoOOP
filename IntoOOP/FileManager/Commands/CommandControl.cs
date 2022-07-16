namespace IntoOOP.FileManager.Commands;

public class CommandControl
{
    private List<ICommand> commands = new List<ICommand>();
    private List<string> cache = new List<string>();
    private int cacheLimit = 10;

    public string[] Cache => cache.ToArray();

    public void AddCommands(IEnumerable<ICommand> commands)
    {

    }

    public void ExecuteCommand(string command, string currentDir)
    {

    }

    private void AddCache(string command)
    {

    }

    private string GetKeyWord()
    {
        return string.Empty;
    }
}