namespace MyApp;

public class SnakeMover
{
    bool running;
    private Thread SnakeMoverThread;
    public event EventHandler<SnakeMovedEventArgs> SnakeMoved;
    private SnakeObject snake;
    private Direction currentDirection;
    private ConsoleRenderer renderer;

    public SnakeMover(SnakeObject snake)
    {
        this.snake = snake;
        this.currentDirection = Direction.Right; // Default direction
    }
    
    public void SetDirection(Direction newDirection)
    {
        this.currentDirection = newDirection;
    }
    
    public void MoveSnake()
    {
        while (running)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    snake.MoveUp(renderer);
                    break;
                case Direction.Down:
                    snake.MoveDown(renderer);
                    break;
                case Direction.Left:
                    snake.MoveLeft(renderer);
                    break;
                case Direction.Right:
                    snake.MoveRight(renderer);
                    break;
            }
            
            SnakeMoved?.Invoke(this, new SnakeMovedEventArgs(snake));
            Thread.Sleep(100);
        }
    }
    
    public void Start()
    {
        renderer = new ConsoleRenderer();
        SnakeMoverThread = new Thread(MoveSnake);
        running = true;
        SnakeMoverThread.Start();
    }
    
    public void Stop()
    {
        running = false;
        SnakeMoverThread.Join();
    }
}

public class SnakeMovedEventArgs : EventArgs
{
    public SnakeMovedEventArgs(SnakeObject snake)
    {
        Snake = snake;
    }
    public SnakeObject Snake { get; private set; }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}