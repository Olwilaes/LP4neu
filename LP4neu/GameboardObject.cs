namespace MyApp;

public class GameboardObject
{
    public int Width { get; set; }
    public int Height { get; set; }
    public char Symbol { get; set; }
    
    public GameboardObject(int width, int height, char symbol)
    {
        Width = width;
        Height = height;
        Symbol = symbol;
    }

    public void Draw(ConsoleRenderer renderer)
    {
        renderer.RenderGameboard(this);
    }
}