using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Settings/Spot Settings", fileName = "New Spot Settings")]
public class SpotSettings : ScriptableObject
{
    public ResourceType InputResource;
    [Min(1)] public int InputValue;
    public ResourceType OutputResource;
    [Min(1)] public int OutputValue;
    public float ProductionDuration;
}
