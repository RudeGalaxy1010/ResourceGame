using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    private const float MaxRotation = 360f;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ResourcesPool _pool;

    public Resource SpawnResource(ResourceType resourceType)
    {
        Resource resource = _pool.Get(resourceType);
        PickUp pickUp = resource.GetComponent<PickUp>();
        pickUp.PickedUp += OnResourcePickedUp;
        resource.transform.position = _spawnPoint.position;
        resource.transform.rotation = GetRandomRotation();
        return resource;
    }

    private Quaternion GetRandomRotation()
    {
        var rotationVector = new Vector3(Random.value, Random.value, Random.value) * MaxRotation;
        return Quaternion.Euler(rotationVector);
    }

    private void OnResourcePickedUp(PickUp pickUp, Resource resource)
    {
        pickUp.PickedUp -= OnResourcePickedUp;
        _pool.Return(resource);
    }
}
