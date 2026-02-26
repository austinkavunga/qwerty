using UnityEngine;

[System.Serializable]
public class InventorySlot 
{
    [SerializeField] private InventoryItemData itemData; // Reference to data
    [SerializeField] private int stackSize; // Current stack size - how much of the data we have

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    // Constructor to make an inventory slot with an item inside
    public InventorySlot(InventoryItemData source, int amount) 
    {
        itemData = source;
        stackSize = amount;
    }

    // Constructor to make an empty inventory slot
    public InventorySlot() 
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }

    public void AssignItem(InventorySlot invSlot) // Assigns an item to the slot
    {
        if(itemData == invSlot.ItemData) // Does the slot contain the same item? Add to the stack if so.
        {
            AddToStack(invSlot.StackSize);
        }
        else // Overwrite slot with the inventory slot were passing in
        {
            itemData = invSlot.ItemData;
            stackSize = 0;
            AddToStack(invSlot.StackSize);
        }
    }

    //Updates slot directly
    public void UpdateInventorySlot(InventoryItemData data, int amount) 
    {
        itemData = data;
        stackSize = amount;
    }

    // Check if there is room left in a stack to take an amount of the data
    public bool EnoughRoomLeftInStack(int amountToAdd, out int amountRemaining) 
    {
        amountRemaining = itemData.MaxStackSize - stackSize;
        return EnoughRoomLeftInStack(amountToAdd);
    }

    public bool EnoughRoomLeftInStack(int amountToAdd)
    {

        if (itemData == null || itemData != null &&  StackSize + amountToAdd <= itemData.MaxStackSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Validation is not required as validation is completed before method is called

    public void AddToStack(int amount) 
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public bool SplitStack(out InventorySlot splitStack)
    {
        if (stackSize <= 1) // Checks if there is enough of an item to split
        {
            splitStack = null;
            return false;
        }
        int halfStack = Mathf.RoundToInt(stackSize / 2); //Gets half the stack
        RemoveFromStack(halfStack);

        splitStack = new InventorySlot(itemData, halfStack); // Creates a copy of the slot with half the stack size
        return true;
        
        
    }
}
