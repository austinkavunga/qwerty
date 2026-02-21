using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TMPro;

[CreateAssetMenu(menuName = "InventorySystem/Item Database")]
public class Database : ScriptableObject
{
    [SerializeField] private List<InventoryItemData> itemDatabase;

    [ContextMenu("Set IDs")]
    public void SetIDs()
    {
        itemDatabase = new List<InventoryItemData>();

        var founditems = Resources.LoadAll<InventoryItemData>(path:"Item Data").OrderBy(i => i.ID).ToList();

        var hasIDInRange = founditems.Where(i => i.ID != -1 && i.ID < founditems.Count).OrderBy(i=>i.ID).ToList();
        var hasIDNotInRange = founditems.Where(i => i.ID != -1 && i.ID > founditems.Count).OrderBy(i => i.ID).ToList();
        var noId = founditems.Where(i => i.ID <= -1 ).ToList(); 

        var index = 0;
        for (int i = 0; i < founditems.Count; i++)
        {
            InventoryItemData itemToAdd;
            itemToAdd = hasIDInRange.Find(d => d.ID == i);
            if (itemToAdd != null)
            {
                itemDatabase.Add(itemToAdd);
            }
            else if(index < noId.Count)
            {
                noId[index].ID = i;
                itemToAdd = noId[index];
                index++;
                itemDatabase.Add(itemToAdd);
            }
            foreach(var item in hasIDNotInRange)
            {
                itemDatabase.Add(item);
            }
        }
    }

    public InventoryItemData GetItem(int id)
    {
        return itemDatabase.Find(i => i.ID == id);
    }
}
