using System;
using System.Collections.Generic;
using System.Text;
using WebStoreGusev.DomainNew.Entities.Base;
using WebStoreGusev.DomainNew.Entities.Base.Interfaces;

namespace WebStoreGusev.DomainNew.Entities
{
    /// <summary>
    /// Сущность категория.
    /// </summary>
    public class Category : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Родительская секция (при наличии)
        /// </summary>
        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}
