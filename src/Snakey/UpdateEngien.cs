using MinECS;

public class UpdateEngien
{
    public void Update(double delta)
    {
        ComponentManager.UpdateAllActive<PlayerComponent>(delta);
        ComponentManager.UpdateAllActive<SimpleAIComponent>(delta);
        ComponentManager.UpdateAllActive<TranslationComponent>(delta);
        ComponentManager.UpdateAllActive<ConsumerComponent>(delta);
    }
}

