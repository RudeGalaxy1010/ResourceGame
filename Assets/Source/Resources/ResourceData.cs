using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Resource", fileName = "New Resource")]
public class ResourceData : ScriptableObject
{
    public string Name;
    public Resource Prefab;
}
