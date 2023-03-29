using MinECS;
using System.Drawing;

public class CollisionEvent : Event
{
    public readonly GameObject objA;
    public readonly GameObject objB;

    public CollisionEvent(GameObject a, GameObject b)
    {
        this.objA = a;
        this.objB = b;
    }
}

public class CollisionDetectionSystem
{
    public void Update(double delta)
    {
        var colliders = ComponentManager.GetActiveComponents<AABBColliderComponent>();

        for (int i = 0; i < colliders.Length; i++)
        {
            var collider1 = colliders[i];
            var gameObject1 = collider1.Owner;
            var currentTranslation1 = gameObject1.GetComponent<TranslationComponent>();
            
            if (currentTranslation1 == null)
                continue;

            var AABB1 = collider1.CalculateBoundingBox(currentTranslation1.Location);

            for (int j = 0; j < colliders.Length; j++)
            {
                var collider2 = colliders[j];
                var gameObject2 = collider2.Owner;
                var currentTranslation2 = gameObject2.GetComponent<TranslationComponent>();                

                if (collider1.ComponentId == collider2.ComponentId)                    
                    continue;

                if (currentTranslation2 == null)
                    continue;

                var AABB2 = collider2.CalculateBoundingBox(currentTranslation2.Location);

                if(Intersect(AABB1, AABB2))
                    World.EnqueueCollisionEvent(new CollisionEvent(gameObject1, gameObject2));
            }
        }
    }

    public bool Intersect(RectangleF box1, RectangleF box2 )
    {
        
        //var first = box1.X < box2.X + box2.Width;
        //var second = box1.X + box1.Width > box2.X;
        //var third = box1.Y < box2.Y + box2.Height;
        //var fourth = box1.Y + box1.Height > box2.Y;

        return box1.IntersectsWith(box2); //first && second && third && fourth;
    }
}
