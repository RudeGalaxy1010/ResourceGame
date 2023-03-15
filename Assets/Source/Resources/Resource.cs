using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Resource", fileName = "New Resource")]
public class Resource : ScriptableObject
{
    public string Name;
    public GameObject Prefab;
}
