using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Settings/Collection Settings", fileName = "New Collection Settings")]
public class CollectionSettings : ScriptableObject
{
    public float SpawnDelay = 0.25f;
    public float Spread = 2f;
}
