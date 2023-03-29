namespace MinECS
{
    public abstract class Component
    {
        public readonly Guid ComponentId = Guid.NewGuid();

        public bool IsActive = true;
        
        public GameObject Owner;
    }
}