using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash("Moving");

    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetBool(IsMoving, _playerMove.IsMoving);
    }
}
