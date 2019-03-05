namespace WebStore.Domain.Entities.Base.Interfaces
{
    /// <summary>
    /// Interface for Ordered Entity
    /// </summary>
    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}
