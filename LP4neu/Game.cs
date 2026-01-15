namespace MyApp;

public class Game
{
    private KeyboardWatcher keyboardWatcher;
    private SnakeMover snakeMover;
    private SnakeObject snake;
    private ConsoleRenderer renderer;
    private GameboardObject gameboard;
    private FoodSpawner foodSpawner;
    private FoodObject food;
    private CollisionDetector collisionDetector;
    private bool gameOver = false;
    
    public Game()
    {
        renderer = new ConsoleRenderer();
        gameboard = new GameboardObject(20, 10, '█'); // Example size
        snake = new SnakeObject(gameboard.Width / 2, gameboard.Height / 2, 'Ö');
        food = new FoodObject(1, 1, '#'); // Initial food position, will be updated by spawner
        
        keyboardWatcher = new KeyboardWatcher();
        snakeMover = new SnakeMover(snake); 
        foodSpawner = new FoodSpawner(food);
        collisionDetector = new CollisionDetector(snake, gameboard);
    }
    
    public void Run()
    {
        Console.CursorVisible = false; // Hide the cursor
        renderer.RenderGameboard(gameboard);
        renderer.RenderSnake(snake); // Render initial snake position
        
        keyboardWatcher.KeyPressed += (sender, e) =>
        {
            switch (e.Key.Key)
            {
                case ConsoleKey.LeftArrow:
                    snakeMover.SetDirection(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    snakeMover.SetDirection(Direction.Right);
                    break;
                case ConsoleKey.UpArrow:
                    snakeMover.SetDirection(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    snakeMover.SetDirection(Direction.Down);
                    break;
                case ConsoleKey.Escape:
                    gameOver = true; // Allow exiting with Escape key
                    break;
            }
        };
        keyboardWatcher.Start();

        snakeMover.SnakeMoved += (sender, e) =>
        {
            renderer.RenderSnake(e.Snake);
        };
        snakeMover.Start();

        foodSpawner.FoodSpawned += (sender, e) =>
        {
            renderer.RenderFood(e.Food);
        };
        foodSpawner.Start();

        collisionDetector.CollisionDetected += (sender, e) =>
        {
            gameOver = true;
            Console.SetCursorPosition(gameboard.Width / 2 - 5, gameboard.Height / 2);
            Console.WriteLine("Game Over!");
        };
        collisionDetector.Start();
        
        // Main game loop
        while (!gameOver)
        {
            Thread.Sleep(100); // Keep the main thread alive
        }
        
        Stop(); // Stop all threads when game is over
        Console.SetCursorPosition(0, gameboard.Height + 3); // Move cursor below game board
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
    
    public void Stop()
    {
        keyboardWatcher.Stop();
        snakeMover.Stop();
        foodSpawner.Stop();
        collisionDetector.Stop();
    }
}