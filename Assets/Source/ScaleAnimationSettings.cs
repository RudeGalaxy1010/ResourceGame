using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Settings/Scale Animation Settings", fileName = "New Scale Animation Settings")]
public class ScaleAnimationSettings : ScriptableObject
{
    public float ScaleEndValue;
    public float Duration;
}
