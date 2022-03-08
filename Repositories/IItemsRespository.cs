using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Entities.Repositories
{
    public interface IItemsRespository
    {
        public IEnumerable<Item> GetItemsAsync();
        public Item GetItem(Guid Id);
        public void CreateItem(Item item);
        public void UpdateItem(Item item);
        public void DeleteItem(Guid id);
    }
}