using System.Collections.Concurrent;
using DemoApp.Models;

namespace DemoApp.Repositories;

public class InMemoryItemRepository : IItemRepository
{
    private readonly ConcurrentDictionary<Guid, Item> _items = new();

    public InMemoryItemRepository()
    {
        // Seed with sample data
        var sample = new Item(Guid.NewGuid(), "Sample item", "This is a sample item.");
        _items[sample.Id] = sample;
    }

    public IEnumerable<Item> GetAll() => _items.Values;

    public Item? Get(Guid id) => _items.TryGetValue(id, out var item) ? item : null;

    public Item Create(Item item)
    {
        _items[item.Id] = item;
        return item;
    }

    public bool Update(Guid id, Item item)
    {
        if (!_items.ContainsKey(id)) return false;
        _items[id] = item;
        return true;
    }

    public bool Delete(Guid id) => _items.TryRemove(id, out _);
}
