using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public abstract class BaseRepository<T>
    where T : class, IComponent, ICloneable
{
    private readonly List<T> _storage = new();

    public IEnumerable<T> All => _storage;

    public T? GetById(Guid id) => _storage.FirstOrDefault(item => item.Id == id);

    public T? Clone(Guid id)
    {
        T? item = GetById(id);
        return (T?)item?.Clone();
    }

    public void Add(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (_storage.Any(existingItem => existingItem.Id == item.Id))
            throw new InvalidOperationException($"Item with ID {item.Id} already exists.");

        _storage.Add(item);
    }

    public void Update(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        T? existingItem = GetById(item.Id);
        if (existingItem == null)
            throw new InvalidOperationException($"Item with ID {item.Id} not found.");

        int index = _storage.IndexOf(existingItem);
        _storage[index] = item;
    }

    public void Delete(Guid id)
    {
        T? existingItem = GetById(id);
        if (existingItem != null)
            _storage.Remove(existingItem);
    }
}