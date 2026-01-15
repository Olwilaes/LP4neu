public class KeyboardWatcher
{
    private bool running;
    
    private Thread KeyboardWatcherThread;
    
    public event EventHandler<KeyPressedEventArgs> KeyPressed;

    public void CheckForKeyPressed()
    {
        while (running)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            KeyPressed?.Invoke(this, new KeyPressedEventArgs(key));
            Thread.Sleep(100);
        }
    }
    
    public void Start()
    {
        this.KeyboardWatcherThread = new Thread(CheckForKeyPressed);
        this.running = true;
        this.KeyboardWatcherThread.Start();
    }

    public void Stop()
    {
        this.running = false;
        this.KeyboardWatcherThread.Join();
    }
}
    
public class KeyPressedEventArgs : EventArgs 
{
    public KeyPressedEventArgs(ConsoleKeyInfo key) 
    { 
        this.Key = key; 
    }
    public ConsoleKeyInfo Key { get; private set; }
}