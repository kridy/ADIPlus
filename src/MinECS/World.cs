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

        public static GameObject GetGameObject(string id) 
        {
            if (gameobjects.ContainsKey(id))
                return gameobjects[id];

            return null;
        }
    }
}