using ADIPlus.Drawing;
using MinECS;

public class RenderComponent : Component
{
    public RenderComponent(AsciiGraphics surface, Action<AsciiGraphics, GameObject> imageGen)
    {
        this.surface = surface;
        this.imageGen = imageGen;
    }

    private readonly AsciiGraphics surface;
    private readonly Action<AsciiGraphics, GameObject> imageGen;

    public override void Update(double delta)
    {
        imageGen(surface, Owner);
    }
}

