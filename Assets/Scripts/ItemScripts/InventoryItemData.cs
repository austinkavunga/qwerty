using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/ Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public int ID = -1;
    public string DisplayName;
    [TextArea(4,4)] public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    public GameObject ItemPrefab;


    public void UseItem()
    {
        if (DisplayName == "Bandage")
        {
            Health playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            playerHealth.UseBandage();

        }
        if(DisplayName == "Energy Drink")
        {
            PlayerSprint playerSprint = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSprint>();
            playerSprint.UseEnergyDrink();
        }
        Debug.Log($"Using {DisplayName}");
    }
}
