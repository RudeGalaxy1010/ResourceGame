using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Settings/Drop Settings", fileName = "New Drop Settings")]
public class DropSettings : ScriptableObject
{
    public float DropHeight = 1f;
    public float Spread = 1f;
}
