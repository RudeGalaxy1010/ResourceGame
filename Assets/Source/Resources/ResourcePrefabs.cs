using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Resource Prefabs", fileName = "New Resource Prefabs")]
public class ResourcePrefabs : ScriptableObject
{
    public Resource WoodResourcePrefab;
    public Resource MetalResourcePrefab;
    public Resource CrystalResourcePrefab;

    public Resource GetPrefab(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Wood: return WoodResourcePrefab;
            case ResourceType.Metal: return MetalResourcePrefab;
            case ResourceType.Crystal: return CrystalResourcePrefab;
            default: return null;
        }
    }
}
