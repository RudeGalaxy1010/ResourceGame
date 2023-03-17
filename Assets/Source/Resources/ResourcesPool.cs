using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesPool : MonoBehaviour
{
    [SerializeField] private ResourcePrefabs _resourcePrefabs;
    [SerializeField] private int _startQuantity;

    private List<Resource> _resources;

    private void Start()
    {
        _resources = new List<Resource>(_startQuantity);

        for (int i = 0; i < _startQuantity; i++)
        {
            CreateResource(ResourceType.Wood);
            CreateResource(ResourceType.Metal);
            CreateResource(ResourceType.Crystal);
        }
    }

    public Resource Get(ResourceType resourceType)
    {
        Resource result = _resources.FirstOrDefault(r => r.ResourceType == resourceType)
            ?? CreateResource(resourceType);
        result.gameObject.SetActive(true);
        result.transform.SetParent(null, true);
        _resources.Remove(result);
        return result;
    }

    public List<Resource> Get(ResourceType resourceType, int quantity)
    {
        List<Resource> resources = new List<Resource>(quantity);

        for (int i = 0; i < quantity; i++)
        {
            resources.Add(Get(resourceType));
        }

        return resources;
    }

    public void Return(Resource resource)
    {
        resource.gameObject.SetActive(false);
        resource.transform.position = transform.position;
        resource.transform.SetParent(transform, true);
        _resources.Add(resource);
    }

    private Resource CreateResource(ResourceType resourceType)
    {
        Resource prefab = _resourcePrefabs.GetPrefab(resourceType);
        Resource resource = Instantiate(prefab, transform);
        resource.gameObject.SetActive(false);
        _resources.Add(resource);
        return resource;
    }
}
