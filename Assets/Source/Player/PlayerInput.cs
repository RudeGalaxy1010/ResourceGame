using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private Vector3 _velocity;

    public Vector3 Velocity => _velocity;

    private void Update()
    {
        _velocity = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
    }
}
