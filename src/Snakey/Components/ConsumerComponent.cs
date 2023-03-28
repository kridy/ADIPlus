using MinECS;

using System.Numerics;

public class ConsumerComponent : Component
{
    public override void Update(double delta)
    {
        var allConsumable = ComponentManager.GetComponents<ConsumableComponent>();

        var ownerTranslate = ComponentManager.GetComponent<TranslationComponent>(this.Owner);

        foreach (var consumable in allConsumable)
        {
            var comTranslation = ComponentManager.GetComponent<TranslationComponent>(consumable.Owner);

            if (comTranslation == null || ownerTranslate == null)
                continue;

            if (comTranslation?.ComponentId == ownerTranslate?.ComponentId)
                continue;

            if (Intersects(comTranslation, ownerTranslate))
            {
                //take energy from consumable and grow snake

                comTranslation.Location = new Vector2(4, 10);
            }
        }
    }

    public bool Intersects(TranslationComponent t1, TranslationComponent t2)
    {
        var x1 = (int)t1.Location.X;
        var y1 = (int)t1.Location.Y;
        var x2 = (int)t2.Location.X;
        var y2 = (int)t2.Location.Y;

        return x1 == x2 && y1 == y2;
    }
}



















