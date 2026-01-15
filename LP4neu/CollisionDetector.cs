namespace MyApp;

public class CollisionDetector
{
    private bool running;
    private Thread collisionDetectorThread;
    public event EventHandler<CollisionDetectedEventArgs> CollisionDetected;
    private SnakeObject snake;
    private GameboardObject gameboard;

    public CollisionDetector(SnakeObject snake, GameboardObject gameboard)
    {
        this.snake = snake;
        this.gameboard = gameboard;
    }

    public void Start()
    {
        running = true;
        collisionDetectorThread = new Thread(DetectCollisionLoop);
        collisionDetectorThread.Start();
    }

    private void DetectCollisionLoop()
    {
        while (running)
        {
            // Check for collision with game board borders
            if (snake.X <= 0 || snake.X >= gameboard.Width + 1 || 
                snake.Y <= 0 || snake.Y >= gameboard.Height + 1)
            {
                CollisionDetected?.Invoke(this, new CollisionDetectedEventArgs());
                running = false; // Stop detecting after collision
            }
            Thread.Sleep(50); // Check for collisions frequently
        }
    }
    
    public void Stop()
    {
        running = false;
        collisionDetectorThread.Join();
    }
}

public class CollisionDetectedEventArgs : EventArgs
{
    public CollisionDetectedEventArgs()
    {
        
    }
}