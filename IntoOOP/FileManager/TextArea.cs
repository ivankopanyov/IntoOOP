namespace IntoOOP;

public class TextArea: Window
{
    private string content = string.Empty;
    private int pageNumber = 1;

    public bool ShowPageNumber { get; set; }

    public TextArea(int weigth) : base(weigth)
    { 
    
    }

    public void SetContent(string content, int pageNumber = 1)
    {
        if (pageNumber <= 0)
            throw new ArgumentException();

        if (content == null) 
            content = string.Empty;
    }
}