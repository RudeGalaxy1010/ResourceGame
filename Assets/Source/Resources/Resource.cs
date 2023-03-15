using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private int _quantity = 1;

    public ResourceType ResourceType => _resourceType;
    public int Quantity => _quantity;
}
