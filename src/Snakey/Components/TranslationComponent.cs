using MinECS;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

public class TranslationComponent : Component 
{
    public Vector2 Location;
    public Vector2 Speed;
    public Vector2 Direction;
    public Vector2 DistanceMoved;

    public TranslationComponent(float locX, float locY, float speedX,float speedY, float dirX, float dirY)
    {
        Location= new Vector2(locX, locY);
        Speed = new Vector2(speedX, speedY);
        Direction= new Vector2(dirX, dirY);
        DistanceMoved = new Vector2(0, 0);
    }
}
