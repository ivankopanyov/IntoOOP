namespace IntoOOP.FileManager.UI;

public class FileManagerUI
{
    private Container mainContainer;
    private TextArea tree;
    private TextArea info;
    private TextArea currentDir;
    private InputField commandLine;

    public TextArea Tree => tree;
    public TextArea Info => info;
    public TextArea CurrentDir => currentDir;
    public InputField CommandLine => commandLine;

    public FileManagerUI(int width, int height)
    {
        FixedSizeConsole(width, height);
    }

    public void Update()
    {
        mainContainer.Draw(0, 0, Console.WindowWidth, Console.WindowHeight);
    }

    private void FixedSizeConsole(int width, int height)
    {

    }
}