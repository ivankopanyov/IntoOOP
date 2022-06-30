using IntoOOP.FileManager.UI;

namespace IntoOOP.FileManager.Commands
{
    public interface ICommand
    {
        string KeyWord { get; }

        TextArea Output { get; }

        void Execute(string args, string currentDir);
    }
}