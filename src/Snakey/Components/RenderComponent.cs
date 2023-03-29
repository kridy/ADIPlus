using ADIPlus.Drawing;

using MinECS;

public class RenderComponent : Component
{
    public RenderComponent(Action<AsciiGraphics, GameObject> imageGen)
    {
        this.ImageGenerator = imageGen;
    }

    public readonly Action<AsciiGraphics, GameObject> ImageGenerator;
}



