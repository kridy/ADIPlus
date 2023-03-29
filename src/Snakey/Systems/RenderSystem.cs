using ADIPlus.Drawing;

using MinECS;

public class RenderSystem
{
    private readonly AsciiGraphics _surface;

    public RenderSystem(AsciiGraphics surface)
    {
        _surface = surface;
    }

    public void Update(double delta)
    {
        var renderComponents = ComponentManager.GetActiveComponents<RenderComponent>();

        for (int i = 0; i < renderComponents.Length; i++)
        {
            var renderComponent = renderComponents[i];

            renderComponent.ImageGenerator(_surface, renderComponent.Owner);
        }
    }
}



