using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private const string SaveFileName = "save";
    private const string FileExtension = ".json";

    [SerializeField] private Player _player;

    private string SavePath => Path.Combine(Application.dataPath, SaveFileName + FileExtension);

    private void OnEnable()
    {
        LoadSave(_player.Inventory);
    }

    private void OnDisable()
    {
        Save(_player.Inventory);
    }

    private void Save(Inventory inventory)
    {
        Dictionary<ResourceType, int> resources = inventory.GetData();
        ResourceSave resourcesToSave = new ResourceSave()
        {
            ResourceType = resources.Keys.Select(k => (int)k).ToArray(),
            Quantity = resources.Values.ToArray()
        };

        string saveString = JsonUtility.ToJson(resourcesToSave);
        File.WriteAllText(SavePath, saveString);
    }

    private void LoadSave(Inventory inventory)
    {
        if (File.Exists(SavePath) == false)
        {
            return;
        }

        string saveString = File.ReadAllText(SavePath);
        ResourceSave resourceSave = JsonUtility.FromJson<ResourceSave>(saveString);

        Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

        for (int i = 0; i < resourceSave.ResourceType.Length; i++)
        {
            resources.Add((ResourceType)resourceSave.ResourceType[i], resourceSave.Quantity[i]);
        }

        inventory.SetData(resources);
    }
}
