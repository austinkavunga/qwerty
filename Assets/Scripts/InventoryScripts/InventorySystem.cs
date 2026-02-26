using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using System.Linq;


[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots; 
    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize =>  InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size) // Constructor that sets the amount of slots
    {
        inventorySlots = new List<InventorySlot>(size);
        
        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot)) 
        {
            foreach(var slot in invSlot)
            {
                if (slot.EnoughRoomLeftInStack(amountToAdd, out int amountRemaining))
                {
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                } 
            }
        }

        // Gets first free slot if there isn't a partially full slot with the item already
        if (HasFreeSlot(out InventorySlot freeSlot)) 
        {
            if(freeSlot.EnoughRoomLeftInStack(amountToAdd))
            {
                freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
                OnInventorySlotChanged?.Invoke(freeSlot);
                return true;
            }

            
        }

        return false;
    }

    //Checks whether the item exists in the inventory.
    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> invSlot) 
    {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList(); //If they do passes out a list of all of them.
        return invSlot == null ? false : true; // If they do return true, if not return false.
    }

    //Gets the first free slot that has no data in it
    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
