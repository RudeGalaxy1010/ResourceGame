using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Resources))]
public class PickUp : MonoBehaviour
{
    private const float MinDistance = 0.1f;

    [SerializeField] private PickUpSettings _pickUpSettings;

    private Resource _resource;
    private Player _player;

    private void Awake()
    {
        _resource = GetComponent<Resource>();
    }

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
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
        }

        Collider[] colliders = GetComponents<Collider>();

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }

        _player = player;
    }

    private void EndMove()
    {
        _player.Inventory.AddResource(_resource.ResourceType, _resource.Quantity);
        Destroy(gameObject);
    }
}
