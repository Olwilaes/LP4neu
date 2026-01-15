namespace MyApp;

public class ConsoleRenderer : Renderer
{
    public override void RenderGameboard(GameboardObject gameboard)
    {
        Console.Clear(); // Clear once at the beginning
        // Draw top border
        for (int i = 0; i < gameboard.Width + 2; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write(gameboard.Symbol);;
            Console.SetCursorPosition(i, gameboard.Height + 1);
            Console.Write(gameboard.Symbol);
        }

        // Draw side borders
        for (int i = 0; i < gameboard.Height + 2; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(gameboard.Symbol);
            Console.SetCursorPosition(gameboard.Width + 1, i);
            Console.Write(gameboard.Symbol);
        }
    }

    public override void RenderSnake(SnakeObject snake)
    {
        Console.SetCursorPosition(snake.X + 1, snake.Y + 1); // Offset by 1 for border
        Console.Write(snake.Symbol);
    }
    
    public override void RenderFood(FoodObject food)
    {
        Console.SetCursorPosition(food.X + 1, food.Y + 1); // Offset by 1 for border
        Console.Write(food.Symbol);
    }
}