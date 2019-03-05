using System.ComponentModel.DataAnnotations;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Abstract Class for Named Entity : BaseEntity, INamedEntity
    /// </summary>
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
