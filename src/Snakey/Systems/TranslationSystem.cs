using MinECS;

public class TranslationSystem
{
    public void Update(double delta)
    {
        var translations = ComponentManager.GetActiveComponents<TranslationComponent>();

        for (int i = 0; i < translations.Length; i++)
        {
            var current = translations[i];

            current.DistanceMoved = (current.Speed * current.Direction * (float)delta);

            current.Location = current.Location + current.DistanceMoved;
        }        
    }
}


















