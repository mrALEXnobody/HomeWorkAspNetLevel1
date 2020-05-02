using WebStoreGusev.DomainNew.Entities.Base;
using WebStoreGusev.DomainNew.Entities.Base.Interfaces;

namespace WebStoreGusev.DomainNew.Entities
{
    /// <summary>
    /// Сущность бренд.
    /// </summary>
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
