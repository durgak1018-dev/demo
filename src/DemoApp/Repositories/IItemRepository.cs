using DemoApp.Models;

namespace DemoApp.Repositories;

public interface IItemRepository
{
    IEnumerable<Item> GetAll();
    Item? Get(Guid id);
    Item Create(Item item);
    bool Update(Guid id, Item item);
    bool Delete(Guid id);
}
