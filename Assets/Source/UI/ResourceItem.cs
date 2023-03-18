using TMPro;
using UnityEngine;

public class ResourceItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _quantityText;
    [SerializeField] private ScaleAnimation _scaleAnimation;

    private int _currentQuantity;

    public void SetQuantity(int quantity)
    {
        if (_currentQuantity < quantity)
        {
            _scaleAnimation.PlayOnce();
        }

        _currentQuantity = quantity;
        _quantityText.text = quantity.ToString();
    }
}
