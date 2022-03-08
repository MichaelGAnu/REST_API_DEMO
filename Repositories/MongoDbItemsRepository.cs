using System;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Entities.Repositories;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRespository
    {
        const string DatabaseName = "Catalog";
        const string CollectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemsRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(DatabaseName);
            itemsCollection = database.GetCollection<Item>(CollectionName);
        }

        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}