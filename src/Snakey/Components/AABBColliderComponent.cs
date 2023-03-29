
using MinECS;
using System.Drawing;
using System.Numerics;

public class AABBColliderComponent : Component
{
    public Vector2 LocationOffset;
    public Vector2 Size;


    public AABBColliderComponent(int x, int y, int width, int height)
    {
        LocationOffset = new Vector2(x, y);
        Size = new Vector2(width, height);   
    }

    public Rectangle CalculateBoundingBox(Vector2 location)
    {
        return new Rectangle(
            (int)location.X + (int)LocationOffset.X,
            (int)location.Y + (int)LocationOffset.Y,
            (int)Size.X,
            (int)Size.Y);
               
    }
}
