using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public GameObject InventoryMenu;
    public bool inventoryPressed;
    private bool menuActivated;
    public ItemSlot[] itemSlot;


    private void Awake()
    {
        inventoryPressed = false;

    }
    private void toggleInventory()
    {
        if (inventoryPressed == false)
        {
            inventoryPressed = true;
        }
        else if (inventoryPressed == true)
        {
            inventoryPressed = false;
        }
    }

    private void Update()
    {

        if (PlayerController.tabPressed == true)
        {
            toggleInventory();
            PlayerController.tabPressed = false;
        }

        if (inventoryPressed == false)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
        }
        else if (inventoryPressed == true)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSleceted = false;
        }
    }
}
