namespace IntoOOP;

public class Container : Window
{
    private List<Window> stack = new List<Window>();
    private Direction direction;

    public Window[] Stack => stack.ToArray();

    public Direction Direction { get; set; }

    public int WeigthSum
    {
        get
        {
            if (stack.Count == 0) return 0;
            var result = 0;
            foreach (Window window in stack)
                result += window.Weigth;
            return result;
        }
    }

    public Container(Direction direction, int weigth) : base(weigth)
    {
        this.direction = direction;
        Weigth = weigth;
    }

    public void AddWindow(Window window)
    {
        if (window == null)
            throw new ArgumentNullException();

        stack.Add(window);
    }

    public void DrawHorizontalStack(int x, int y, int width, int heigth)
    {

    }

    public void DrawVerticalStack(int x, int y, int width, int heigth)
    {

    }
}