namespace Litmus.Shared.Abstraction
{
    public interface IEntity
    {
        int Id { get; }
        string Name { get; set; }
    }
}