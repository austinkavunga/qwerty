using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarDisplay : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public Image[] hotbarImages;
    public TMP_Text[] hotbarQuantityTexts;

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (inventoryManager.itemSlot[i].quantity > 0)
            {
                hotbarImages[i].sprite = inventoryManager.itemSlot[i].itemSprite;
                hotbarQuantityTexts[i].text = inventoryManager.itemSlot[i].quantity.ToString();
                hotbarQuantityTexts[i].enabled = true;
            }
            else
            {
                hotbarImages[i].sprite = inventoryManager.itemSlot[i].emptySprite;
                hotbarQuantityTexts[i].enabled = false;
            }
        }
    }
}

