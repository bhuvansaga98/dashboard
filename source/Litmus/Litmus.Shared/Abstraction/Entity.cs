namespace Litmus.Shared.Abstraction
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}