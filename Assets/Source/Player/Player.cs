using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory Inventory { get; private set; }

    private void Start()
    {
        Inventory = new Inventory();
    }
}
