using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Resources))]
public class PickUp : MonoBehaviour
{
    private const float MinDistance = 0.1f;

    public event Action<PickUp, Resource> PickedUp;

    [SerializeField] private PickUpSettings _pickUpSettings;
    [SerializeField] private PlayerDetector _playerDetector;

    private Resource _resource;
    private Collider _collider;
    private Rigidbody _rigidbody;
    private Transform _target;

    private void Update()
    {
        if (_target == null && _playerDetector.IsPlayerInRange == true)
        {
            StartMoveTo(_playerDetector.Players.First().transform);
        }

        if (_target == null)
        {
            return;
        }

        MoveTo(_target.position);
    }

    public void OnEnable()
    {
        _target = null;
        transform.localScale = Vector3.one;
        CheckAndFindComponents();
        SetCollidersEnabled(true);
        SetRigidbodyUseGravity(true);
    }

    public void SetActive(bool isActive)
    {
        CheckAndFindComponents();

        _collider.enabled = isActive;

        if (_rigidbody != null)
        {
            _rigidbody.useGravity = isActive;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    public void StartMoveTo(Transform target)
    {
        SetRigidbodyUseGravity(false);
        SetCollidersEnabled(false);
        _target = target;
    }

    private void MoveTo(Vector3 position)
    {
        if (Vector3.Distance(transform.position, position) <= MinDistance)
        {
            EndMove();
        }

        transform.position = Vector3.MoveTowards(transform.position,
            position, _pickUpSettings.MoveSpeed * Time.deltaTime);
        transform.localScale = Vector3.MoveTowards(transform.localScale,
            Vector3.zero, _pickUpSettings.ScaleSpeed * Time.deltaTime);
    }

    private void CheckAndFindComponents()
    {
        if (_resource == null)
        {
            _resource = GetComponent<Resource>();
        }

        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }

        if (_rigidbody == null)
        {
            TryGetComponent(out _rigidbody);
        }
    }

    private void SetRigidbodyUseGravity(bool isEnabled)
    {
        if (_rigidbody == null)
        {
            return;
        }

        _rigidbody.useGravity = isEnabled;
        _rigidbody.velocity = Vector3.zero;
    }

    private void SetCollidersEnabled(bool isEnabled)
    {
        _collider.enabled = isEnabled;
    }

    private void EndMove()
    {
        if (_target.TryGetComponent(out Player player))
        {
            player.Inventory.AddResource(_resource.ResourceType, _resource.Quantity);
        }
        else if (_target.TryGetComponent(out Spot spot))
        {
            spot.AddResource(_resource.Quantity);
        }

        PickedUp?.Invoke(this, _resource);
    }
}
