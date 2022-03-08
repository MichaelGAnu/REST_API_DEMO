using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Entities.Repositories
{
    public class ItemsRepository  : IItemsRespository
    {
        private readonly List<Item> items = new (){
              new Item{
                  Id = Guid.NewGuid(),
                  Name = "Coper Belt", 
                  Price = 20,
                  CreatedDate = DateTimeOffset.UtcNow
              },
               new Item{
                  Id = Guid.NewGuid(),
                  Name = "Mercury Jack", 
                  Price = 201,
                  CreatedDate = DateTimeOffset.UtcNow
              },
               new Item{
                  Id = Guid.NewGuid(),
                  Name = "Iron Sheet", 
                  Price = 250,
                  CreatedDate = DateTimeOffset.UtcNow
              },
        };

        public void CreateItem(Item item)
        {
           items.Add(item);
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existringItem =>existringItem.Id==id);
            items.RemoveAt(index);
        }

        public Item GetItem(Guid Id)
        {
          return items.Where(x =>x.Id==Id).SingleOrDefault();
          //  throw new NotImplementedException();
        }

        //  public Task<List<Item>> Items => items;

        public IEnumerable<Item> GetItemsAsync(){
            return  items;
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem =>existingItem.Id ==item.Id);
            
            items[index]=item;
        }


        // Task<IEnumerable<Item>> GetItemsAsync()
        // {
        //     throw new NotImplementedException();
        // }
    }
}