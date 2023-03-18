using System;
using System.Collections.Generic;

public class Inventory
{
    private const string NegativeQuantityExceptionMessage = "Negative quantity of resource is not allowed";

    public event Action<Inventory> ResourcesUpdated;

    private Dictionary<ResourceType, int> _resources;

    public Inventory()
    {
        _resources = new Dictionary<ResourceType, int>();
    }

    public bool HasResource(ResourceType resourceType) => _resources.ContainsKey(resourceType) 
        && _resources[resourceType] > 0;
    public bool HasEnoughResource(ResourceType resourceType, int quantity) =>
        HasResource(resourceType) && _resources[resourceType] >= quantity;
    public int GetResourceQuantity(ResourceType resourceType) => HasResource(resourceType) ?
        _resources[resourceType] : 0;

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

        if (_resources.ContainsKey(resourceType))
        {
            _resources[resourceType] += quantity;
            ResourcesUpdated?.Invoke(this);
            return;
        }

        _resources.Add(resourceType, quantity);
        ResourcesUpdated?.Invoke(this);
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

        if (_resources.ContainsKey(resourceType) == false)
        {
            throw new ArgumentException("Inventory does not contain resource you are trying to remove");
        }

        if (_resources[resourceType] < quantity)
        {
            throw new Exception("Can't remove more resources than inventory has");
        }

        _resources[resourceType] -= quantity;
        ResourcesUpdated?.Invoke(this);
    }
}
