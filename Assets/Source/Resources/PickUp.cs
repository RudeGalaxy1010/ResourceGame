using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickUp : MonoBehaviour
{
    [SerializeField] private PickUpSettings _pickUpSettings;

    private Transform _target;

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        MoveTo(_target.position);
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
        if (transform.position == position)
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
        Collider[] colliders = GetComponents<Collider>();

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }

        _target = player.transform;
    }

    private void EndMove()
    {
        // Collect
        Destroy(gameObject);
    }
}
