using System;
using System.Collections.Generic;

public class Inventory
{
    private const string NegativeQuantityExceptionMessage = "Negative quantity of resource is not allowed";

    public event Action<Dictionary<ResourceType, int>> ResourcesUpdated;

    private Dictionary<ResourceType, int> _inventory;

    public Inventory()
    {
        _inventory = new Dictionary<ResourceType, int>();
    }

    public bool HasResource(ResourceType resourceType) => _inventory.ContainsKey(resourceType);
    public bool HasEnoughResource(ResourceType resourceType, int quantity) => 
        HasResource(resourceType) && _inventory[resourceType] >= quantity;

    public void AddResource(ResourceType resourceType, int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException(NegativeQuantityExceptionMessage);
        }

        if (quantity == 0)
        {
            return;
        }

        if (_inventory.ContainsKey(resourceType))
        {
            _inventory[resourceType] += quantity;
            return;
        }

        _inventory.Add(resourceType, quantity);
        ResourcesUpdated?.Invoke(_inventory);
    }

    public void RemoveResource(ResourceType resourceType, int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentException(NegativeQuantityExceptionMessage);
        }

        if (quantity == 0)
        {
            return;
        }

        if (_inventory.ContainsKey(resourceType) == false)
        {
            throw new ArgumentException("Inventory does not contain resource you are trying to remove");
        }

        if (_inventory[resourceType] < quantity)
        {
            throw new Exception("Can't remove more resources than inventory has");
        }

        _inventory[resourceType] -= quantity;
        ResourcesUpdated?.Invoke(_inventory);
    }
}
