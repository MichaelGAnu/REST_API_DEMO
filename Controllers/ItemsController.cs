using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Entities.Repositories;
using Catalog.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRespository _repository;

        public ItemsController(IItemsRespository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _repository.GetItemsAsync().Select(item =>item.AsDto());
            // new ItemDto{
            //          Id = item.Id,
            //          Name = item.Name,
            //          Price = item.Price,
            //          CreatedDate = item.CreatedDate
            //         });
            return items;    
        }
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item =  _repository.GetItem(id);
            if(item is null){
                return  NotFound();
            }
            return item.AsDto();
        }
        //Post /Items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
           Item item = new Item
            {
              Id = Guid.NewGuid(),
              Name = createItemDto.Name, 
              Price = createItemDto.Price,
              CreatedDate = DateTimeOffset.UtcNow
            };
            _repository.CreateItem(item );
            //CreatedAtAction (string actionName, string controllerName, object routeValues, object value)
           //creates resource with status code of 201
            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.AsDto());
        }
        //Put /items/id
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
             var existingItem = _repository.GetItem(id);
             if(existingItem is null){
                 return NotFound();
             }
             Item item = existingItem with{
                 Name  = updateItemDto.Name, 
                 Price = updateItemDto.Price
             };
             _repository.UpdateItem(item);
            //  Returns:The created NoContentResult object for the response.
             return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);
            if(existingItem is null){
                return NotFound();

            }
            _repository.DeleteItem(id);
            return NoContent();
        }
    }
}