namespace IntoOOP.FileManager.UI;

public abstract class Window
{
    private Container parent;
    private int weigth;
    private bool showBorder;

    public Container Parent
    {
        get => parent;
        protected set
        {
            parent = value;
        }
    }

    public int Weigth
    {
        get => weigth;
        set
        {
            if (value <= 0)
                throw new ArgumentException();
            weigth = value;
        }
    }

    public bool ShowBorder { get => showBorder; set => showBorder = value; }

    public Container MainContainer { get; }

    public Window(int weigth)
    {
        Weigth = weigth;
    }

    public void Draw(int x, int y, int width, int heigth)
    {

    }
}