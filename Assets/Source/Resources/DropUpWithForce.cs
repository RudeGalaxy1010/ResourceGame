using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class DropUpWithForce : MonoBehaviour
{
    [SerializeField] private float _dropHeight;
    [SerializeField] private float _maxSpread;

    private Collider _collider;
    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        CheckAndFindComponents();
        Drop();
    }

    private void CheckAndFindComponents()
    {
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }

        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Drop()
    {
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(GetRandomForce(), ForceMode.Impulse);
    }

    private Vector3 GetRandomForce()
    {
        float yForce = Mathf.Sqrt(2 * _dropHeight * Mathf.Abs(Physics.gravity.y));
        var forceVector = new Vector3(Random.value, 0, Random.value) * _maxSpread;
        forceVector.y = yForce;
        return forceVector;
    }
}
