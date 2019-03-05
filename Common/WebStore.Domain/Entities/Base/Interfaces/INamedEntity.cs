namespace WebStore.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Interface for Named Entity
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }
}
