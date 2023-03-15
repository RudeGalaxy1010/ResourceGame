using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    private const float MaxRotation = 360f;

    [SerializeField] private float _dropHeight;
    [SerializeField] private float _maxSpread;
    [SerializeField] private Player _player;
    [SerializeField] private float _collectDelay;
    [SerializeField] private float _speed;

    public void SpawnResource(Resource resource)
    {
        Resource resourceObj = Instantiate(resource, transform.position, GetRandomRotation());
        AddForce(resourceObj);
        StartCoroutine(CollectResource(resourceObj, _collectDelay));
    }

    private void AddForce(Resource resourceObj)
    {
        Rigidbody rigidbody;

        if (resourceObj.TryGetComponent(out rigidbody) == false)
        {
            rigidbody = resourceObj.AddComponent<Rigidbody>();
        }

        rigidbody.useGravity = true;
        rigidbody.AddForce(GetRandomForce(), ForceMode.Impulse);
    }

    private Quaternion GetRandomRotation()
    {
        var rotationVector = new Vector3(Random.value, Random.value, Random.value) * MaxRotation;
        return Quaternion.Euler(rotationVector);
    }

    private Vector3 GetRandomForce()
    {
        float yForce = Mathf.Sqrt(2 * _dropHeight * Mathf.Abs(Physics.gravity.y));
        var forceVector = new Vector3(Random.value, 0, Random.value) * _maxSpread;
        forceVector.y = yForce;
        return forceVector;
    }

    private IEnumerator CollectResource(Resource resource, float delay)
    {
        yield return new WaitForSeconds(delay);

        resource.GetComponent<Collider>().enabled = false;
        Rigidbody rigidbody = resource.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;

        while (resource.transform.position != _player.transform.position)
        {
            resource.transform.position = Vector3.MoveTowards(
                resource.transform.position, _player.transform.position, _speed * Time.deltaTime);
            yield return null;
        }

        // Add resource to inventory
        Destroy(resource.gameObject);
    }
}
