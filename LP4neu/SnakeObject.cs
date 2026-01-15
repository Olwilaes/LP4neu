namespace MyApp;

public class SnakeObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
    
    public SnakeObject(int x, int y, char symbol)
    {
        X = x;
        Y = y;
        Symbol = symbol;
    }

    public void MoveLeft(ConsoleRenderer renderer)
    {
        renderer.RenderSnake(this);
        X--;
    }
    public void MoveRight(ConsoleRenderer renderer)
    {
        renderer.RenderSnake(this);
        X++;
    }
    public void MoveUp(ConsoleRenderer renderer)
    {
        renderer.RenderSnake(this);
        Y--;
    }
    public void MoveDown(ConsoleRenderer renderer)
    {
        renderer.RenderSnake(this);
        Y++;
    }
}