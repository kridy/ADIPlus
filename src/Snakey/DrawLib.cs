using ADIPlus.Drawing;

using MinECS;

internal static class DrawLib
{
    public static void AppelImageGen(AsciiGraphics surface, GameObject gameObject)
    {
        var translate = ComponentManager.GetComponent<TranslationComponent>(gameObject);

        if (translate == null)
            throw new Exception($"Componen of type {typeof(TranslationComponent).Name} is missing from {gameObject.Id}");

        surface.DrawPoint(new AsciiPen("O", AsciiColors.Green), new Point((uint)translate!.Location.X, (uint)translate!.Location.Y));
    }
    public static void SnakeImageGen(AsciiGraphics surface, GameObject gameObject)
    {
        var translate = ComponentManager.GetComponent<TranslationComponent>(gameObject);

        if (translate == null)
            throw new Exception($"Componen of type {typeof(TranslationComponent).Name} is missing from {gameObject.Id}");

        surface.DrawPoint(new AsciiPen('*', AsciiColors.Green), new Point((uint)translate!.Location.X, (uint)translate!.Location.Y));
    }
}