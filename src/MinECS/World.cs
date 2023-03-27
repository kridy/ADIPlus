using System.ComponentModel;

namespace MinECS
{
    public class World
    {
        private Dictionary<string, GameObject> gameobjects= new Dictionary<string, GameObject>();

        public GameObject Create(string id)
        {
            gameobjects[id] = new GameObject(id);

            return gameobjects[id];
        }
    }
}