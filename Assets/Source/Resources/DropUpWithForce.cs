using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class DropUpWithForce : MonoBehaviour
{
    [SerializeField] private DropSettings _dropSettings;

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
        float yForce = Mathf.Sqrt(2 * _dropSettings.DropHeight * Mathf.Abs(Physics.gravity.y));
        var forceVector = new Vector3(Random.value, 0, Random.value) * _dropSettings.Spread;
        forceVector.y = yForce;
        return forceVector;
    }
}
