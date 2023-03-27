namespace MinECS
{
    public abstract class Component
    {
        protected internal GameObject Owner;
        public abstract void Update(double delta);
    }
}