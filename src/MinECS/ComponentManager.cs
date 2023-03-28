using System.Data;
using System.Runtime.CompilerServices;

namespace MinECS
{
    public static class ComponentManager
    {
        public static Dictionary<string, List<Component>> objectComponentMap= new Dictionary<string, List<Component>>();
        public static void Register<T>(GameObject gameObject, T component) where T : Component 
        { 
            if(!objectComponentMap.ContainsKey(gameObject.Id))
                objectComponentMap[gameObject.Id] = new List<Component>();

            objectComponentMap[gameObject.Id].Add(component);
        }

        public static T[] GetComponents<T>() where T : Component
        {
            return objectComponentMap
                .SelectMany(kvp => kvp.Value)
                .Where(v => v is T)
                .Cast<T>()
                .ToArray();    
        }

        public static T[] GetActiveComponents<T>() where T : Component
        {
            return objectComponentMap
                .SelectMany(kvp => kvp.Value)
                .Where(v => v is T && v.IsActive)
                .Cast<T>()
                .ToArray();
        }

        public static T? GetComponent<T>(GameObject gameObject) where T : Component
        {
            if (!objectComponentMap.ContainsKey(gameObject.Id))
                return null;

            return (T?)objectComponentMap[gameObject.Id].FirstOrDefault(go => go is T);
        }

        public static void UpdateAll<T>(this T[] comp, double delta) where T : Component
        {
            for (int i = 0; i < comp.Length; i++)
            {
                comp[i].Update(delta);
            }
        }

        public static void UpdateAll<T>(double delta) where T : Component
        {
            var comp = GetComponents<T>();

            comp.UpdateAll(delta);            
        }

        public static void UpdateAllActive<T>(double delta) where T : Component
        {
            var comp = GetActiveComponents<T>();

            comp.UpdateAll(delta);
        }
    }
}