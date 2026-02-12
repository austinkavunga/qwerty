using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectHotbarSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectHotbarSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectHotbarSlot(2);
        }
    }

    private void SelectHotbarSlot(int slotIndex)
    {
        if (slotIndex >= inventoryManager.itemSlot.Length)
            return;

        inventoryManager.DeselectAllSlots();

        inventoryManager.itemSlot[slotIndex].selectedShader.SetActive(true);
        inventoryManager.itemSlot[slotIndex].thisItemSleceted = true;
    }
}
