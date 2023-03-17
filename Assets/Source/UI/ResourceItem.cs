using TMPro;
using UnityEngine;

public class ResourceItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _quantityText;

    public void SetQuantity(int quantity)
    {
        _quantityText.text = quantity.ToString();
    }
}
