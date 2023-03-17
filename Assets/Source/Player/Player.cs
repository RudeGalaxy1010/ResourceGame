using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _move;

    public Inventory Inventory { get; private set; } = new Inventory();
    public PlayerMove Move => _move;
}
