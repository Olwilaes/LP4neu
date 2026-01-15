namespace MyApp;

public class FoodSpawner
{
    private bool running;
    private Thread foodSpawnerThread;
    public event EventHandler<FoodSpawnedEventArgs> FoodSpawned;
    private Random random;
    private FoodObject food;
    private ConsoleRenderer renderer;
    
    public FoodSpawner(FoodObject food)
    {
        this.food = food;
    }
    
    public void Start()
    {
        renderer = new ConsoleRenderer();
        foodSpawnerThread = new Thread(SpawnFood);
        running = true;
        foodSpawnerThread.Start();
    }
    
    public void Stop()
    {
        running = false;
        foodSpawnerThread.Join();
    }

    private void SpawnFood()
    {
        while (running)
        {
            Random random = new Random();
            int x = random.Next(1, 20);
            int y = random.Next(1, 20);

            food = new FoodObject(x, y, '#');
            //food.Spawn(renderer);
            
            FoodSpawned?.Invoke(this, new FoodSpawnedEventArgs(food));
            Thread.Sleep(100);
        }
        
        
    }
}

public class FoodSpawnedEventArgs : EventArgs
{
    public FoodSpawnedEventArgs(FoodObject food)
    {
       Food = food;
    }
    public FoodObject Food { get; private set; }
}