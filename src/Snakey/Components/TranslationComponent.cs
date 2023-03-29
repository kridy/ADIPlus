using MinECS;

using System.Numerics;

public class TranslationComponent : Component 
{
    public Vector2 Location;
    public Vector2 Speed;
    public Vector2 Direction;

    public TranslationComponent(float locX, float locY, float speedX,float speedY, float dirX, float dirY)
    {
        Location= new Vector2(locX, locY);
        Speed = new Vector2(speedX, speedY);
        Direction= new Vector2(dirX, dirY);
    }
}
