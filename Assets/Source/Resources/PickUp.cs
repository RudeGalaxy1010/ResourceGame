using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Resources))]
public class PickUp : MonoBehaviour
{
    private const float MinDistance = 0.1f;

    public event Action<PickUp, Resource> PickedUp;

    [SerializeField] private PickUpSettings _pickUpSettings;

    private Resource _resource;
    private Collider[] _colliders;
    private Rigidbody _rigidbody;
    private Player _player;

    private void Update()
    {
        if (_player == null)
        {
            return;
        }

        MoveTo(_player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartMoveTo(player);
        }
    }

    public void ResetAll()
    {
        _player = null;
        transform.localScale = Vector3.one;
        CheckAndFindComponents();
        SetCollidersEnabled(true);
        SetRigidbodyUseGravity(true);
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

    private void StartMoveTo(Player player)
    {
        SetRigidbodyUseGravity(false);
        SetCollidersEnabled(false);
        _player = player;
    }

    private void CheckAndFindComponents()
    {
        if (_resource == null)
        {
            _resource = GetComponent<Resource>();
        }

        if (_colliders == null || _colliders.Length == 0)
        {
            _colliders = GetComponents<Collider>();
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
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = isEnabled;
        }
    }

    private void EndMove()
    {
        _player.Inventory.AddResource(_resource.ResourceType, _resource.Quantity);
        PickedUp?.Invoke(this, _resource);
    }
}
