using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Resource", fileName = "New Resource")]
public class ResourceData : ScriptableObject
{
    public ResourceType ResourceType;
    public PickUp Prefab;
}
