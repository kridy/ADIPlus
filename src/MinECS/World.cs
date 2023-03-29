using System.ComponentModel;

namespace MinECS
{
    public static class World
    {
        private static Dictionary<string, GameObject> gameobjects= new Dictionary<string, GameObject>();

        public static GameObject Create(string id)
        {
            gameobjects[id] = new GameObject(id);

            return gameobjects[id];
        }

        public static GameObject? LookupGameObject(string id) 
        {
            if (gameobjects.ContainsKey(id))
                return gameobjects[id];

            return null;
        }

        public static T[] GetActiveComponents<T>(string id) where T : Component 
        {
            return ComponentManager.GetActiveComponents<T>();
        }


        private static readonly Queue<Event> eventqueue = new Queue<Event>(); 

        public static void EnqueueCollisionEvent<T>(T evt) where T : Event
        {
            eventqueue.Enqueue(evt);         
        }

        public static T? DequeueCollisionEvent<T>() where T : Event
        {
            if(eventqueue.Count == 0)
                    return null; 
           
            return (T)eventqueue.Dequeue();
        }
    }
}