using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Sprite emptySprite;

    public void SetFrom(ItemSlot source)
    {
        if (source == null || source.quantity == 0)
        {
            Clear();
            return;
        }

        itemImage.sprite = source.itemSprite != null ? source.itemSprite : emptySprite;
        quantityText.text = source.quantity > 1 ? source.quantity.ToString() : "";
    }

    public void Clear()
    {
        if (itemImage != null) itemImage.sprite = emptySprite;
        if (quantityText != null) quantityText.text = "";
    }
}
