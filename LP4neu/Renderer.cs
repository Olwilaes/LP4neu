namespace MyApp;

public abstract class Renderer
{
    public abstract void RenderGameboard(GameboardObject gameboard);
    
    public abstract void RenderSnake(SnakeObject snake);
    
    public abstract void RenderFood(FoodObject food);
}