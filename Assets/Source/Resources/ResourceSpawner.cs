using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    private const float MaxRotation = 360f;

    public void SpawnResource(Resource resource)
    {
        Instantiate(resource, transform.position, GetRandomRotation());
    }

    private Quaternion GetRandomRotation()
    {
        var rotationVector = new Vector3(Random.value, Random.value, Random.value) * MaxRotation;
        return Quaternion.Euler(rotationVector);
    }
}
