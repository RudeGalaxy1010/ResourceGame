using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Settings/Production Settings", fileName = "New Production Settings")]
public class ProductionSettings : ScriptableObject
{
    public float TimeToGetResourceUnit;
    public int MaxResourcesBeforeRecover;
    public float RecoverTime;
}
