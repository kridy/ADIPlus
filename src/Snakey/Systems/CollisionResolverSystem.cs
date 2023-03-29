using MinECS;

public class CollisionResolverSystem
{
    public void Update(double delta)
    {
        var evt = World.DequeueCollisionEvent<CollisionEvent>();

        while (evt != null)
        {
            var translation1 = evt.objA.GetComponent<TranslationComponent>();
            var translation2 = evt.objB.GetComponent<TranslationComponent>();

            translation1.Location = translation1.Location + (translation1.DistanceMoved * -1 * 2);
            translation2.Location = translation2.Location + (translation2.DistanceMoved * -1 * 2);
            
            evt = World.DequeueCollisionEvent<CollisionEvent>();
        }
    }
}
