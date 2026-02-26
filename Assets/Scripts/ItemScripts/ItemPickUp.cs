using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;

    private CircleCollider2D myCollider;

    private void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();

        //If it collides with an object without an inventory nothing happens
        if (!inventory) 
        {
            return;
        }

        //Checks if it can be added to the inventory then destroys the Game Object
        if (inventory.InventorySystem.AddToInventory(ItemData,1)) 
        {
            Destroy(this.gameObject);
        }
    }
}