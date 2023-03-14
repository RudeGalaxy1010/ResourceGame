using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private NavMeshAgent _navMeshAgent;

    public bool IsMoving => _playerInput.Velocity != Vector3.zero;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsMoving == false)
        {
            return;
        }

        _navMeshAgent.Move(_playerInput.Velocity * _navMeshAgent.speed * Time.deltaTime);
    }
}
