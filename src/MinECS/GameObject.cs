namespace MinECS
{
    public class GameObject
    {
        public string Id;

        public GameObject(string id)
        {
            Id = id;
        }

        public GameObject Add(Component component)
        {
            ComponentManager.Register(this, component);
            
            component.Owner = this;
            
            return this;            
        }

        public GameObject Remove(Component component)
        {
            ComponentManager.Register(this, component);

            component.Owner = this;

            return this;
        }
    }
}